using ePM_Dal.Enums;
using ePM_Dal.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Login
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //this line to enable unobstrusive  validation
           // this.UnobtrusiveValidationMode = System.Web.UI.UnobtrusiveValidationMode.None;
            this.Form.DefaultButton = this.btnLogin.UniqueID;
            if (!Page.IsPostBack)
            {
                Session["UserId"] = 0;
                Session["RoleId"] = 0;
                Session["ClinicId"] = 0;
                Session["HospitalID"] = 0;
            }
        }

        protected void btnLogin_Click1(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
               // var user = UserManager.TempValidateEmail(txtEmail.Text, txtPassword.Text);
                var user = UserManager.validateUserByEmailReal(txtEmail.Text, txtPassword.Text);
                if (user != null)
                {
                    Session["UserId"] = user.ID.ToString();
                    Session["RoleId"] = user.RoleId.ToString();
                    Session["ClinicId"] = user.ClinicID.ToString();
                    Session["HospitalID"] = user.HospitalID.ToString();
                    Response.Redirect("~/Default.aspx", true);
                }
                else
                {
                    Session["UserId"] = 0;
                    txtPassword.Text = "";
                    txtEmail.Text = "";
                    lbl_invalideuser.Visible = true;
                }
            }
        }
    }
}