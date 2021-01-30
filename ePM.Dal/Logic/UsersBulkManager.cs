using ePM_Dal.ViewModels;
using ePM.Dal;
using OfficeOpenXml;
using OfficeOpenXml.DataValidation;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Validation;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MS.DAL.Utils;

namespace ePM_Dal.Logic
{
   public static class UsersBulkManager
    {
        public static string createUsersExcelTemplate(string filePath, string fileName)
        {
            if (File.Exists(Path.Combine(filePath, fileName + ".xlsx")))
            {
                File.Delete(Path.Combine(filePath, fileName + ".xlsx"));
            }
            FileInfo output = new FileInfo(Path.Combine(filePath, fileName + ".xlsx"));
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package = new ExcelPackage(output))
            {
                package.Workbook.Worksheets.Add("Users");
                using (var db = new ePMEntities())
                {
                    //populate list of Security Groups and HR Roles
                    List<u_HRRoles> hrRolesList = db.u_HRRoles.ToList();

                    List<LMS_Roles> secRoleList = db.LMS_Roles.ToList();

                    //dictionary = catList.ToDictionary(x => x.ID, x => x.Category);
                    AddListValidationHRRoles(package, "G", "Position", hrRolesList);
                    AddListValidationRoles(package, "H", "SecurityGroup", secRoleList);
                    //AddListValidationValuesFromDB(package, catList);
                }
               ExcelImportManager.AddTextCell(package, "A", "FullName");
                ExcelImportManager.AddTextCell(package, "B", "FirstName");
                ExcelImportManager.AddTextCell(package, "C", "LastName");
                ExcelImportManager.AddTextCell(package, "D", "Email");
                //AddIntCell(package, "B", "Number Column",50, "Enter only Integer Greater than 0", "Value should be greater than 0");
                ExcelImportManager.AddPhoneCell(package, "E", "PhoneNo", "Enter Phone No", "Has to be 8 digits");
                ExcelImportManager.AddTextCell(package, "F", "EmployeeNo");

                //  AddPhoneCell(package, "F", "EmployeeNo",1000, "Enter Phone No", "Has to be 8 digits");
                // AddTextCell(package, "D", "FName");
                package.Workbook.Worksheets[0].Cells.AutoFitColumns();
                //package.Workbook.Worksheets[1].Cells.AutoFitColumns();
                //package.Workbook.Worksheets[0].Column(1).Width = 30;//full name
                //package.Workbook.Worksheets[0].Column(4).Width = 30;//email
                //package.Workbook.Worksheets[0].Column(7).Width=50;//position
                //package.Workbook.Worksheets[0].Column(8).Width=50;//user access group

                using (ExcelRange cell = package.Workbook.Worksheets[0].Cells[1, 1, 1, 8])
                {
                    Color colFromHex = ColorTranslator.FromHtml("#045E7D");
                    cell.Style.Font.Size = 13;
                    cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    cell.Style.Fill.BackgroundColor.SetColor(colFromHex);
                    cell.Style.Font.Bold = true;
                    cell.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    cell.Style.Font.Color.SetColor(Color.White);
                    cell.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    //to make vertical alignment text
                   // cell.Style.TextRotation = 90;
                    cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                }
                package.SaveAs(output);
                
            }
            return output.FullName;
        }
      
