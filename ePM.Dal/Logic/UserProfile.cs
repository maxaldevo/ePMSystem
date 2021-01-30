
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ePM.Dal;
using ePM_Dal.ViewModels;

namespace ePM_Dal.Logic
{
    public static class UserProfile
    {
        public static vPersonnel GetUserById(int personnelId)
        {
            using (var db =new ePMEntities())
            {
                return db.vPersonnels.SingleOrDefault(x => x.PersonnelID == personnelId);
            }
        }
        public static vPersonnel GetUserByPersonnelId(int personnelId)
        {
            using (var db = new ePMEntities())
            {
                return db.vPersonnels.SingleOrDefault(x => x.PersonnelID == personnelId);
            }
        }

        public static List<PersonelDTO> GetPersonById(int userId)
        {
            using (var db = new ePMEntities())
            {
                return db.vPersonnels.Where(x => x.PersonnelID == userId)
                  .Select(x => new PersonelDTO
                  {
                      BaseId = (int)x.BaseID,
                      FName = x.FName,
                      Department = x.Department,
                      Position = x.Position,
                      Email = x.Email
                  }).ToList();
            }
        }
        //get personnel id by user id
        public static int GetPersonnelIdByuserId(int userId)
        {
            int _personnelId = 0;
            using (var db = new ePMEntities())
            {
                var data = db.vPersonnels.Where(x => x.ID == userId).FirstOrDefault();
                if (data!=null)
                {
                    _personnelId = (int)data.PersonnelID;
                }
                 
            }
            return _personnelId;
        }

    }
}
