using ePM.Dal;
using ePM_Dal.Logic;
using ePM_Dal.ViewModels;
using ePM_Dal.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using MS.DAL.Utils;

namespace WebApplication1
{
    public partial class AddUsersBulk : System.Web.UI.Page
    {
        public static string _fname, FileUploadPath = "";
        public static Dictionary<int, string> hrRolesDictionary = new System.Collections.Generic.Dictionary<int, string>();
        public static Dictionary<int, string> RolesDictionary = new System.Collections.Generic.Dictionary<int, string>();
        public static List<ExcelValidationResult> validationRes = new List<ExcelValidationResult>();
        public static DataTable dtsUsers = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Page.Form.Attributes.Add("enctype", "multipart/form-data");
            if (!Page.IsPostBack)
            {
                ValidateSession.ValidateUserSession(this.Page, HttpContext.Current.Request.Url.LocalPath);
            }
        }

        protected void linDownload_Click(object sender, EventArgs e)
        {
            string path = UsersBulkManager.createUsersExcelTemplate(Server.MapPath("/ExcelUploads/UsersTemplate/"), "UserTemplate");
            FileInfo file = new FileInfo(Server.MapPath("/ExcelUploads/UsersTemplate/UserTemplate.xlsx"));
            if (file.Exists)
            {
                Response.Clear();
                Response.ClearHeaders();
                Response.ClearContent();
                Response.AddHeader("content-disposition", "attachment; filename=" + file.Name);
                Response.AddHeader("Content-Type", "application/Excel");
                Response.ContentType = "application/vnd.xls";
                Response.AddHeader("Content-Length", file.Length.ToString());
                Response.WriteFile(file.FullName);
                Response.End();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Error", "<script>showpoperror('" + "Sorry, This file does not exist.! " + "')</script>", false);
            }
        }

        protected void lnkReset_Click(object sender, EventArgs e)
        {
            Reset();
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            //lnkImport.Visible = false;
            btnShowInvalidRecords.Visible = false;
            if (FileUploadLink.HasFile && Path.GetExtension(FileUploadLink.PostedFile.FileName) == ".xlsx")
            {
                string fileName = FileUploadLink.FileName;
                string path = Server.MapPath("~/ExcelUploads/Users/");
                FileUploadLink.SaveAs(Path.Combine(path, "Users" + DateTime.Now.ToString("ddMMyyyyhhmm") + ".xlsx"));
                FileUploadPath = Path.Combine(path, "Users" + DateTime.Now.ToString("ddMMyyyyhhmm") + ".xlsx");
                preview();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpoperror('" + "Please select a valid file " + "')</script>", false);
            }
        }
        protected void preview()
        {
            if (FileUploadPath != "")
            {
                string excelPath = FileUploadPath;
                if (UsersBulkManager.isValidSheet(FileUploadPath))
                {
                    dtsUsers.Clear();
                    Stream stream = ExcelImportManager.GetStreamFromFile(excelPath);
                     dtsUsers = ExcelImportManager.GetDTFromExcelFile(stream);
                    if (dtsUsers.Rows.Count > 0)
                    {
                        RepeaterUploadedUsers.Visible = true;
                        RepeaterUploadedUsers.DataSource = dtsUsers;
                        RepeaterUploadedUsers.DataBind();
                        // lnkImport.Visible = true;
                        validationRes.Clear();
                        validationRes=  UsersBulkManager.ValidateUsersData(dtsUsers);
                        if (validationRes.Count > 0)//the file has invalid or duplicate data
                        {
                            lblInvalid.Visible = true;
                            if (validationRes.Select(x => x.RowNo).Distinct().Count() == 1)
                            {
                                if (validationRes[0].RowNo ==0 && validationRes[0].Reason.ToLower().Contains("email"))
                                {
                                    lblInvalid.Text =  "This sheet contains duplicate emails";
                                }
                                else if (validationRes[0].RowNo == 0 && validationRes[0].Reason.ToLower().Contains("employee"))
                                {
                                    lblInvalid.Text = "This sheet contains duplicate employee no";
                                }
                            }
                            else
                            {
                                lblInvalid.Text = validationRes.Select(x=>x.RowNo ).Distinct().Count().ToString() +   " Invalid records!";
                            }
                           
                            btnShowInvalidRecords.Visible = true;
                        }
                        else //Valid sheet, prepare for insert
                        {
                            
                            FillDictionaries();
                            lnkImport.Visible = true;
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Error", "<script>showpoperror('" + "The uploaded sheet has no data! " + "')</script>", false);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Error", "<script>showpoperror('" + "The uploaded sheet is invalid  or has invalid columns! " + "')</script>", false);
                }

            }
        }
        protected void RepeaterUploadedRooms_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
            {
                HtmlTableRow tr = (HtmlTableRow)e.Item.FindControl("tdValue2");
                Label email = (Label)e.Item.FindControl("lblEmail");
                Label fullname = (Label)e.Item.FindControl("lblFName");
                Label empNo = (Label)e.Item.FindControl("lblEmployeeNo");
                Label lblPosition = (Label)e.Item.FindControl("lblPosition");
                Label lblSecurityGroup = (Label)e.Item.FindControl("lblSecurityGroup");

                bool isValid =UserManager.IsValidEmailFormat(email.Text);
                if (isValid == false || string.IsNullOrWhiteSpace(fullname.Text) || string.IsNullOrWhiteSpace(empNo.Text) || string.IsNullOrWhiteSpace(lblPosition.Text) || string.IsNullOrWhiteSpace(lblSecurityGroup.Text))
                {
                    tr.Attributes.Add("style", "background-color:Red;");
                }    
            }
        }

