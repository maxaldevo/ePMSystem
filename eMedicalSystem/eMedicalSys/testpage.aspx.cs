using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.Demos;
using ePM.Dal;
using ePM.Dal.Logic;
using ePM.Dal.ViewModels;
using ePM_Dal.Logic;
using ePM_Dal.Utilities;

namespace eMedicalSys
{
    public partial class testpage : System.Web.UI.Page
    {
        public List<vPersonnel> usersList = new List<vPersonnel>();
        public static int _TimeinHrs, _userID, _roleId, _clinicId, _DaysNumber, _selectedRoomId, _selectedPatientId, _selectedServiceId, _selectedtimeId = 0;
        public static string _selectedtime, _selectedtimebegin, _selectedtimeEnd = "";
        //DateTime _selecteddate;
        //string day_date, month_date, year_date = "";
        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (gvUsers.Rows.Count > 0)
            {
                gvUsers.UseAccessibleHeader = true;
                gvUsers.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                #region Page Validation

                int usrId, RoleId, clinicID = 0;
                if (Session["UserId"] == null)
                {
                    Response.Redirect("~/Login/Login.aspx", true);
                }
                else
                {
                    if (int.Parse(Session["UserId"].ToString()) != 0)
                    {
                        usrId = int.Parse(Session["UserId"].ToString());
                        RoleId = int.Parse(Session["RoleId"].ToString());
                        clinicID = int.Parse(Session["ClinicId"].ToString());

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
                _userID = int.Parse(Session["UserId"].ToString());
                _roleId = int.Parse(Session["RoleId"].ToString());
                _clinicId = int.Parse(Session["ClinicId"].ToString());

                BindGrid(_clinicId);
                bindRooms(_userID);
                bindServices(_selectedRoomId);
                bindtimebegins(_userID, _selectedRoomId);
                bindtimeEnd(_userID, _selectedRoomId, Convert.ToDateTime(_selectedtimebegin));
                //binddates(_userID, _selectedRoomId);
                //bindPatients(_clinicId);
            }
        }
        //private void binddates(int usrId, int roomId)
        //{
        //    DropDowndate.DataSource = null;
        //    DropDowndate.ClearSelection();
        //    List<BookingDates> dates = BookingManager.GetBookingTimingList_distinct_Nottoday(usrId, roomId);
        //    DropDowndate.DataSource = dates;
        //    DropDowndate.DataValueField = "RoomID";
        //    DropDowndate.DataTextField = "bookingDate";
        //    DropDowndate.DataTextFormatString = "{0:dd-MM-yyyy}";
        //    DropDowndate.DataBind();
        //    if (DropDowndate.Items.Count > 0)
        //    {
        //        DropDowndate.Items[0].Selected = true;
        //        _selecteddate = Convert.ToDateTime(DropDowndate.SelectedItem.Text);
        //        day_date = _selecteddate.Day.ToString();
        //        month_date = _selecteddate.Month.ToString();
        //        year_date = _selecteddate.Year.ToString();
        //    }
        //}
        private void bindtimebegins(int usrId, int roomId)
        {
            DropDownTimebegin.DataSource = null;
            DropDownTimebegin.ClearSelection();
            List<vBookingTime> Timesbegin = BookingManager.GetBookingTimingListbyroomid(usrId, roomId, Convert.ToDateTime("26-10-2021"));
            DropDownTimebegin.DataSource = Timesbegin;
            DropDownTimebegin.DataValueField = "ID";
            DropDownTimebegin.DataTextField = "BookingDate_TimeBegin";
            DropDownTimebegin.DataBind();
            if (DropDownTimebegin.Items.Count > 0)
            {
                DropDownTimebegin.Items[0].Selected = true;
                _selectedtimebegin = DropDownTimebegin.SelectedItem.Text;
            }
            //for (int i = 0; i < DropDownTimebegin.Items.Count - 1; i++)
            //{
            //    TimeSpan spWorkMin = TimeSpan.FromMinutes(int.Parse(DropDownTimebegin.Items[i].Text));
            //    DropDownTimebegin.Items[i].Text = string.Format("{0:00}:{1:00}", (int)spWorkMin.TotalHours, spWorkMin.Minutes);
            //}

        }
        private void bindtimeEnd(int usrId, int roomId, DateTime timebagin)
        {
            DropDownTimeEnd.DataSource = null;
            DropDownTimeEnd.ClearSelection();
            List<vBookingTime> Timesbegin = BookingManager.GetBookingTimingListbyroomid(usrId, roomId, timebagin);
            DropDownTimeEnd.DataSource = Timesbegin;
            DropDownTimeEnd.DataValueField = "ID";
            DropDownTimeEnd.DataTextField = "BookingDate_TimeEnd";
            DropDownTimeEnd.DataBind();
            if (DropDownTimeEnd.Items.Count > 0)
            {
                DropDownTimeEnd.Items[0].Selected = true;
                _selectedtimeEnd = DropDownTimeEnd.SelectedItem.Text;
            }
        }
        private void bindRooms(int usrId)
        {

            DropDownRoom.DataSource = null;
            DropDownRoom.ClearSelection();
            List<eMedical_Room> Rooms = ServiceManager.GetRoomsList(usrId);
            DropDownRoom.DataSource = Rooms;
            DropDownRoom.DataValueField = "ID";
            DropDownRoom.DataTextField = "RoomName";
            DropDownRoom.DataBind();
            //DropDownHRRoles.Items.Insert(0, new ListItem("All", "0"));
            DropDownRoom.Items[0].Selected = true;
            _selectedRoomId = int.Parse(DropDownRoom.SelectedItem.Value);
        }
        private void bindServices(int roomID)
        {

            DropDownService.DataSource = null;
            DropDownService.ClearSelection();
            List<vService> Services = ServiceManager.GetservicesList(roomID);
            DropDownService.DataSource = Services;
            DropDownService.DataValueField = "SID";
            DropDownService.DataTextField = "ServiceName";
            DropDownService.DataBind();
            //DropDownHRRoles.Items.Insert(0, new ListItem("All", "0"));
            DropDownService.Items[0].Selected = true;
            _selectedServiceId = int.Parse(DropDownService.SelectedItem.Value);
        }
        private void BindGrid(int clinicId)
        {
            List<eMedical_User> Patients = UserManager.getPatientsList(clinicId, 7);
            try
            {
                gvUsers.DataSource = Patients;
                gvUsers.DataBind();
            }
            catch (Exception ex)
            {
                ExceptionsManager.AddException(ex);
                SweetAlert.showToast(this.Page, SweetAlert.ToastType.Error, ex.Message, "Unexpected error", SweetAlert.ToasterPostion.TopCenter, false);
            }
        }
        protected void btnAddNewRecord_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AddNewPatient.aspx", true);
        }
        protected void btnAppointmentCheckIn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/CheckinAppointment.aspx", true);
        }
        protected void btnBookAppointment_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (_selectedPatientId > 0)
                {
                    try
                    {
                        string result = BookingManager.AddNewAppointment(Convert.ToDateTime(_selectedtimebegin), Convert.ToDateTime(_selectedtimeEnd), _selectedPatientId, _selectedRoomId, _selectedServiceId);
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
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "Success", "<script>showpopsuccess('" + "Clinic added successfully!" + "')</script>", false);
                        }
                    }
                    catch (Exception ex)
                    {

                        ScriptManager.RegisterStartupScript(this, typeof(Page), "unexpected error", "<script>showpoperror('" + "Unexpected error, Please contact your Admin!" + ex.Message + "')</script>", false);
                    }
                }
                else
                {
                    lblResult.Visible = true;
                    lblResult.ForeColor = System.Drawing.Color.Red;
                    lblResult.Text = "Please choose The Patient.";
                }
            }
        }
        private void clearControls()
        {
            
        }
        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = gvUsers.Rows[e.NewEditIndex];
            Session["PatientId"] = Convert.ToInt32(gvUsers.DataKeys[e.NewEditIndex].Values[0]);
            _selectedPatientId = Convert.ToInt32(gvUsers.DataKeys[e.NewEditIndex].Values[0]);
        }
        protected void DropDownRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedRoomId = int.Parse(DropDownRoom.SelectedItem.Value);
            bindServices(_selectedRoomId);
            bindtimebegins(_userID, _selectedRoomId);
            bindtimeEnd(_userID, _selectedRoomId, Convert.ToDateTime(_selectedtimebegin));
        }
        protected void DropDownService_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedServiceId = int.Parse(DropDownService.SelectedItem.Value);
        }
        //protected void DropDownTime_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    _selectedtimeId = int.Parse(DropDownTime.SelectedItem.Value);
        //}
        //protected void DropDowndate_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    _selecteddate = Convert.ToDateTime(DropDowndate.SelectedItem.Text);
        //    day_date = _selecteddate.Day.ToString();
        //    month_date = _selecteddate.Month.ToString();
        //    year_date = _selecteddate.Year.ToString();
        //}
        protected void DropDownTimebegin_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedtimebegin = DropDownTimebegin.SelectedItem.Text;
            bindtimeEnd(_userID, _selectedRoomId, Convert.ToDateTime(_selectedtimebegin));
        }
        protected void DropDownTimeEnd_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedtimeEnd = DropDownTimeEnd.SelectedItem.Text;
        }
    }
}