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
    public partial class AddNewService : System.Web.UI.Page
    {
        public static string  _sName;
        public static int _noOfSessions, _price, _clinicId, _userID, _selectedHospital, _selectedClinic, _selectedServiceType, _selectedRoom = 0;

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
                        _clinicId = int.Parse(Session["ClinicId"].ToString());

                        string currentPage = HttpContext.Current.Request.Url.LocalPath;
                        if (RoleId != 1)
                        {
                            if (!SecurityManager.isPageInRole(currentPage, RoleId))
                            {
                                Response.Redirect("~/Unauthorized.aspx", true);
                            }
                            BindRooms(_userID);
                            BindServiceTypes(_userID, _clinicId);
                        }
                        else
                        {
                            BindHospitals();
                            BindClinics(_selectedHospital);
                            BindRooms(_userID);
                            BindServiceTypes(_userID, _clinicId);
                            DropDownClinics.Visible = true;
                            DropDownHospitals.Visible = true;
                        }
                    }
                    else
                    {
                        Response.Redirect("~/Login/Login.aspx", true);
                    }
                }
                #endregion Page Validation
            }
        }
        protected void btnShowData_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    //Validate user name and emp No

                    _sName = txtSName.Text;
                    _noOfSessions = int.Parse(txtnosessions.Text);
                    _price = int.Parse(txtPrice.Text);

                    string result = ServiceManager.AddNewService(_sName, _selectedServiceType, _noOfSessions, _price, _selectedClinic, _selectedHospital, _selectedRoom, _userID);
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
            txtSName.Text = "";
            txtnosessions.Text = "";
            txtPrice.Text = "";
            // lblResult.Visible = false;
        }



        private void BindHospitals()
        {
            DropDownHospitals.DataSource = null;
            DropDownHospitals.ClearSelection();
            List<eMedical_Hospital> Hospitals = ClinicManager.GetHospitalsList();
            DropDownHospitals.DataSource = Hospitals;
            DropDownHospitals.DataValueField = "ID";
            DropDownHospitals.DataTextField = "HospitalName";
            DropDownHospitals.DataBind();
            //DropDownHRRoles.Items.Insert(0, new ListItem("All", "0"));
            DropDownHospitals.Items[0].Selected = true;
            _selectedHospital = int.Parse(DropDownHospitals.SelectedItem.Value);
        }
        private void BindRooms(int usrId)
        {
            DropDownRooms.DataSource = null;
            DropDownRooms.ClearSelection();
            List<eMedical_Room> Rooms = ServiceManager.GetRoomsList(usrId);
            DropDownRooms.DataSource = Rooms;
            DropDownRooms.DataValueField = "ID";
            DropDownRooms.DataTextField = "RoomName";
            DropDownRooms.DataBind();
            //DropDownHRRoles.Items.Insert(0, new ListItem("All", "0"));
            DropDownRooms.Items[0].Selected = true;
            _selectedRoom = int.Parse(DropDownRooms.SelectedItem.Value);
        }
        private void BindRooms()
        {
            DropDownRooms.DataSource = null;
            DropDownRooms.ClearSelection();
            List<eMedical_Room> Rooms = ServiceManager.GetRoomsList();
            DropDownRooms.DataSource = Rooms;
            DropDownRooms.DataValueField = "ID";
            DropDownRooms.DataTextField = "RoomName";
            DropDownRooms.DataBind();
            //DropDownHRRoles.Items.Insert(0, new ListItem("All", "0"));
            DropDownRooms.Items[0].Selected = true;
            _selectedRoom = int.Parse(DropDownRooms.SelectedItem.Value);
        }
        private void BindClinics(int selectedHospital)
        {
            DropDownClinics.DataSource = null;
            DropDownClinics.ClearSelection();
            List<eMedical_Clinic> Clinics = ClinicManager.GetClinicsList(selectedHospital);
            DropDownClinics.DataSource = Clinics;
            DropDownClinics.DataValueField = "ID";
            DropDownClinics.DataTextField = "ClinicName";
            DropDownClinics.DataBind();
            //DropDownHRRoles.Items.Insert(0, new ListItem("All", "0"));
            DropDownClinics.Items[0].Selected = true;
            _selectedClinic = int.Parse(DropDownClinics.SelectedItem.Value);
        }
        private void BindServiceTypes(int usrID, int clinicId)
        {
            DropDownServiceTypes.DataSource = null;
            DropDownServiceTypes.ClearSelection();
            List<vServiceType> ServicesTypes = ServiceManager.GetservicesTypeList(usrID, clinicId);
            DropDownServiceTypes.DataSource = ServicesTypes;
            DropDownServiceTypes.DataValueField = "ID";
            DropDownServiceTypes.DataTextField = "ServiceType";
            DropDownServiceTypes.DataBind();
            DropDownServiceTypes.Items[0].Selected = true;
            _selectedServiceType = int.Parse(DropDownServiceTypes.SelectedItem.Value);
        }

        protected void DropDownHospitals_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedHospital = int.Parse(DropDownHospitals.SelectedItem.Value);
            BindClinics(_selectedHospital);
        }

        protected void DropDownClinics_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedClinic = int.Parse(DropDownClinics.SelectedItem.Value);
        }

        protected void DropDownServiceTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedServiceType = int.Parse(DropDownServiceTypes.SelectedItem.Value);
        }
        protected void DropDownRooms_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedRoom = int.Parse(DropDownRooms.SelectedItem.Value);
        }
    }
}