        protected void btnShowInvalidRecords_Click(object sender, EventArgs e)
        {
            try
            {
            
                if (validationRes.Count > 0)
                {
                    MemoryStream ms = new MemoryStream();
                    TextWriter tw = new StreamWriter(ms);
                    tw.WriteLine("The following rows contains Invalid Data.");
                    foreach (var item in validationRes)
                    {
                        tw.WriteLine( $"Invalid Data at Row No. :  {item.RowNo}, Reason: {item.Reason} ");
                    }
                    tw.Flush();
                    this.Context.ApplicationInstance.CompleteRequest();
                    byte[] bytes = ms.ToArray();
                    ms.Close();
                    Response.Clear();
                    Response.ContentType = "application/force-download";
                    Response.AddHeader("content-disposition", "attachment;    filename=InvalidRecords.txt");
                    Response.BinaryWrite(bytes);
                    Response.End();
                }
            }
            catch (Exception ex)
            {
                if (ex.HelpLink == null)
                {
                    ex.HelpLink = HttpContext.Current.Request.Url.LocalPath;
                }
                ExceptionsManager.AddExceptionDetails(ex, new Page());
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Error", "<script>showpoperror('" + "Unexpected Error! " + ex.Message + "')</script>", false);
            }
        }

        protected void lnkImport_Click(object sender, EventArgs e)
        {
            try
            {
                string result = UsersBulkManager.InsertUsersBulk(dtsUsers, hrRolesDictionary, RolesDictionary);
                if (result.ToLower() == "success")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "success", "<script>showpopsuccess('" + "Data Imported Successfully! " + "')</script>", false);
                    Reset();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Error", "<script>showpoperror('" + "Problem uploading data! " + result + "')</script>", false);
                }
            }
            catch (Exception ex)
            {
                if (ex.HelpLink == null)
                {
                    ex.HelpLink = HttpContext.Current.Request.Url.LocalPath;
                }
                ExceptionsManager.AddExceptionDetails(ex, new Page());
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Error", "<script>showpoperror('" + "Problem uploading data! " + ex.HResult + "')</script>", false);
            }
        }
        protected void Reset()
        {
            lnkImport.Visible = false;
            FileUploadPath = "";
            RepeaterUploadedUsers.Visible = false;
            lblInvalid.Visible = false;
            lblError.Visible = false;
            btnShowInvalidRecords.Visible = false;
        }
        public static void FillDictionaries()
        {
            using (var db = new ePMEntities())
            {
                List<u_HRRoles> hrRolesList = db.u_HRRoles.ToList();
                hrRolesDictionary = hrRolesList.ToDictionary(x => x.RoleID, x => x.Name + "_" + x.Department);
                List<LMS_Roles> secRoleList = db.LMS_Roles.ToList();
                RolesDictionary = secRoleList.ToDictionary(x => x.RoleId, x => x.RoleName);
            }
        }
    }
}