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
    public static class HospitalManager
    {
        public static string AddNewHospital(string hospitalName, string description, int userid)
        {
            string friendlyMsg = "";
            try
            {
                using (var db = new eMedicalEntities())
                {
                    var outputMsgParameter = new ObjectParameter("msg", typeof(string));
                    // db.sp_lms_addNewUser(fname, firstName, lastName, email, mobile, empNo, position, dept, roleId, hrRoleId, outputMsgParameter);
                    db.sp_eMedical_addNewHospital(hospitalName,description,userid, outputMsgParameter);
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
        public static bool checkUserHospitalName(string hospitalName)
        {
            bool exists = false;
            using (var db = new eMedicalEntities())
            {
                var data = db.eMedical_Hospital.Where(x => x.HospitalName == hospitalName).FirstOrDefault();
                if (data != null)
                {
                    exists = true;
                }
            }
            return exists;
        }
    }
}
