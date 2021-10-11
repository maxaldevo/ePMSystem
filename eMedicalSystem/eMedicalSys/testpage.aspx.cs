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
        public static string _selectedtime, _selectedtimebegin, _selecteddate = "";
        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (gvUsers.Rows.Count > 0)
            {
                gvUsers.UseAccessibleHeader = true;
                gvUsers.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }
        protected void Page_Init()
        {
            //DemoHelper.Instance.ControlAreaMaxWidth = Unit.Percentage(100);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //#region Page Validation

                //int usrId, RoleId, clinicID = 0;
                //if (Session["UserId"] == null)
                //{
                //    Response.Redirect("~/Login/Login.aspx", true);
                //}
                //else
                //{
                //    if (int.Parse(Session["UserId"].ToString()) != 0)
                //    {
                //        usrId = int.Parse(Session["UserId"].ToString());
                //        RoleId = int.Parse(Session["RoleId"].ToString());
                //        clinicID = int.Parse(Session["ClinicId"].ToString());

                //        string currentPage = HttpContext.Current.Request.Url.LocalPath;
                //        if (RoleId != 1)
                //        {
                //            if (!SecurityManager.isPageInRole(currentPage, RoleId))
                //            {
                //                Response.Redirect("~/Unauthorized.aspx", true);
                //            }
                //        }
                //    }
                //    else
                //    {
                //        Response.Redirect("~/Login/Login.aspx", true);
                //    }
                //}

                //#endregion Page Validation
                _userID = int.Parse(Session["UserId"].ToString());
                _roleId = int.Parse(Session["RoleId"].ToString());
                _clinicId = int.Parse(Session["ClinicId"].ToString());

                BindGrid(_clinicId); 
                bindRooms(_userID);
                binddates(_userID, _selectedRoomId);
                bindtimebegins(_userID, _selectedRoomId);
                //bindPatients(_clinicId);
                bindServices(_clinicId, _userID);

            }
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
            _selecteddate = DropDowndate.SelectedItem.Text;
        }
        private void bindtimebegins(int usrId, int roomId)
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
            Response.Redirect("~/AddNewUser.aspx", true);
        }
        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = gvUsers.Rows[e.NewEditIndex];
            Session["PatientId"] = Convert.ToInt32(gvUsers.DataKeys[e.NewEditIndex].Values[0]);
        }
        protected void DropDownRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedRoomId = int.Parse(DropDownRoom.SelectedItem.Value);
        }
        protected void DropDownService_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedServiceId = int.Parse(DropDownService.SelectedItem.Value);
        }
        protected void DropDownTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedtimeId = int.Parse(DropDownTime.SelectedItem.Value);
        }
        protected void DropDowndate_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selecteddate = DropDowndate.SelectedItem.Text;
        }
        protected void DropDownTimebegin_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedtimebegin = DropDownTimebegin.SelectedItem.Value;
        }
    }
}