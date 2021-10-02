using ePM.Dal;
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

namespace ePM_Dal.Logic
{
    public static class UserManager
    {
        public static List<vPersonnel> getUsersList()
        {
            using (var db = new eMedicalEntities())
            {
                return db.vPersonnels.Where(x => x.Active == true).ToList();
            }
        }
        public static List<vPersonnel> getUsersList(int clinicid)
        {
            using (var db = new eMedicalEntities())
            {
                return db.vPersonnels.Where(x => x.Active == true && x.ClinicID == clinicid).ToList();
            }
        }
        public static List<vPersonnel> getUsersList_OnlyPatient(int clinicid)
        {
            using (var db = new eMedicalEntities())
            {
                return db.vPersonnels.Where(x => x.Active == true && x.ClinicID == clinicid && x.RoleId == 7).ToList();
            }
        }

        public static eMedical_User getSingleUser(int userId)
        {
            using (eMedicalEntities db = new eMedicalEntities())
            {
                return db.eMedical_User.Where(x=>x.ID ==userId).FirstOrDefault();//in case that we have more than result
            }
        }

        //public static vPersonnel TempValidateEmail(string email, string password)
        //{
        //    using (var db=new ePMEntities())
        //    {
        //        if (email == "n.bradshaw@kipic.com.kw")
        //        {
        //            var person = db.vPersonnels.SingleOrDefault(x => x.Email == email && password == "K@elM$#20psmm_00!");
        //            return person;
        //        }

        //        else
        //        {
        //            var person = db.vPersonnels.FirstOrDefault(x => x.Email == email && password == "Kipic123");
        //            return person;
        //        }
        //    }
        //}

        //for adding new user which is not part of u_hrpersonel or perbase tables
        //public static List<u_HRGroup> GetHRGroups()
        //{
        //    using (var db = new ePMEntities())
        //    {
        //        var groups = db.u_HRGroup.ToList();
        //        return groups;
        //    }
        //}

