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
        public static string AddNewService(string ServiceName, int serviceType, int noOfSession, int price, int clinicId, int hospitalID, int userId)
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
                        db.sp_eMedical_addNewSession_ByHospitalID_ClinicID(ServiceName, serviceType, noOfSession, price, userId, hospitalID, clinicId, outputMsgParameter);
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
    }
}
