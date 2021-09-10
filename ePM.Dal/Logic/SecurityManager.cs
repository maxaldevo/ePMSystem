using System;
using System.Collections.Generic;
using System.Linq;
using ePM.Dal;

namespace ePM_Dal.Logic
{
    public static class SecurityManager
    {
        public static List<sp_eMedical_ModulePagesByRole_Result> GetMS_PagesByRole(int _roleId)
        {
            using (var db = new eMedicalEntities())
            {
                var pages = db.sp_eMedical_ModulePagesByRole(_roleId).ToList();
                return pages;
            }
        }

        public static List<eMedical_Roles> Get_Roles()
        {
            using (var db = new eMedicalEntities())
            {
                var roles = db.eMedical_Roles.Where(x => x.RoleId != 1).ToList();//All Roles Except Admin
                //admin is going to have all roles
                return roles;
            }
        }
        public static List<v_eMedical_RolesCount> Get_RoleswithCount()
        {
            using (var db = new eMedicalEntities())
            {
                var roles = db.v_eMedical_RolesCount.Where(x => x.RoleId != 1).ToList();//All Roles Except Admin
                //admin is going to have all roles
                return roles;
            }
        }
        public static bool AddRole(eMedical_Roles newRole)
        {
            bool isAdded = false;
            if (newRole !=null)
            {
                using (var db = new eMedicalEntities())
                {
                    db.eMedical_Roles.Add(newRole);
                    db.SaveChanges();
                    isAdded = true;
                }
            }
            return isAdded;
        }
        public static bool AddRolesRights(List<eMedical_RolesRights> answers)
        {
            var isSaved = false;
            using (var db = new eMedicalEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        if (answers.Count > 0)
                        {
                            db.eMedical_RolesRights.AddRange(answers);
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

        public static bool AddOrDeleteRolesRights(List<eMedical_RolesRights> _insertList, List<eMedical_RolesRights> _deletedList)
        {
            var isSaved = false;

            using (var db = new eMedicalEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    db.Configuration.ValidateOnSaveEnabled = false;
                    try
                    {
                        if (_insertList.Count > 0)
                        {
                            db.eMedical_RolesRights.AddRange(_insertList);
                        }
                        if (_deletedList.Count > 0)
                        {
                            eMedical_Roles delete = new eMedical_Roles();
                            foreach (var item in _deletedList)
                            {
                                var dataToDeleted = db.eMedical_RolesRights.Where(x => x.Id == item.Id).FirstOrDefault();
                                db.eMedical_RolesRights.Remove(dataToDeleted);
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

        public static List<sp_eMedical_GetPagesByRole_Result> GetPagesByRoleAndLevel(int _roleId, int _level)
        {
            //level is either 0 for parent menu items or 1 for children
            using (var db = new eMedicalEntities())
            {
                var data = db.sp_eMedical_GetPagesByRole(_roleId, _level).ToList();
                return data;
            }
        }

        public static List<string> GetPagesByRole(int _roleId)
        {
            using (var db = new eMedicalEntities())
            {
                List<string> pages = db.v_eMedical_ModulePages.Where(x => x.RoleId == _roleId).Select(x => x.Url).Distinct().ToList();
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

        public static bool UpdateRole(eMedical_Roles updatedRole)
        {
            bool isUpdated = false;
            if (updatedRole !=null)
            {
                using (var db = new eMedicalEntities())
                {
                    var role = db.eMedical_Roles.Where(x => x.RoleId == updatedRole.RoleId).FirstOrDefault();
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
                    using (var db = new eMedicalEntities())
                    {
                        var role = db.eMedical_Roles.Where(x => x.RoleId == _roleId).FirstOrDefault();
                        //check if role is used in LMS_user
                        var users = db.eMedical_User.Where(x => x.RoleId == _roleId).ToList();
                        if (users.Count ==0)
                        {
                            if (role != null)
                            {
                                db.eMedical_Roles.Remove(role);
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