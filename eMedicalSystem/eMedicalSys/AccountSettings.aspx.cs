using ePM_Dal.Logic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class AccountSettings : System.Web.UI.Page
    {
        public static string defaultImagePath = "images/avatar1.png";
        public static  string profileImage = "";
        public static readonly List<string> ImageExtensions = new List<string> { ".JPG", ".JPE", ".BMP", ".GIF", ".PNG" };
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Form.Attributes.Add("enctype", "multipart/form-data");
            if (!Page.IsPostBack)
            {
                UploadDiv.Visible = false;
                if (Session["UserId"] == null)
                {
                    Response.Redirect("~/Login/Login.aspx", false);
                }
                else
                {
                    if (int.Parse(Session["UserId"].ToString()) != 0)
                    {
                        var userObject= UserManager.getSingleUser(int.Parse(Session["UserId"].ToString()));
                        Session["PersonnelId"] = (int)userObject.PersonnelID;
                        this.BindUser();
                    }
                    else
                    {
                        Response.Redirect("~/Login/Login.aspx", false);
                    }
                }

            }

        }
        private void BindUser()
        {
            var user = UserProfile.GetUserById(int.Parse(Session["UserId"].ToString()));
           
            if (user.PersonnelID <= 0) return;
            // lblUserName.Text = user.FName;//full name

                defaultImagePath = File.Exists(HttpContext.Current.Server.MapPath(user.ProfilePicPath))
                         ? user.ProfilePicPath : defaultImagePath;

            image1.ImageUrl = defaultImagePath;
            lblFName.Text = user.FName;
            lblEmail.Text = user.Email;
            lblCivilID.Text = user.CivilID;
            lblMobile.Text = user.Mobile;
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            try
            {
                FileInfo fileInfo = new FileInfo(Server.MapPath(defaultImagePath));            
                Response.Clear();
                Response.AddHeader("Content-Disposition", "attachment;filename=" + fileInfo.Name);
                Response.AddHeader("Content-Length", fileInfo.Length.ToString());
                Response.ContentType = "application/octet-stream";
                Response.Flush();
                Response.WriteFile(fileInfo.FullName);
                Response.End();
            }
            catch (Exception ex)
            {
                if (ex.HelpLink == null)
                {
                    ex.HelpLink = HttpContext.Current.Request.Url.LocalPath;
                }
                ExceptionsManager.AddExceptionDetails(ex, new Page());
                ScriptManager.RegisterStartupScript(this, typeof(Page), "unexpected error", "<script>showpoperror('" + "Unexpected error, Please contact your Admin!" + "')</script>", false);
            }
            
        }
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            UploadDiv.Visible = true;
        }
        //upload image profile
        protected void linbuttonUpload_Click(object sender, EventArgs e)
        {
          //  Page.Validate("A");
            if (Page.IsValid && Session["UserId"] == null)
            {
                try
                {
                    string dbImagePath = "";
                    string fileExt = System.IO.Path.GetExtension(FileUpload1.FileName).ToUpper();
                    if (FileUpload1.HasFile && FileUpload1.PostedFile != null)
                    {
                        if (!ImageExtensions.Contains(Path.GetExtension(fileExt).ToUpperInvariant()))
                        {
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpopwarning('" + "Please select a valid image!" + "')</script>", false);
                            return;
                        }
                        else
                        {
                            string imagepath = Server.MapPath("~/ProfilePics/") + Session["UserId"].ToString() + fileExt;
                            dbImagePath = "ProfilePics/" + Session["UserId"].ToString() + fileExt;
                            FileUpload1.PostedFile.SaveAs(imagepath);
                            // If same name of file present then delete that file first
                            if (File.Exists(imagepath))
                            {
                                File.Delete(imagepath);
                            }
                            // Save file
                            FileUpload1.PostedFile.SaveAs(imagepath);
                            //UPDATE profile pic path HERE
                            UserManager.UpdateProfilePic(int.Parse(Session["UserId"].ToString()), dbImagePath);
                            //Bind new image
                            bindImage();
                            //hide upload div
                            UploadDiv.Visible = false;
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "Success", "<script>showpopsuccess('" + "File uploaded successfully!" + "')</script>", false);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpopwarning('" + "Please select a file!" + "')</script>", false);
                    }
                  
                }
                catch (Exception ex)
                {
                    if (ex.HelpLink == null)
                    {
                        ex.HelpLink = HttpContext.Current.Request.Url.LocalPath;
                    }
                    ExceptionsManager.AddExceptionDetails(ex, new Page());
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "unexpected error", "<script>showpoperror('" + "Unexpected error, Please contact your Admin!" + "')</script>", false);
                }
            }
        }
        private void bindImage()
        {
            if (Session["UserId"] == null)
            {
                var user = PersonnelManager.GetSingleByUserId(int.Parse(Session["UserId"].ToString()));
                image1.ImageUrl = "";

                defaultImagePath = File.Exists(HttpContext.Current.Server.MapPath(user.ProfilePicPath))
                             ? user.ProfilePicPath : defaultImagePath;

                image1.ImageUrl = defaultImagePath; 
            }
            else
            {
                Response.Redirect("~/Login/Login.aspx", false);
            }
        }
        protected void linkChangePassword_Click(object sender, EventArgs e)
        {
            Panel1.Visible = true;
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
        }
        //change password
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid && Session["UserId"] != null)
            {
                //upadate user password
                try
                {
                    if (UserManager.ChangePassword(int.Parse(Session["UserId"].ToString()), txtPassword.Text))
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Success", "<script>showpopsuccess('" + "Password updated successfully!" + "')</script>", false);
                        Panel1.Visible = false;
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "unexpected error", "<script>showpoperror('" + "Unexpected error, Please contact your Admin!" + "')</script>", false);
                    }
                }
                catch (Exception)
                {

                    ScriptManager.RegisterStartupScript(this, typeof(Page), "unexpected error", "<script>showpoperror('" + "Unexpected error, Please contact your Admin!" + "')</script>", false);
                }
            }
            else
            {
                Response.Redirect("~/Login/Login.aspx", false);
            }
        }
    }
}