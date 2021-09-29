using ePM_Dal.Logic;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePM.Dal.Logic
{
    public static class ServiceManager
    {
        public static string AddNewService(string ServiceName, int serviceType, int noOfSession, int price, int clinicId, int hospitalID, int roomId, int userId)
        {
            string friendlyMsg = "";
            try
            {
                using (var db = new eMedicalEntities())
                {
                    var outputMsgParameter = new ObjectParameter("msg", typeof(string));

                    bool ExistServicename = checkServiceName(ServiceName, clinicId);
                    if (!ExistServicename)
                    {
                        db.sp_eMedical_addNewSession_ByHospitalID_ClinicID(ServiceName, serviceType, noOfSession, price, userId, hospitalID, clinicId,roomId, outputMsgParameter);
                        friendlyMsg = outputMsgParameter.Value.ToString();
                    }
                    else
                        friendlyMsg = "This Service added before.";
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

        public static string AddNewRoom(string RoomName, int userid, string sessionDuration)
        {
            string friendlyMsg = "";
            try
            {
                using (var db = new eMedicalEntities())
                {
                    var outputMsgParameter = new ObjectParameter("msg", typeof(string));
                    db.sp_eMedical_addNewRoom(RoomName, userid, sessionDuration, outputMsgParameter);
                    friendlyMsg = outputMsgParameter.Value.ToString();
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
        public static bool checkUserRoomName(string RoomName)
        {
            bool exists = false;
            using (var db = new eMedicalEntities())
            {
                var data = db.eMedical_Room.Where(x => x.RoomName == RoomName).FirstOrDefault();
                if (data != null)
                {
                    exists = true;
                }
            }
            return exists;
        }
        public static List<eMedical_Room> GetRoomsList()
        {
            using (var db = new eMedicalEntities())
            {
                return db.eMedical_Room.Where(x => x.Status == true).ToList();
            }
        }
        public static List<eMedical_Room> GetRoomsList(int usrId)
        {
            using (var db = new eMedicalEntities())
            {
                return db.eMedical_Room.Where(x => x.Status == true && x.UpdatedByID == usrId).ToList();
            }
        }
        public static string AddNewServiceType(string ServiceType, int userId)
        {
            string friendlyMsg = "";
            try
            {
                using (var db = new eMedicalEntities())
                {
                    var outputMsgParameter = new ObjectParameter("msg", typeof(string));
                    db.sp_eMedical_addNewSessionType(ServiceType, userId, outputMsgParameter);
                    friendlyMsg = outputMsgParameter.Value.ToString();
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
        public static bool checkServiceName(string serviceName, int clinicId)
        {
            bool exists = false;
            using (var db = new eMedicalEntities())
            {
                var data = db.eMedical_Service.Where(x => x.ServiceName == serviceName && x.ClinicID == clinicId).FirstOrDefault();
                if (data != null)
                {
                    exists = true;
                }
            }
            return exists;
        }

        public static List<vService> GetservicesList()
        {
            using (var db = new eMedicalEntities())
            {
                return db.vServices.Where(x => x.Status == true).ToList();
            }
        }
        public static List<vService> GetservicesList(int clinicID, int userID)
        {
            using (var db = new eMedicalEntities())
            {
                return db.vServices.Where(x => x.Status == true && x.ClinicID == clinicID && x.UpdatedByID == userID).ToList();
            }
        }
        public static List<vServiceType> GetservicesTypeList()
        {
            using (var db = new eMedicalEntities())
            {
                return db.vServiceTypes.Where(x => x.Status == true).ToList();
            }
        }
        public static List<vServiceType> GetservicesTypeList(int userID, int clinicId)
        {
            using (var db = new eMedicalEntities())
            {
                return db.vServiceTypes.Where(x => x.Status == true && x.UpdatedByID == userID && x.ClinicId == clinicId).ToList();
            }
        }
        public static bool updateService(eMedical_Service updatedService)
        {
            bool isUpdated = false;
            if (updatedService != null)
            {
                using (var db = new eMedicalEntities())
                {
                    var service = db.eMedical_Service.Where(x => x.ID == updatedService.ID).First();
                    //product.ID = updatedProduct.ID;
                    service.ServiceName = updatedService.ServiceName;
                    service.NoofSessions = updatedService.NoofSessions;
                    service.Price = updatedService.Price;
                    service.Status = updatedService.Status;
                    db.SaveChanges();
                    isUpdated = true;
                }
            }
            return isUpdated;
        }
    }
}
