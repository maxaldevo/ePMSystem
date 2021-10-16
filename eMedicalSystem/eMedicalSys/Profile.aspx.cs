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
            lblFName.Text = user.FName; //full name
            image1.ImageUrl = File.Exists(HttpContext.Current.Server.MapPath(user.ProfilePicPath))
                         ? user.ProfilePicPath : defaultImagePath;
            lblEmail.Text = user.Email;
            lblAddressDetails.Text = user.Addr1;
            lblPinCode.Text = user.POPostcode;
            lblCivilId.Text = user.CivilID;
            lblMobile.Text = user.Mobile;
            lblPhoneNo.Text = user.PhoneNo;
        }
    }
}