using System;
using System.Collections.Generic;
using System.Linq;
using ePM.Dal;

namespace ePM_Dal.Logic
{
    public static class SecurityManager
    {
        public static List<sp_lmsModulePagesByRole_Result> GetMS_PagesByRole(int _roleId)
        {
            using (var db = new ePMEntities())
            {
                var pages = db.sp_lmsModulePagesByRole(_roleId).OrderBy(x => x.ModuleId).ToList();
                return pages;
            }
        }

        public static List<LMS_Roles> Get_Roles()
        {
            using (var db = new ePMEntities())
            {
                var roles = db.LMS_Roles.Where(x => x.RoleId != 1).ToList();//All Roles Except Admin
                //admin is going to have all roles
                return roles;
            }
        }
        public static List<v_lms_RolesCount> Get_RoleswithCount()
        {
            using (var db = new ePMEntities())
            {
                var roles = db.v_lms_RolesCount.Where(x => x.RoleId != 1).ToList();//All Roles Except Admin
                //admin is going to have all roles
                return roles;
            }
        }
        public static bool AddRole(LMS_Roles newRole)
        {
            bool isAdded = false;
            if (newRole !=null)
            {
                using (var db = new ePMEntities())
                {
                    db.LMS_Roles.Add(newRole);
                    db.SaveChanges();
                    isAdded = true;
                }
            }
            return isAdded;
        }
        public static bool AddRolesRights(List<LMS_RolesRights> answers)
        {
            var isSaved = false;
            using (var db = new ePMEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        if (answers.Count > 0)
                        {
                            db.LMS_RolesRights.AddRange(answers);
                            db.SaveChanges();
                            transaction.Commit();
                            isSaved = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        ExceptionsManager.AddException(ex);
                        transaction.Rollback();
                        throw;
                    }
                }
            }
            return isSaved;
        }

        public static bool AddOrDeleteRolesRights(List<LMS_RolesRights> _insertList, List<LMS_RolesRights> _deletedList)
        {
            var isSaved = false;

            using (var db = new ePMEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    db.Configuration.ValidateOnSaveEnabled = false;
                    try
                    {
                        if (_insertList.Count > 0)
                        {
                            db.LMS_RolesRights.AddRange(_insertList);
                        }
                        if (_deletedList.Count > 0)
                        {
                            LMS_Roles delete = new LMS_Roles();
                            foreach (var item in _deletedList)
                            {
                                var dataToDeleted = db.LMS_RolesRights.Where(x => x.Id == item.Id).FirstOrDefault();
                                db.LMS_RolesRights.Remove(dataToDeleted);
                            }
                        }
                        db.SaveChanges();
                        isSaved = true;
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        ExceptionsManager.AddException(ex);
                        isSaved = false;
                        transaction.Rollback();
                    }
                    finally
                    {
                        db.Configuration.ValidateOnSaveEnabled = true;
                    }
                }
            }
            return isSaved;
        }

        public static List<sp_lms_GetPagesByRole_Result> GetPagesByRoleAndLevel(int _roleId, int _level)
        {
            //level is either 0 for parent menu items or 1 for children
            using (var db = new ePMEntities())
            {
                var data = db.sp_lms_GetPagesByRole(_roleId, _level).ToList();
                return data;
            }
        }

        public static List<string> GetPagesByRole(int _roleId)
        {
            using (var db = new ePMEntities())
            {
                List<string> pages = db.v_lms_ModulePages.Where(x => x.RoleId == _roleId).Select(x => x.Url).Distinct().ToList();
                return pages;
            }
        }

        public static bool isPageInRole(string page, int _roleId)
        {
            bool exists = false;
            if (!page.ToLower().EndsWith(".aspx"))
            {
                page = page + ".aspx";
            }
            List<string> rolePages = GetPagesByRole(_roleId);
            if (rolePages != null && rolePages.Count > 0)
            {
                foreach (var item in rolePages)
                {
                    if (page == item)
                    {
                        exists = true;
                        break;
                    }
                }
            }
            return exists;
        }

        public static bool UpdateRole(LMS_Roles updatedRole)
        {
            bool isUpdated = false;
            if (updatedRole !=null)
            {
                using (var db = new ePMEntities())
                {
                    var role = db.LMS_Roles.Where(x => x.RoleId == updatedRole.RoleId).FirstOrDefault();
                    role.RoleId = updatedRole.RoleId;
                    role.RoleName = updatedRole.RoleName;
                    role.Notes = updatedRole.Notes;
                    db.SaveChanges();
                    isUpdated = true;
                }
            }
            return isUpdated;
        }
        public static int DeleteRole(int _roleId)
        {
            int isUpdated = 0;
            try
            {
                if (_roleId > 0)
                {
                    using (var db = new ePMEntities())
                    {
                        var role = db.LMS_Roles.Where(x => x.RoleId == _roleId).FirstOrDefault();
                        //check if role is used in LMS_user
                        var users = db.LMS_User.Where(x => x.RoleId == _roleId).ToList();
                        if (users.Count ==0)
                        {
                            if (role != null)
                            {
                                db.LMS_Roles.Remove(role);
                                db.SaveChanges();
                                isUpdated = 1;
                            }
                        }

                    }
                }
            }
            catch (Exception)
            {

                isUpdated = -1;
            }
           
            return isUpdated;
        }
    }
}