        /// <summary>
        /// Adds Validation List from defined List and hide it
        /// </summary>
        /// <param name="package"></param>
        /// <param name="list"></param>
        private static void AddListValidationHRRoles(ExcelPackage package, string columnName, string colTitle, List<u_HRRoles> list)
        {
            // var mainSheet = package.Workbook.Worksheets.Add("Sheet1");
            string columnName1 = string.Concat(columnName, 1);
            package.Workbook.Worksheets[0].Cells[columnName1].Value = colTitle;
            Color colFromHex = ColorTranslator.FromHtml("#045E7D");

            string validationRange = $"Lists!${columnName}$2:${columnName}$" + (list.Count - 1).ToString();
            //create the second sheet and fill it with content
            ExcelWorksheet sheet;
            //create the second sheet and fill it with content
            if (package.Workbook?.Worksheets?.Count <= 1)
            {
                sheet = package.Workbook.Worksheets.Add("Lists");
            }
            else
            {
                sheet = package.Workbook.Worksheets[1];
            }
            sheet.Cells[columnName1].Style.Font.Bold = true;
            // sheet.Cells[columnName1].Value = "CourseCategories";
            sheet.Cells[columnName1].Style.Fill.PatternType = ExcelFillStyle.Solid;
            sheet.Cells[columnName1].Style.Fill.BackgroundColor.SetColor(colFromHex);
            for (int i = 1; i < list.Count - 1; i++)
            {
                sheet.Cells[columnName + i].Value = list[i].Name + "_" + list[i].Department;
            }

            // add a validation and set values
            var validation = package.Workbook.Worksheets[0].DataValidations.AddListValidation(string.Concat(columnName + ":", columnName));
            // Alternatively:
            // var validation = sheet.Cells["A1"].DataValidation.AddListDataValidation();
            validation.ShowErrorMessage = true;
            //  validation.ErrorStyle = ExcelDataValidationWarningStyle.warning;
            validation.ErrorStyle = ExcelDataValidationWarningStyle.stop;
            validation.ErrorTitle = "An invalid value was entered";
            validation.Error = "Select a value from the list";
            validation.PromptTitle = "Enter a integer value here";
            validation.Formula.ExcelFormula = validationRange;
            sheet.Hidden = OfficeOpenXml.eWorkSheetHidden.Hidden;
            //MessageBox.Show("Added sheet for list validation with formula");
        }
        private static void AddListValidationRoles(ExcelPackage package, string columnName, string colTitle, List<LMS_Roles> list)
        {
            // var mainSheet = package.Workbook.Worksheets.Add("Sheet1");
            string columnName1 = string.Concat(columnName, 1);
            package.Workbook.Worksheets[0].Cells[columnName1].Value = colTitle;
            Color colFromHex = ColorTranslator.FromHtml("#045E7D");
            string validationRange = $"Lists!${columnName}$1:${columnName}$" + (list.Count - 1).ToString();
            ExcelWorksheet sheet;
            //create the second sheet and fill it with content
            if (package.Workbook?.Worksheets?.Count <= 1)
            {
                sheet = package.Workbook.Worksheets.Add("Lists");
            }
            else
            {
                sheet = package.Workbook.Worksheets[1];
            }
            sheet.Cells[columnName1].Style.Font.Bold = true;
            sheet.Cells[columnName1].Value = "SecurityGroups";
            sheet.Cells[columnName1].Style.Fill.PatternType = ExcelFillStyle.Solid;
            sheet.Cells[columnName1].Style.Fill.BackgroundColor.SetColor(colFromHex);
            //sheet.Cells[columnName + 1].Value = list[0].RoleName;
            for (int i = 1; i <= list.Count - 1; i++)
            {
                sheet.Cells[columnName + i].Value = list[i].RoleName;
            }

            // add a validation and set values
            var validation = package.Workbook.Worksheets[0].DataValidations.AddListValidation(string.Concat(columnName + ":", columnName));
            // Alternatively:
            // var validation = sheet.Cells["A1"].DataValidation.AddListDataValidation();
            validation.ShowErrorMessage = true;
            //  validation.ErrorStyle = ExcelDataValidationWarningStyle.warning;
            validation.ErrorStyle = ExcelDataValidationWarningStyle.stop;
            validation.ErrorTitle = "An invalid value was entered";
            validation.Error = "Select a value from the list";
            validation.PromptTitle = "Enter a integer value here";
            validation.Formula.ExcelFormula = validationRange;
            sheet.Hidden = OfficeOpenXml.eWorkSheetHidden.Hidden;
            //MessageBox.Show("Added sheet for list validation with formula");
        }
        public static bool isValidSheet(string filePath)
        {
            bool validsheet = false;
            Stream stream = ExcelImportManager.GetStreamFromFile(filePath);
            DataTable result = ExcelImportManager.GetDTFromExcelFile(stream);
            decimal totalRows = result.Rows.Count;
            foreach (DataRow dr in result.Rows)
            {
                int index = result.Rows.IndexOf(dr);
                if (index == 0)
                {

                    if (result.Columns.Contains("FullName") && result.Columns.Contains("Position") && result.Columns.Contains("FirstName") && result.Columns.Contains("LastName")
                    && result.Columns.Contains("Email") && result.Columns.Contains("PhoneNo") && result.Columns.Contains("EmployeeNo") && result.Columns.Contains("SecurityGroup"))
                    {
                        validsheet = true;
                        break;
                    }
                }
                else
                {
                    if (validsheet == false)
                    {
                       
                        break;
                    }
                }

            }
            return validsheet;
        }
        public static List<ExcelValidationResult> ValidateUsersData(DataTable dt)
        {
            List<ExcelValidationResult> ValidResult = new List<ExcelValidationResult>();
            bool validsheet = true;
            decimal totalRows = dt.Rows.Count;
            foreach (DataRow dr in dt.Rows)
            {
                int index = dt.Rows.IndexOf(dr);

                if (!string.IsNullOrWhiteSpace(dr["Email"].ToString()) && !string.IsNullOrWhiteSpace(dr["EmployeeNo"].ToString()) && !string.IsNullOrWhiteSpace(dr["Position"].ToString())
                && !string.IsNullOrWhiteSpace(dr["FullName"].ToString()) && !string.IsNullOrWhiteSpace(dr["SecurityGroup"].ToString()))
                {
                    //Validate email format 
                    if (!UserManager.IsValidEmailFormat(dr["Email"].ToString()))
                    {
                        ValidResult.Add(new ExcelValidationResult() { RowNo = index, Reason = $" Data : ({dr["Email"].ToString()}) is Invalid Email format!" });
                        validsheet = false;
                    }
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(dr["Email"].ToString()) || string.IsNullOrWhiteSpace(dr["EmployeeNo"].ToString()) || string.IsNullOrWhiteSpace(dr["Position"].ToString())
                            || string.IsNullOrWhiteSpace(dr["SecurityGroup"].ToString()))
                    {
                        ValidResult.Add(new ExcelValidationResult() { RowNo = index, Reason = $"has blank cells!" });
                        validsheet = false;
                    }
                }
            }
            //if the ValidResult.Count <= 0 , then we have valid sheet and valid emails
            //Now we check the database for emails and employeeNo
            if (totalRows > 0 && ValidResult.Count < 1 && validsheet==true )//THERE ARE DATA AND EMAILS ARE VALID
            {
                //NOW CHECK EMPLOYEE NO AND EMAIL FROM DATABASE
                foreach (DataRow dr in dt.Rows)
                {
                    int index = dt.Rows.IndexOf(dr);


                        if (!string.IsNullOrWhiteSpace(dr["Email"].ToString()) && !string.IsNullOrWhiteSpace(dr["EmployeeNo"].ToString()) && !string.IsNullOrWhiteSpace(dr["Position"].ToString())
                            && !string.IsNullOrWhiteSpace(dr["SecurityGroup"].ToString()))
                        {
                            //email exists 
                            if (UserManager.EmailExists(dr["Email"].ToString()))
                            {
                                ValidResult.Add(new ExcelValidationResult() { RowNo = index, Reason = $" Email : ({dr["Email"].ToString()}) Exists before!" });
                                validsheet = false;
                            }
                            //email exists 
                            if (UserManager.EmployeeNoExists(dr["EmployeeNo"].ToString()))
                            {
                                ValidResult.Add(new ExcelValidationResult() { RowNo = index, Reason = $" Employee No : ({dr["EmployeeNo"].ToString()}) Exists before!" });
                                validsheet = false;
                            }
                        }
                        else
                        {
                            ValidResult.Add(new ExcelValidationResult() { RowNo = index, Reason = $"Blank records!" });
                            validsheet = false;
                            break;
                        }
                    
                }
                if (validsheet)//check for duplicates in Email and employee no
                {
                    List<string> emailsList = dt.AsEnumerable()
                           .Select(r => r.Field<string>("Email"))
                           .ToList();
                    List<object> empNoList = dt.AsEnumerable()
                     .Select(r => r.Field<object>("EmployeeNo"))
                     .ToList();
                    if (emailsList.Count > emailsList.Distinct().Count())
                    {
                        var duplicates = emailsList.GroupBy(s => s)
                             .SelectMany(grp => grp.Skip(1));
                        StringBuilder sb = new StringBuilder();
                        bool first = true;
                        foreach (var item in duplicates)
                        {
                            if (first)
                            {
                                sb.Append(item.ToString());
                            }
                            else
                            {
                                sb.Append(", " + item.ToString());
                            }
                            first = false;
                        }
                        ValidResult.Add(new ExcelValidationResult() { RowNo = 0, Reason = $" Email contains duplicate data! ,duplicate values are {sb.ToString()}" });
                        validsheet = false;
                    }
                    if (empNoList.Count > empNoList.Distinct().Count())
                    {
                        var duplicates = empNoList.GroupBy(s => s)
                              .SelectMany(grp => grp.Skip(1));
                        StringBuilder sb = new StringBuilder();
                        bool first = true;
                        foreach (var item in duplicates)
                        {
                            if (first)
                            {
                                sb.Append(item.ToString() );
                            }
                            else
                            {
                                sb.Append(", "  +item.ToString());
                            }
                            first = false;
                        }
                        ValidResult.Add(new ExcelValidationResult() { RowNo = 0, Reason = $" employeeNo contains duplicate data! ,duplicate values are {sb.ToString()}" });
                        validsheet = false;
                    }
                 
                }
            }
            return ValidResult;
        }
        public static string InsertUsersBulk(DataTable dt, Dictionary<int, string> hrRolesDictionary, Dictionary<int, string> RolesDictionary)
        {
            string insertResult = "";
                //Load thew dt
                int Id = 0;
                DataTable newUsersDT = new DataTable();
                newUsersDT.Columns.Add("Id", typeof(int));
                newUsersDT.Columns.Add("FName", typeof(string));
                newUsersDT.Columns.Add("FirstName", typeof(string));
                newUsersDT.Columns.Add("LastName", typeof(string));
                newUsersDT.Columns.Add("Email", typeof(string));
                newUsersDT.Columns.Add("Mobile", typeof(string));
                newUsersDT.Columns.Add("EmpNo", typeof(string));
                newUsersDT.Columns.Add("RoleId", typeof(int));
                newUsersDT.Columns.Add("HRRoleId", typeof(int));

                //fill new users list
                foreach (DataRow dr in dt.Rows)
                {
                    int index = dt.Rows.IndexOf(dr);
                    Id += 1;
                    newUsersDT.Rows.Add(Id, dr["FullName"].ToString(), dr["FirstName"].ToString(), dr["LastName"].ToString(), dr["Email"].ToString(),
                      dr["PhoneNo"].ToString(), dr["EmployeeNo"].ToString(), RolesDictionary.FirstOrDefault(x => x.Value == dr["SecurityGroup"].ToString()?.Trim()).Key,
                     hrRolesDictionary.FirstOrDefault(x => x.Value == dr["Position"].ToString()?.Trim()).Key);

                }
                if (newUsersDT.Rows.Count > 0)
                {
                    try
                    {
                        bool inserted = UserManager.AddUsersBulk(newUsersDT);
                        if (inserted)
                        {
                        insertResult = "Success";

                        }
                    }
                    //catch (DbEntityValidationException ee)
                    //{
                    //    foreach (var eve in ee.EntityValidationErrors)
                    //    {
                    //        MessageBox.Show("Entity of type \"{0}\" in state has the following validation errors:",
                    //            eve.Entry.Entity.GetType().Name + eve.Entry.State);
                    //        foreach (var ve in eve.ValidationErrors)
                    //        {
                    //            MessageBox.Show("- Property: \"{0}\", Error: \"{1}\"",
                    //                ve.PropertyName + ve.ErrorMessage);
                    //        }
                    //    }
                    //    throw;
                    //}
                    catch (Exception ex)
                    {
                    ExceptionsManager.AddException(ex);
                    insertResult = ex.Message;
                    }
                }
            return insertResult;
            }
        }

    
}
