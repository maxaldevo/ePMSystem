using ePM_Dal.Logic;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePM.Dal.Logic
{
    public static class ProductManager
    {
        public static string AddNewProduct_By_HospitalID_ClinicID(string pName, int qty, int costPrice, int profitPrice, int salePrice, int userId, int hospitalID, int clinicID)
        {
            string friendlyMsg = "";
            try
            {
                using (var db = new eMedicalEntities())
                {
                    var outputMsgParameter = new ObjectParameter("msg", typeof(string));
                    // db.sp_lms_addNewUser(fname, firstName, lastName, email, mobile, empNo, position, dept, roleId, hrRoleId, outputMsgParameter);
                    db.sp_eMedical_addNewProduct_ByHospitalID_ClinicID(pName, qty, costPrice, profitPrice, salePrice, userId, hospitalID, clinicID, outputMsgParameter);
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
        public static List<vProductInfo> getProductsList()
        {
            using (var db = new eMedicalEntities())
            {
                return db.vProductInfoes.Where(x => x.Status == true).ToList();
            }
        }
        public static List<vProductInfo> getProductsList(int clinicid, int userID)
        {
            using (var db = new eMedicalEntities())
            {
                return db.vProductInfoes.Where(x => x.Status == true && x.ClinicID == clinicid && x.UpdatedByID == userID).ToList();
            }
        }
    }
}
