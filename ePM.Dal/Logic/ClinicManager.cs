using ePM.Dal;
using ePM_Dal.Logic;
using ePM_Dal.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ePM.Dal.Logic
{
    public static class ClinicManager
    {
        public static string AddNewClinic(string clinicName, int hospitalID, int userid)
        {
            string friendlyMsg = "";
            try
            {
                using (var db = new eMedicalEntities())
                {
                    var outputMsgParameter = new ObjectParameter("msg", typeof(string));
                    // db.sp_lms_addNewUser(fname, firstName, lastName, email, mobile, empNo, position, dept, roleId, hrRoleId, outputMsgParameter);
                    db.sp_eMedical_addNewClinic(clinicName, hospitalID, userid, outputMsgParameter);
                    friendlyMsg = outputMsgParameter.Value.ToString();
                    //make default password 111111
                }
            }
            catch (Exception ex)
            {

                friendlyMsg = "Please contact your admin!. unexpected error";
                ExceptionsManager.AddException(ex);
                if (ex.InnerException != null)
                {
                    ExceptionsManager.AddException(ex.InnerException);
                }
            }


            return friendlyMsg;
        }
        public static bool checkUserClinicName(string clinicName)
        {
            bool exists = false;
            using (var db = new eMedicalEntities())
            {
                var data = db.eMedical_Clinic.Where(x => x.Clinicname == clinicName).FirstOrDefault();
                if (data != null)
                {
                    exists = true;
                }
            }
            return exists;
        }
        public static List<eMedical_Hospital> GetHospitalsList()
        {
            using (var db = new eMedicalEntities())
            {
                return db.eMedical_Hospital.ToList();
            }
        }
        public static List<eMedical_Clinic> GetClinicsList(int hospitalID)
        {
            using (var db = new eMedicalEntities())
            {
                return db.eMedical_Clinic.Where(x=>x.HospitalID == hospitalID).ToList();
            }
        }
        public static bool updateRoom(eMedical_Room updatedRoom)
        {
            bool isUpdated = false;
            if (updatedRoom != null)
            {
                using (var db = new eMedicalEntities())
                {
                    var room = db.eMedical_Room.Where(x => x.ID == updatedRoom.ID).First();
                    
                    room.RoomName = updatedRoom.RoomName;
                    room.Status = updatedRoom.Status;
                    db.SaveChanges();
                    isUpdated = true;
                }
            }
            return isUpdated;
        }
    }
}
