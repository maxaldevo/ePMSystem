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
                    // db.sp_lms_addNewUser(fname, firstName, lastName, email, mobile, empNo, position, dept, roleId, hrRoleId, outputMsgParameter);
                    db.sp_eMedical_addNewSession_ByHospitalID_ClinicID(ServiceName, serviceType, noOfSession, price, userId, hospitalID, clinicId, outputMsgParameter);
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
        public static bool checkServiceName(string serviceName)
        {
            bool exists = false;
            using (var db = new eMedicalEntities())
            {
                var data = db.eMedical_Service.Where(x => x.ServiceName == serviceName).FirstOrDefault();
                if (data != null)
                {
                    exists = true;
                }
            }
            return exists;
        }

        public static List<eMedical_Service> GetservicesList()
        {
            using (var db = new eMedicalEntities())
            {
                return db.eMedical_Service.ToList();
            }
        }
        public static List<eMedical_Service> GetservicesList(int clinicID)
        {
            using (var db = new eMedicalEntities())
            {
                return db.eMedical_Service.Where(x=>x.ClinicID == clinicID).ToList();
            }
        }
        public static List<eMedical_ServiceType> GetservicesTypeList()
        {
            using (var db = new eMedicalEntities())
            {
                return db.eMedical_ServiceType.ToList();
            }
        }
    }
}
