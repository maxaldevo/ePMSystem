using ePM.Dal;
using ePM.Dal.Logic;
using ePM_Dal.Logic;
using ePM_Dal.Utilities;
using ePM_Dal.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class DoctorFollowUp : System.Web.UI.Page
    {
        public static DateTime _selectedDate = DateTime.Now;
        public List<vBookingTime> bookingTimesList = new List<vBookingTime>();
        public static int _userID, _DaysNumber, _selectedRoomId = 0;
        public static List<DateTime> selectedDateslist = new List<DateTime>();
        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (gvAppointments.Rows.Count > 0)
            {
                gvAppointments.UseAccessibleHeader = true;
                gvAppointments.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
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
                this.BindGrid();
            }
        }
        private void BindGrid()
        {
            try
            {
                    gvAppointments.DataSource = BookingManager.GetDoctorAppointmentList(6); // doctor room id = 6 
                    gvAppointments.DataBind();

            }
            catch (Exception ex)
            {
                ExceptionsManager.AddException(ex);
                SweetAlert.showToast(this.Page, SweetAlert.ToastType.Error, ex.Message, "Unexpected error", SweetAlert.ToasterPostion.TopCenter, false);
            }
        }
        private void clearControls()
        {
            //txtDaysNumber.Text = "";
            // lblResult.Visible = false;
        }
        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = gvAppointments.Rows[e.NewEditIndex];
            Session["AppointmentId"] = Convert.ToInt32(gvAppointments.DataKeys[e.NewEditIndex].Values[0]);
            //_selectedPatientId = Convert.ToInt32(gvAppointments.DataKeys[e.NewEditIndex].Values[0]);
        }
    }
}