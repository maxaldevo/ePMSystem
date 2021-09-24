using ePM.Dal;
using ePM.Dal.Logic;
using ePM_Dal.Logic;
using ePM_Dal.Utilities;
using ePM_Dal.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class BookAppointment : System.Web.UI.Page
    {
        public static int _userID, _DaysNumber, _selectedServiceId = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                #region Page Validation

                int RoleId = 0;
                if (Session["UserId"] == null)
                {
                    Response.Redirect("~/Login/Login.aspx", true);
                }
                else
                {
                    if (int.Parse(Session["UserId"].ToString()) != 0)
                    {
                        _userID = int.Parse(Session["UserId"].ToString());
                        RoleId = int.Parse(Session["RoleId"].ToString());

                        string currentPage = HttpContext.Current.Request.Url.LocalPath;
                        if (RoleId != 1)
                        {
                            if (!SecurityManager.isPageInRole(currentPage, RoleId))
                            {
                                Response.Redirect("~/Unauthorized.aspx", true);
                            }
                        }
                    }
                    else
                    {
                        Response.Redirect("~/Login/Login.aspx", true);
                    }
                }
                #endregion Page Validation
                bindServices(); 
            }
        }
        protected void btnShowData_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    //Validate user name and emp No

                    _DaysNumber = int.Parse(txtDaysNumber.Text);

                    //string result = BookingManager.CreateSchedule(_DaysNumber, Convert.ToDateTime(txt_date.Text), _selectedServiceId, _userID);
                    string result = "";
                    if (result != "inserted")
                    {
                        lblResult.Visible = true;
                        lblResult.ForeColor = System.Drawing.Color.Red;
                        lblResult.Text = result;
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Error", "<script>showpoperror('" + result + " Please contact your Admin!" + "')</script>", false);
                    }
                    else
                    {
                        lblResult.Visible = true;
                        lblResult.ForeColor = System.Drawing.Color.Green;
                        lblResult.Text = result;
                        clearControls();
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Success", "<script>showpopsuccess('" + "User added successfully!" + "')</script>", false);
                        //Re-Bind the user grid based on the User's role.
                        //if (int.Parse(Session["RoleId"].ToString()) == 1) BindProductsGrid(0, 0); else BindProductsGrid(int.Parse(Session["ClinicId"].ToString()), int.Parse(Session["UserId"].ToString()));
                    }


                }
                catch (Exception ex)
                {

                    ScriptManager.RegisterStartupScript(this, typeof(Page), "unexpected error", "<script>showpoperror('" + "Unexpected error, Please contact your Admin!" + ex.Message + "')</script>", false);
                }

            }

        }
        private void clearControls()
        {
            txtDaysNumber.Text = "";
            // lblResult.Visible = false;
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            txt_date.Text = Calendar1.SelectedDate.ToShortDateString();
        }

        private void bindServices()
        {
            DropDownService.DataSource = null;
            DropDownService.ClearSelection();
            List<vService> Services = ServiceManager.GetservicesList();
            DropDownService.DataSource = Services;
            DropDownService.DataValueField = "SID";
            DropDownService.DataTextField = "ServiceName";
            DropDownService.DataBind();
            //DropDownHRRoles.Items.Insert(0, new ListItem("All", "0"));
            DropDownService.Items[0].Selected = true;
            _selectedServiceId = int.Parse(DropDownService.SelectedItem.Value);
        }

        protected void DropDownService_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedServiceId = int.Parse(DropDownService.SelectedItem.Value);
        }


    }
}