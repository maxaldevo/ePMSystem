using DevExpress.Web;
using ePM.Dal;
using ePM.Dal.Logic;
using ePM.Dal.ViewModels;
using ePM_Dal.Logic;
using ePM_Dal.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace eMedicalSys.DevExpress.ASPxSchedulerForms
{
    public partial class Appointment_Form : System.Web.UI.UserControl
    {

        public List<vPersonnel> usersList = new List<vPersonnel>();
        public static int _TimeinHrs, _userID, _roleId, _clinicId, _DaysNumber, _selectedRoomId, _selectedPatientId, _selectedServiceId, _selectedtimeId = 0;
        public static string _selectedtime, _selectedtimebegin = "";
        DateTime _selecteddate;
        string day_date, month_date, year_date = "";
        //protected void Page_PreRender(object sender, EventArgs e)
        //{
        //    if (gvUsers.Rows.Count > 0)
        //    {
        //        gvUsers.UseAccessibleHeader = true;
        //        gvUsers.HeaderRow.TableSection = TableRowSection.TableHeader;
        //    }
        //}
        protected void Page_Load(object sender, EventArgs e)
        {
            //ASPxDateEdit edit = (ASPxDateEdit)this.FindControlByID("edtStartDate");
            //_TimeinHrs = int.Parse(Session["UserId"].ToString());
            this.Page.Title = "New Appointment";
            _userID = int.Parse(Session["UserId"].ToString());
            _roleId = int.Parse(Session["RoleId"].ToString());
            _clinicId = int.Parse(Session["ClinicId"].ToString());

            bindRooms(_userID);
            binddates(_userID, _selectedRoomId);
            bindtimebegins(_userID, _selectedRoomId, day_date,month_date,year_date);
            //bindPatients(_clinicId);
            bindServices(_clinicId, _userID);
            //BindGrid(_clinicId);
            //bindTimes(_userID);
        }
        private void binddates(int usrId, int roomId)
        {
            DropDowndate.DataSource = null;
            DropDowndate.ClearSelection();
            List<BookingDates> dates = BookingManager.GetBookingTimingList_distinct_Nottoday(usrId, roomId);
            DropDowndate.DataSource = dates;
            DropDowndate.DataValueField = "RoomID";
            DropDowndate.DataTextField = "bookingDate";
            DropDowndate.DataBind();
            DropDowndate.Items[0].Selected = true;
            _selecteddate = Convert.ToDateTime(DropDowndate.SelectedItem.Text);
            day_date = _selecteddate.Day.ToString();
            month_date = _selecteddate.Month.ToString();
            year_date = _selecteddate.Year.ToString();
        }
        private void bindtimebegins(int usrId, int roomId, string dd, string mm, string yyyy)
        {

            DropDownTimebegin.DataSource = null;
            DropDownTimebegin.ClearSelection();
            List<vBookingTime> Timesbegin = BookingManager.GetBookingTimingListbyroomid(usrId, roomId);
            DropDownTimebegin.DataSource = Timesbegin;
            DropDownTimebegin.DataValueField = "ID";
            DropDownTimebegin.DataTextField = "hrstimebegin";
            DropDownTimebegin.DataBind();
            DropDownTimebegin.Items[0].Selected = true;
            _selectedtimebegin = DropDownTimebegin.SelectedItem.Text;
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
        private void bindServices(int clinicId, int userId)
        {

            DropDownService.DataSource = null;
            DropDownService.ClearSelection();
            List<vService> Services = ServiceManager.GetservicesList(clinicId, userId);
            DropDownService.DataSource = Services;
            DropDownService.DataValueField = "SID";
            DropDownService.DataTextField = "ServiceName";
            DropDownService.DataBind();
            //DropDownHRRoles.Items.Insert(0, new ListItem("All", "0"));
            DropDownService.Items[0].Selected = true;
            _selectedServiceId = int.Parse(DropDownService.SelectedItem.Value);
        }
        //private void bindPatients(int clinicId)
        //{
        //    DropDownPatient.DataSource = null;
        //    DropDownPatient.ClearSelection();
        //    List<eMedical_User> Patients = UserManager.getPatientsList(clinicId, 7);
        //    DropDownPatient.DataSource = Patients;
        //    DropDownPatient.DataValueField = "ID";
        //    DropDownPatient.DataTextField = "FName";
        //    DropDownPatient.DataBind();
        //    //DropDownHRRoles.Items.Insert(0, new ListItem("All", "0"));
        //    DropDownPatient.Items[0].Selected = true;
        //    _selectedPatientId = int.Parse(DropDownPatient.SelectedItem.Value);
        //}
        private void bindTimes(int usrId)
        {
            DropDownTime.DataSource = null;
            DropDownTime.ClearSelection();
            List<eMedical_Room> Times = ServiceManager.GetRoomsList(usrId);
            DropDownTime.DataSource = Times;
            DropDownTime.DataValueField = "ID";
            DropDownTime.DataTextField = "RoomName";
            DropDownTime.DataBind();
            DropDownTime.Items[0].Selected = true;
            _selectedtimeId = int.Parse(DropDownTime.SelectedItem.Value);
        }
        protected void DropDownRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedRoomId = int.Parse(DropDownRoom.SelectedItem.Value);
        }
        protected void DropDownService_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedServiceId = int.Parse(DropDownService.SelectedItem.Value);
        }
        //protected void DropDownPatient_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    _selectedPatientId = int.Parse(DropDownPatient.SelectedItem.Value);
        //}
        protected void DropDownTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedtimeId = int.Parse(DropDownTime.SelectedItem.Value);
        }
        protected void DropDowndate_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selecteddate = Convert.ToDateTime(DropDowndate.SelectedItem.Text);
            day_date = _selecteddate.Day.ToString();
            month_date = _selecteddate.Month.ToString();
            year_date = _selecteddate.Year.ToString();
        }
        protected void DropDownTimebegin_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedtimebegin = DropDownTimebegin.SelectedItem.Value;
        }
        //protected void btnAddNewRecord_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("~/AddNewUser.aspx", true);
        //}
        //protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        //{
        //    GridViewRow row = gvUsers.Rows[e.RowIndex];
        //    int userId = Convert.ToInt32(gvUsers.DataKeys[e.RowIndex].Values[0]);

        //    //string txtroomName = (row.FindControl("txtRoomName") as TextBox).Text;
        //    //string txtSessionDura = (row.FindControl("txtSessionDuration") as TextBox).Text;
        //    //bool isAvaialbe = (row.FindControl("chk_IsAvailable") as CheckBox).Checked;
        //    //eMedical_Room room = new eMedical_Room()
        //    //{
        //    //    ID = roomId,
        //    //    RoomName = txtroomName,
        //    //    SessionDuration = int.Parse(txtSessionDura),
        //    //    Status = isAvaialbe
        //    //};
        //}
        //private void BindGrid( int clinicId)
        //{
        //    List<eMedical_User> Patients = UserManager.getPatientsList(clinicId, 7);
        //    try
        //    {
        //        gvUsers.DataSource = Patients;
        //        gvUsers.DataBind();
        //    }
        //    catch (Exception ex)
        //    {
        //        ExceptionsManager.AddException(ex);
        //        SweetAlert.showToast(this.Page, SweetAlert.ToastType.Error, ex.Message, "Unexpected error", SweetAlert.ToasterPostion.TopCenter, false);
        //    }
        //}
    }
}