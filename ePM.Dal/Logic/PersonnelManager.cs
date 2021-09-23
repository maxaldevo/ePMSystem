using ePM.Dal;
using ePM_Dal.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace ePM_Dal.Logic
{
    public static class PersonnelManager
    {
        //public static List<u_PERSBase> getPersonnelList()
        //{
        //    using (ePMEntities db = new ePMEntities())
        //    {
        //        return db.u_PERSBase.ToList();
        //    }
        //}
        //public static u_HRGroup getParentGroupId(string group)
        //{
        //    using (ePMEntities db = new ePMEntities())
        //    {
        //        return db.u_HRGroup.Where(x=>x.Group == group).SingleOrDefault();
        //    }
        //}
        public static vPersonnel GetSingleByUserId(int userId)
        {
            using (eMedicalEntities db = new eMedicalEntities())
            {
                return db.vPersonnels.Where(x => x.ID == userId).SingleOrDefault();
            }
        }
        //public static vPersonnel GetSingleByPersonId(int personnelId)
        //{
        //    using (ePMEntities db = new ePMEntities())
        //    {
        //        return db.vPersonnels.Where(x => x.PersonnelID == personnelId).SingleOrDefault();
        //    }
        //}
        //public static List<GroupsDTO> GetGroups()
        //{
        //    using (var db=new ePMEntities())
        //    {
        //        return db.v_GroupsPersonnel.Select(i => new { i.ID, i.Group,i.ParentGroup,i.ParentID }).Distinct()
        //          .Select(x => new GroupsDTO
        //          {
        //              Id = x.ID,
        //              GroupName = x.Group,
        //              ParentGroup = x.ParentGroup,
        //              ParentId = (int)x.ParentID
        //          }).ToList();
        //    }
        //}
        //public static List<GroupsDTO> GetAllGroups()
        //{
        //    using (var db = new ePMEntities())
        //    {
        //        return db.u_HRGroup.Select(i => new { i.ID, i.Group,  i.ParentID }).Distinct()
        //          .Select(x => new GroupsDTO
        //          {
        //              Id = x.ID,
        //              GroupName = x.Group,
        //              ParentId = (int)x.ParentID
        //          }).ToList();
        //    }
        //}
        //public static List<GroupsDTO> GetOperationsMainGroups()
        //{
        //    using (var db = new ePMEntities())
        //    {
        //        return db.u_HRGroup.
        //            Where(x=>x.ID ==2 ||  x.ParentID==2 ||( x.ParentID  == 7 || x.ParentID == 8 || x.ParentID == 9 || x.ParentID == 10 || x.ParentID == 11))
        //            .Where(x=>x.SubGroup !=null )
        //            .Select(i => new { i.ID, i.Group, i.ParentID }).Distinct()
        //          .Select(x => new GroupsDTO
        //          {
        //              Id = x.ID,
        //              GroupName = x.Group,
        //              ParentId = (int)x.ParentID
        //          }).ToList();
        //    }
        //}
        //public static List<GroupsDTO> GetSingleGroup(string _group)
        //{
        //    using (var db = new ePMEntities())
        //    {
        //        return db.v_GroupsPersonnel.Where(x=>x.Group  == _group)
        //          .Select(x => new GroupsDTO
        //          {
        //              Id = x.ID,
        //              GroupName = x.Group,
        //              ParentGroup = x.ParentGroup,
        //              ParentId = (int)x.ParentID
        //          }).ToList();
        //    }
        //}
        //public static List<GroupsDTO> GetSingleGroupByUser(int _user)
        //{
        //    using (var db = new ePMEntities())
        //    {
        //        return db.v_GroupsPersonnel.Where(x => x.PersonnelID == _user)
        //          .Select(x => new GroupsDTO
        //          {
        //              Id = x.ID,
        //              GroupName = x.Group,
        //              ParentGroup = x.ParentGroup,
        //              ParentId = (int)x.ParentID
        //          }).ToList();
        //    }
        //}

        //public static List<TraineeDTO> GetPersonnelListByGroup(int _groupId)
        //{
        //    using (var db = new ePMEntities())
        //    {
        //        return db.v_GroupsPersonnel.Where(x=>x.ID == _groupId || x.ParentID == _groupId)
        //          .Select(x => new TraineeDTO
        //          {
        //              PersonnelId = (int)x.PersonnelID,
        //              Department  = x.Department,
        //              Position = x.Position,
        //              FullName=x.FName,
        //              Display= x.Position + " _ " + x.FName
        //          }).ToList();
        //    }
        //}

        //public static List<TraineeDTO> GetPersonnelListByGroupId(int _groupId)
        //{
        //    using (var db = new ePMEntities())
        //    {
        //        return db.v_GroupsPersonnel.Where(x => x.ID == _groupId && (!x.Position.Contains("Team Lead") || !x.Position.Contains("Section Head")))
        //          .Select(x => new TraineeDTO
        //          {
        //              PersonnelId = (int)x.PersonnelID,
        //              Department = x.Department,
        //              Position = x.Position,
        //              FullName = x.FName,
        //              Display = x.Position + " _ " + x.FName
        //          }).ToList();
        //    }
        //}
        //public static List<TraineeDTO> GetPersonnelListByGroup(string _group)
        //{
        //    using (var db = new ePMEntities())
        //    {
        //        return db.v_GroupsPersonnel.Where(x => x.Group == _group || x.ParentGroup == _group)
        //          .Select(x => new TraineeDTO
        //          {
        //              PersonnelId = (int)x.PersonnelID,
        //              Department = x.Department,
        //              Position = x.Position,
        //              FullName = x.FName,
        //              Display = x.Position + " _ " + x.FName
        //          }).ToList();
        //    }
        //}

        //public static List<TraineeDTO> GetAllPersonnel()
        //{
        //    using (var db = new ePMEntities())
        //    {
        //        return db.v_GroupsPersonnel
        //          .Select(x => new TraineeDTO
        //          {
        //              PersonnelId = (int)x.PersonnelID,
        //              Department = x.Department,
        //              Position = x.Position,
        //              FullName = x.FName,
        //              Display = x.Position + " _ " + x.FName
        //          }).ToList();
        //    }
        //}
    }
}