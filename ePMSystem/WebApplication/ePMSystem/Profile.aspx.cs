using ePM_Dal.Logic;
using System;
using System.IO;
using System.Web;
using System.Web.UI;

namespace WebApplication1
{
    public partial class Profile : System.Web.UI.Page
    {
       // public static int userId = 0;
        public string defaultImagePath = "images/avatar1.png";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["UserId"] == null)
                {
                    Response.Redirect("~/Login/Login.aspx", false);
                }
                else
                {
                    if (int.Parse(Session["UserId"].ToString()) != 0)
                    {
                        //userId = int.Parse(Session["UserId"].ToString());
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
            var user = PersonnelManager.GetSingleByUserId(int.Parse(Session["UserId"].ToString()));
            if (user.ID <= 0) return;
           // lblUserName.Text = user.FName;//full name
            lblFName.Text = user.FName;//full name
            //lblTitle.Text = user.Position;

            image1.ImageUrl = File.Exists(HttpContext.Current.Server.MapPath(user.ProfilePicPath))
                         ? user.ProfilePicPath : defaultImagePath;
            lblempNo.Text = user.EmployeeNo.ToString();
            //lblJoiningDate.Text = user.StartDate.ToString();
            //lblGrade.Text = user.Grade;
            //lblProject.Text = user.Project;
            //if (user.Department.Contains("->") && user.Department.Contains("Area"))
            //{
            //    lblarea.Text = user.Department.Substring(user.Department.IndexOf("->") + 3, 6);
            //}
            //else
            //{
            //    lblarea.Text = user.Department;
            //}
            //if (user.Department.IndexOf("->") != user.Department.LastIndexOf("->"))
            //{
            //    //   lblSection.Text = user.Department.Substring(user.Department.LastIndexOf("->") + 3, user.Department.Length - user.Department.LastIndexOf("->") + 4);
            //    int last = user.Department.LastIndexOf("->") + 3;
            //    lblSection.Text = user.Department.Substring(user.Department.LastIndexOf("->") + 3, user.Department.Length -  (last));
            //}
            //else
            //{
            //    lblSection.Text = user.Department;
            //}
            lblEmail.Text = user.Email;
            //lblMobile.Text = user.MobileWork;
            lblAddressDetails.Text = user.Addr1;
            lblPinCode.Text = user.POPostcode;
            lblExperience.Text = user.Experience;
            //lblGroup.Text = user.Department;
            
        }
    }
}