        public static string AddNewUser(string fname,string firstName, string lastName,string email, string mobile,
            string empNo,  int roleId)
        {
            string friendlyMsg = "";
            try
            {
                using (var db = new eMedicalEntities())
                {
                    var outputMsgParameter = new ObjectParameter("msg", typeof(string));
                    // db.sp_lms_addNewUser(fname, firstName, lastName, email, mobile, empNo, position, dept, roleId, hrRoleId, outputMsgParameter);
                    db.sp_eMedical_addNewUser(fname, firstName, lastName, email, mobile, empNo, roleId, outputMsgParameter);
                    friendlyMsg = outputMsgParameter.Value.ToString();
                    //make default password 111111
                }
            }
            catch (Exception ex)
            {

                friendlyMsg = "Please contact your admin!. unexpected error";
                ExceptionsManager.AddException(ex);
                if (ex.InnerException !=null)
                {
                    ExceptionsManager.AddException(ex.InnerException);
                }
            }
          
           
            return friendlyMsg;
        }
        public static string AddNewUser_By_HospitalID_ClinicID(string fname, string firstName, string lastName, string email, string mobile, string civilId, int roleId, int hospitalID, int clinicID)
        {
            string friendlyMsg = "";
            try
            {
                using (var db = new eMedicalEntities())
                {
                    var outputMsgParameter = new ObjectParameter("msg", typeof(string));
                    string EmpNo = RandomNumber(7000, 1000000);
                    
                    // db.sp_lms_addNewUser(fname, firstName, lastName, email, mobile, empNo, position, dept, roleId, hrRoleId, outputMsgParameter);
                    db.sp_eMedical_addNewUser_ByHospitalID_ClinicID(fname, firstName, lastName, email, mobile, EmpNo, civilId, roleId, hospitalID, clinicID, outputMsgParameter);
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
        // Instantiate random number generator.  
        private static readonly Random _random = new Random();

        // Generates a random number within a range.      
        public static string RandomNumber(int min, int max)
        {
            return _random.Next(min, max).ToString();
        }
        //public static string AddNewUser_byHospitalID_ClinicID(string fname, string firstName, string lastName, string email, string mobile,
        //   string empNo, int roleId)
        //{
        //    string friendlyMsg = "";
        //    try
        //    {
        //        using (var db = new eMedicalEntities())
        //        {
        //            var outputMsgParameter = new ObjectParameter("msg", typeof(string));
        //            // db.sp_lms_addNewUser(fname, firstName, lastName, email, mobile, empNo, position, dept, roleId, hrRoleId, outputMsgParameter);
        //            db.sp_eMedical_addNewUser(fname, firstName, lastName, email, mobile, empNo, roleId, outputMsgParameter);
        //            friendlyMsg = outputMsgParameter.Value.ToString();
        //            //make default password 111111
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        friendlyMsg = "Please contact your admin!. unexpected error";
        //        ExceptionsManager.AddException(ex);
        //        if (ex.InnerException != null)
        //        {
        //            ExceptionsManager.AddException(ex.InnerException);
        //        }
        //    }


        //    return friendlyMsg;
        //}

        public static bool checkUserEmail(string email)
        {
            bool exists = false;
            using (var db=new eMedicalEntities())
            {
                var data = db.eMedical_User.Where(x => x.Email == email).FirstOrDefault();
                if (data != null)
                {
                    exists = true;
                }
            }
            return exists;
        }
        public static bool checkUserEmpNo(string empNo)
        {
            bool exists = false;
            using (var db = new eMedicalEntities())
            {
                var data = db.eMedical_User.Where(x => x.EmployeeNo == empNo).FirstOrDefault();
                if (data !=null)
                {
                    exists = true;
                }
            }
            return exists;
        }

        //get personnel id from email  and validate the password
        public static eMedical_User validateUserByEmailReal(string useremail, string password)
        {
            eMedical_User user = null;
            //get personell id
            if (!string.IsNullOrWhiteSpace(getPersonnelNo(useremail)))
            {
                password = GetMD5HashData(password);
                //int personnelId = int.Parse(getPersonnelNo(useremail));
                using (var db = new eMedicalEntities())
                {
                    user = db.eMedical_User.Where(x => x.Email == useremail && x.Password == password && x.Active == true).FirstOrDefault();
                    return user;
                }
            }
            return user;
        }
        
        public static string getPersonnelNo(string email)
        {
            string personnelNo = "";
            using (var db=new eMedicalEntities())
            {
                var person = db.eMedical_User.Where(x => x.Email == email).FirstOrDefault();
                if (person != null)
                {
                    personnelNo = person.ID.ToString();
                }
            }
            return personnelNo;
        }




        /// <summary>
        /// take any string and encrypt it using MD5 then
        /// return the encrypted data 
        /// </summary>
        /// <param name="data">input text you will enterd to encrypt it</param>
        /// <returns>return the encrypted text as hexadecimal string</returns>
        public static  string GetMD5HashData(string data)
        {
            //create new instance of md5
            MD5 md5 = MD5.Create();

            //convert the input text to array of bytes
            byte[] hashData = md5.ComputeHash(Encoding.Default.GetBytes(data));

            //create new instance of StringBuilder to save hashed data
            StringBuilder returnValue = new StringBuilder();

            //loop for each byte and add it to StringBuilder
            for (int i = 0; i < hashData.Length; i++)
            {
                returnValue.Append(hashData[i].ToString());
            }

            // return hexadecimal string
            return returnValue.ToString();

        }

        /// <summary>
        /// encrypt input text using MD5 and compare it with
        /// the stored encrypted text
        /// </summary>
        /// <param name="inputData">input text you will enterd to encrypt it</param>
        /// <param name="storedHashData">the encrypted text
        ///         stored on file or database ... etc</param>
        /// <returns>true or false depending on input validation</returns>
        public static bool ValidateMD5HashData(string inputData, string storedHashData)
        {
            //hash input text and save it string variable
            string getHashInputData = GetMD5HashData(inputData);

            if (string.Compare(getHashInputData, storedHashData) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public static List<v_userRoles> GetUserroles()
        {
            using (var db=new  eMedicalEntities())
            {
                return db.v_userRoles.ToList();
            }
        }
        public static List<eMedical_Roles> GetRolesList()
        {
            using (var db = new eMedicalEntities())
            {
                return db.eMedical_Roles.Where(x=>x.RoleName != "SuperAdmin").ToList();
            }
        }
        //update only single field( working)
        public static void ChangeRole(int userId, int roleId)
        {
            var user = new eMedical_User() { ID = userId, RoleId = roleId };
            using (var db = new eMedicalEntities())
            {
                db.eMedical_User.Attach(user);
                db.Entry(user).Property( x => x.RoleId).IsModified = true;
                db.Configuration.ValidateOnSaveEnabled = false;
                if (db.Entry(user).Property(x => x.RoleId).GetValidationErrors().Count == 0)
                {
                    db.SaveChanges();
                }  
            }
        }

        //update password only  field
        public static bool ChangePassword(int userId, string password)
        {
            bool updated = false;
            string newPassword = GetMD5HashData(password);
            try
            {
                var user = new eMedical_User() { ID = userId, Password = newPassword };
                using (var db = new eMedicalEntities())
                {
                    db.eMedical_User.Attach(user);
                    db.Entry(user).Property(x => x.Password).IsModified = true;
                    db.Configuration.ValidateOnSaveEnabled = false;
                    if (db.Entry(user).Property(x => x.Password).GetValidationErrors().Count == 0)
                    {
                        db.SaveChanges();
                        updated = true;
                    }
                }
            }
            catch (Exception ex)
            {

                ExceptionsManager.AddException(ex);
                updated = false;
            }
            return updated;
        }
        //Deactivate user
        public static bool ChangeUserActive(int userId,bool isActive)
        {
            bool updated = false;
            try
            {
                var user = new eMedical_User() { ID = userId, Active = isActive };
                using (var db = new eMedicalEntities())
                {
                    db.eMedical_User.Attach(user);
                    db.Entry(user).Property(x => x.Active).IsModified = true;
                    db.Configuration.ValidateOnSaveEnabled = false;
                    if (db.Entry(user).Property(x => x.Active).GetValidationErrors().Count == 0)
                    {
                        db.SaveChanges();
                        updated = true;
                    }
                }
            }
            catch (Exception ex)
            {

                ExceptionsManager.AddException(ex);
                updated = false;
            }
            return updated;
        }
        //update only profile pic field( working)
        public static void UpdateProfilePic(int userId, string profilePicPath)
        {
            var user = new eMedical_User() { ID = userId, ProfilePicPath = profilePicPath };
            using (var db = new eMedicalEntities())
            {
                db.eMedical_User.Attach(user);
                db.Entry(user).Property(x => x.ProfilePicPath).IsModified = true;
                db.Configuration.ValidateOnSaveEnabled = false;
                if (db.Entry(user).Property(x => x.ProfilePicPath).GetValidationErrors().Count == 0)
                {
                    db.SaveChanges();
                }

            }
        }

        public static List<HR_RolesDTO> GetHR_Roles()
        {
            List<HR_RolesDTO> myList = new List<HR_RolesDTO>();
            using (var db = new eMedicalEntities())
            {
                var data = db.u_HRRoles.OrderBy(y => y.Name).Select(x => new { x.RoleID, x.Name ,x.Department  }).Distinct();
                foreach (var item in data)
                {
                    myList.Add(new HR_RolesDTO() { RoleId = item.RoleID, RoleName = item.Department + " _ " + item.Name });
                }
                return myList;
            }
        }

        //public static bool EmailExists(string email)
        //{
        //    bool result = false;
        //    using (var db = new eMedicalEntities())
        //    {
        //        int data = db.u_HRPersonnel.Where(x => x.EmailWork == email).Count();
        //        if (data > 0)
        //        {
        //            result = true;
        //        }
        //        else
        //        {
        //            int data2 = db.u_PERSBase.Where(x => x.Email == email).Count();
        //            if (data2 > 0)
        //            {
        //                result = true;
        //            }
        //        }
        //    }
        //    return result;
        //}
        //public static bool EmployeeNoExists(string empNo)
        //{
        //    bool result = false;
        //    using (var db = new eMedicalEntities())
        //    {
        //        int data = db.u_PERSBase.Where(x => x.EmployeeNo == empNo).Count();
        //        if (data > 0)
        //        {
        //            result = true;
        //        }

        //    }
        //    return result;
        //}
        
        public static bool IsValidEmailFormat(string email)
        {
            return new EmailAddressAttribute().IsValid(email);
        }
        //get HRGroup by personnelId
        public static int GetGroupIdByUserId(int userId)
        {
            int result = 0;
            using (var db=new eMedicalEntities())
            {
                var data = db.v_GroupsPersonnel.Where(x => x.UserId == userId).FirstOrDefault();
                if (data !=null)
                {
                    result = (int)data.ID;
                }
            }
            return result;
        }

        //update Access Role and position
        public static void ChangeRoleAndPosition(int userId, int roleId,string position )
        {
            var user = new eMedical_User() { ID = userId, RoleId = roleId };
            using (var db = new eMedicalEntities())
            {
                db.eMedical_User.Attach(user);
                db.Entry(user).Property(x => x.RoleId).IsModified = true;
                db.Configuration.ValidateOnSaveEnabled = false;
                if (db.Entry(user).Property(x => x.RoleId).GetValidationErrors().Count == 0)
                {
                    db.SaveChanges();
                }
            }
        }

        //update Access Role and position
        //public static bool ChangePosition(int personelId, string position)
        //{
        //    bool result = false;
        //    try
        //    {
        //        using (var db = new eMedicalEntities())
        //        {
        //            db.sp_updatePositionByPersonnelId(personelId, position);
        //            result = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        result = false;
        //        ExceptionsManager.AddException(ex);
        //    }
        //    return result;
        //}

    }

}

