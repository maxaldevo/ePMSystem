using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
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
    public partial class BookInSchedule : System.Web.UI.Page
    {
        public List<vPersonnel> usersList = new List<vPersonnel>();
        public static int _TimeinHrs, _userID, _roleId, _clinicId, _DaysNumber, _selectedRoomId, _selectedPatientId, _selectedServiceId, _selectedtimeId = 0;
        public static string _selectedtime, _selectedtimebegin, _selectedtimeEnd = "";
        public static DateTime _selectedDate = new DateTime();
        //DateTime _selecteddate;
        //string day_date, month_date, year_date = "";
        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (gvUsers.Rows.Count > 0)
            {
                gvUsers.UseAccessibleHeader = true;
                gvUsers.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gvBookingTimes_Roomone.Rows.Count > 0)
            {
                gvBookingTimes_Roomone.UseAccessibleHeader = true;
                gvBookingTimes_Roomone.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gvBookingTimes_RoomTwo.Rows.Count > 0)
            {
                gvBookingTimes_RoomTwo.UseAccessibleHeader = true;
                gvBookingTimes_RoomTwo.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gvBookingTimes_RoomThree.Rows.Count > 0)
            {
                gvBookingTimes_RoomThree.UseAccessibleHeader = true;
                gvBookingTimes_RoomThree.HeaderRow.TableSection = TableRowSection.TableHeader;
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

                BindGrid(_clinicId, _userID, Convert.ToDateTime(_selectedDate));
                bindRooms(_userID);
                bindServices(_selectedRoomId);
                bindtimebegins(_userID, _selectedRoomId, Convert.ToDateTime(_selectedDate));
                bindtimeEnd(_userID, _selectedRoomId, Convert.ToDateTime(_selectedtimebegin), Convert.ToDateTime(_selectedDate));
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
        private void bindtimebegins(int usrId, int roomId, DateTime selectDate)
        {
            DropDownTimebegin.DataSource = null;
            DropDownTimebegin.ClearSelection();
            List<vBookingTime> Timesbegin = BookingManager.GetBookingTimingListbyroomid(usrId, roomId, selectDate);
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
        private void bindtimeEnd(int usrId, int roomId, DateTime timebagin, DateTime selectDate)
        {
            DropDownTimeEnd.DataSource = null;
            DropDownTimeEnd.ClearSelection();
            List<vBookingTime> Timesbegin = BookingManager.GetBookingTimingListbyroomid(usrId, roomId, timebagin, selectDate);
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
        private void BindGrid(int clinicId, int usrId, DateTime selectedDate)
        {
            List<eMedical_User> Patients = UserManager.getPatientsList(clinicId, 7);
            try
            {
                gvUsers.DataSource = Patients;
                gvUsers.DataBind();
                gvBookingTimes_Roomone.DataSource = BookingManager.GetBookingTimesList(selectedDate, 4);
                gvBookingTimes_Roomone.DataBind();
                gvBookingTimes_RoomTwo.DataSource = BookingManager.GetBookingTimesList(selectedDate, 5);
                gvBookingTimes_RoomTwo.DataBind();
                gvBookingTimes_RoomThree.DataSource = BookingManager.GetBookingTimesList(selectedDate, 6);
                gvBookingTimes_RoomThree.DataBind();
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
            //bindtimebegins(_userID, _selectedRoomId, Convert.ToDateTime(_selectedDate));
            //bindtimeEnd(_userID, _selectedRoomId, Convert.ToDateTime(_selectedtimebegin), Convert.ToDateTime(_selectedDate));
        }
        protected void DropDownService_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedServiceId = int.Parse(DropDownService.SelectedItem.Value);
            List<vBookingTime> Timesbegin = BookingManager.GetBookingTimingListbyroomid(_userID, _selectedRoomId, Convert.ToDateTime(_selectedDate));
            for (int j = 0; j < Timesbegin.Count - 1; j++)
            {
                int serviceDuration = BookingManager.GetServiceDuration(_selectedServiceId);
                int theActualCounter = serviceDuration / 15;
                int countSessions = 0;

                for (DateTime i = Convert.ToDateTime(Timesbegin.ToList()[j].BookingDate_TimeBegin); i < Convert.ToDateTime(Timesbegin.ToList()[j].BookingDate_TimeBegin).AddMinutes(serviceDuration); i = i.AddMinutes(15))
                {
                    bool isBooked = BookingManager.SessionIsBooked(_selectedServiceId, _selectedRoomId, Convert.ToDateTime(Timesbegin.ToList()[j].BookingDate_TimeBegin));
                    if (isBooked)
                    {
                        countSessions++;
                    }
                }
                if (theActualCounter == countSessions)
                {

                }
                serviceDuration = 0;
                theActualCounter = 0;
                countSessions = 0;
            }
        }

        //protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        //{
        //    Color NormColor = new Color();
        //    NormColor = e.Cell.BackColor;
        //    if (e.Day.IsSelected == true)
        //    {
        //        _selectedDate.Add(e.Day.Date);
        //        e.Cell.BackColor = Color.Orange;
        //    }
        //    Session["SelectedDate"] = _selectedDate;
        //}

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            //if (Session["SelectedDates"] != null)
            //{
            //    List<DateTime> newList = (List<DateTime>)Session["SelectedDates"];
            //    foreach (DateTime dt in newList)
            //    {
            //        Calendar1.SelectedDates.Add(dt);
            //        //TextBox1.Text = Calendar1.SelectedDate.ToShortDateString();
            //        //TextBox1.Text.Replace("\r\n", "<br />");
            //    }
            //    _selectedDate.Clear();
            //}
            _selectedDate = Calendar1.SelectedDate;
            BindGrid(_clinicId, _userID, Convert.ToDateTime(_selectedDate));
            //bindtimebegins(_userID, _selectedRoomId, Convert.ToDateTime(_selectedDate));
            //bindtimeEnd(_userID, _selectedRoomId, Convert.ToDateTime(_selectedtimebegin), Convert.ToDateTime(_selectedDate));

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
            bindtimeEnd(_userID, _selectedRoomId, Convert.ToDateTime(_selectedtimebegin), Convert.ToDateTime(_selectedDate));
        }
        protected void DropDownTimeEnd_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedtimeEnd = DropDownTimeEnd.SelectedItem.Text;
        }
        protected void gvBookingTimes_RoomOne_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblISBOOKED = e.Row.FindControl("lblIsBooked") as Label;
                if (lblISBOOKED.Text == "Busy")
                {
                    e.Row.Cells[2].BackColor = Color.Red;
                    e.Row.Cells[2].ForeColor = Color.White;
                    //e.Row.Cells[3].Enabled = false;
                    //e.Row.Cells[3].Visible = false;
                }
                else
                {
                    e.Row.Cells[2].BackColor = Color.Green;
                    e.Row.Cells[2].ForeColor = Color.White;
                }
            }
        }
        protected void gvBookingTimes_RoomTwo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblISBOOKED = e.Row.FindControl("lblIsBooked") as Label;
                if (lblISBOOKED.Text == "Busy")
                {
                    e.Row.Cells[2].BackColor = Color.Red;
                    e.Row.Cells[2].ForeColor = Color.White;
                    //e.Row.Cells[3].Enabled = false;
                    //e.Row.Cells[3].Visible = false;
                }
                else
                {
                    e.Row.Cells[2].BackColor = Color.Green;
                    e.Row.Cells[2].ForeColor = Color.White;
                }
            }
        }
        protected void gvBookingTimes_RoomThree_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblISBOOKED = e.Row.FindControl("lblIsBooked") as Label;
                if (lblISBOOKED.Text == "Busy")
                {
                    e.Row.Cells[2].BackColor = Color.Red;
                    e.Row.Cells[2].ForeColor = Color.White;
                    //e.Row.Cells[3].Enabled = false;
                    //e.Row.Cells[3].Visible = false;
                }
                else
                {
                    e.Row.Cells[2].BackColor = Color.Green;
                    e.Row.Cells[2].ForeColor = Color.White;
                }
            }
        }
    }
}