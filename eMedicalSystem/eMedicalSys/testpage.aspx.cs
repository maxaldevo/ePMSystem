using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.Demos;
using ePM.Dal;
using ePM_Dal.Logic;
using ePM_Dal.Utilities;

namespace eMedicalSys
{
    public partial class testpage : System.Web.UI.Page
    {
        public List<vPersonnel> usersList = new List<vPersonnel>();
        public static int _TimeinHrs, _userID, _roleId, _clinicId, _DaysNumber, _selectedRoomId, _selectedPatientId, _selectedServiceId, _selectedtimeId = 0;
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
                _userID = int.Parse(Session["UserId"].ToString());
                _roleId = int.Parse(Session["RoleId"].ToString());
                _clinicId = int.Parse(Session["ClinicId"].ToString());

                BindGrid(_clinicId);

            }
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
    }
}