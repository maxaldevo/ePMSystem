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
    public partial class UpdateEmployee : System.Web.UI.Page
    {
        public bool _RTD;
        public static string _FileNo, _EmpId, _FullnameAr, _FullnameEn, _Designation, _Nationality, _CivilId, _ResidencyDate, _PassportNo, _PassportExpDate, _Status, _JoinedDate, _Remarks, _Salary, _TransferedFrom, _TransferedFromDate, _TransferedTo, _TransferedToDate, _VacationFrom, _VacationTo, _VacationFromDays, _VacationExt_1_From, _VacationExt_1_To, _VacationExt_2_From, _VacationExt_2_To, _VacationExt_3_From, _VacationExt_3_To = "";
        public static int _selectedRole, _selectedHospital, _selectedClinic, _employeeId, _employeeNo = 0;
        public List<vPersonnel> usersList = new List<vPersonnel>();
        public List<vHREmployee> EmployeeList = new List<vHREmployee>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                #region Page Validation

                int userId, RoleId = 0;
                if (Session["UserId"] == null)
                {
                    Response.Redirect("~/Login/Login.aspx", true);
                }
                else
                {
                    if (int.Parse(Session["UserId"].ToString()) != 0)
                    {
                        userId = int.Parse(Session["UserId"].ToString());
                        RoleId = int.Parse(Session["RoleId"].ToString());

                        string currentPage = HttpContext.Current.Request.Url.LocalPath;
                        if (RoleId != 1)
                        {
                            if (!SecurityManager.isPageInRole(currentPage, RoleId))
                            {
                                Response.Redirect("~/Unauthorized.aspx", true);
                            }
                            BindRoles();
                        }
                        else
                        {
                            _employeeId = int.Parse(Session["EmpID"].ToString());
                            _employeeNo = int.Parse(Session["EmpNo"].ToString());
                            if (_employeeId != 0 && _employeeNo != 0)
                            {
                                var employee = UserManager.GetEmployeesList(_employeeId, _employeeNo.ToString());

                                txtempid.Text = employee.EmpId;
                                txtFileno.Text = employee.FileNo;
                                txtFullNameAr.Text = employee.FullnameAr;
                                txtFullNameEn.Text = employee.FullnameEn;
                                txtDesignation.Text = employee.Designation;
                                txtNationality.Text = employee.Nationality;
                                txtcivilNo.Text = employee.CivilId;
                                txtResidencyDate.Text = employee.ResidencyDate;
                                txtPassportNo.Text = employee.PassportNo;
                                txtPassportExpDate.Text = employee.PassportExpDate;
                                txtStatus.Text = employee.Status;
                                txtJoinedDate.Text = employee.JoinedDate;
                                txtTransferedFrom.Text = employee.TransferedFrom;
                                txtTransferedTo.Text = employee.TransferedTo;
                                txtTransferedFromdate.Text = employee.TransferedFromDate;
                                txtTransferedTodate.Text = employee.TransferedToDate;
                                txtSalary.Text = employee.Salary;
                                if (employee.RTD == true) chk_RTD.Checked = true; else chk_RTD.Checked = false;
                                txtRemarks.Text = employee.Remarks;
                                txtVacationFrom.Text = employee.VacationFrom;
                                txtVacationTo.Text = employee.VacationTo;
                                txtVacationDaysNo.Text = employee.VacationFromDays;
                                txtVacationExt_1_From.Text = employee.VacationExt_1_From;
                                txtVacationExt_1_To.Text = employee.VacationExt_1_To;
                                txtVacationExt_2_From.Text = employee.VacationExt_2_From;
                                txtVacationExt_2_To.Text = employee.VacationExt_2_To;
                                txtVacationExt_3_From.Text = employee.VacationExt_3_From;
                                txtVacationExt_3_To.Text = employee.VacationExt_3_To;
                            }

                            //BindHospitals();
                            //BindClinics(_selectedHospital);
                            //DropDownClinics.Visible = true;
                            //DropDownHospitals.Visible = true;
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
                    _FileNo = txtFileno.Text;
                    _EmpId = txtempid.Text;
                    _FullnameAr = txtFullNameAr.Text;
                    _FullnameEn = txtFullNameEn.Text;
                    _Designation = txtDesignation.Text;
                    _Nationality = txtNationality.Text;
                    _CivilId = txtcivilNo.Text;
                    _ResidencyDate = txtResidencyDate.Text;
                    _PassportNo = txtPassportNo.Text;
                    _PassportExpDate = txtPassportExpDate.Text;
                    _Status = txtStatus.Text;
                    _JoinedDate = txtJoinedDate.Text;
                    _Salary = txtSalary.Text;
                    _TransferedFrom = txtTransferedFrom.Text;
                    _TransferedFromDate = txtTransferedFromdate.Text;
                    _TransferedTo = txtTransferedTo.Text;
                    _TransferedToDate = txtTransferedTodate.Text;
                    _Remarks = txtRemarks.Text;
                    if (chk_RTD.Checked) _RTD = true; else _RTD = false;
                    _VacationFrom = txtVacationFrom.Text;
                    _VacationTo = txtVacationTo.Text;
                    _VacationFromDays = txtVacationDaysNo.Text;
                    _VacationExt_1_From = txtVacationExt_1_From.Text;
                    _VacationExt_1_To = txtVacationExt_1_To.Text;
                    _VacationExt_2_From = txtVacationExt_2_From.Text;
                    _VacationExt_2_To = txtVacationExt_2_To.Text;
                    _VacationExt_3_From = txtVacationExt_3_From.Text;
                    _VacationExt_3_From = txtVacationExt_3_To.Text;
                    string result = "";
                    bool empIDExist = UserManager.checkEmpID(_EmpId);
                    //bool empoExist = UserManager.checkUserEmpNo(_civilno);
                    if (!empIDExist)
                    {
                        result = UserManager.AddNewEmpolyee(_FileNo, _EmpId, _FullnameAr, _FullnameEn, _Designation, _Nationality, _CivilId, _ResidencyDate, _PassportNo, _PassportExpDate, _Status, _JoinedDate, _Remarks, Session["UserId"].ToString(), _Salary, _TransferedFrom, _TransferedFromDate, _TransferedTo, _TransferedToDate, _RTD, _VacationFrom, _VacationTo, _VacationFromDays, _VacationExt_1_From, _VacationExt_1_To, _VacationExt_2_From, _VacationExt_2_To, _VacationExt_3_From, _VacationExt_3_To);
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
                        }
                    }
                    else
                    {
                        result = UserManager.UpdateExistEmpolyee(_FileNo, _EmpId, _FullnameAr, _FullnameEn, _Designation, _Nationality, _CivilId, _ResidencyDate, _PassportNo, _PassportExpDate, _Status, _JoinedDate, _Remarks, Session["UserId"].ToString(), _Salary, _TransferedFrom, _TransferedFromDate, _TransferedTo, _TransferedToDate, _RTD, _VacationFrom, _VacationTo, _VacationFromDays, _VacationExt_1_From, _VacationExt_1_To, _VacationExt_2_From, _VacationExt_2_To, _VacationExt_3_From, _VacationExt_3_To);
                        if (result == "updated")
                        {

                            lblResult.Visible = true;
                            lblResult.ForeColor = System.Drawing.Color.Red;
                            lblResult.Text = "Employee has been updated!";
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "Success", "<script>showpopsuccess('" + "User updated successfully!" + "')</script>", false);
                        }
                        else
                        {
                            lblResult.Visible = true;
                            lblResult.ForeColor = System.Drawing.Color.Red;
                            lblResult.Text = "User email or Employee No exists";
                            ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpopwarning('" + "User email or Employee No exists!" + "')</script>", false);
                        }
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
            //txtEmail.Text = "";
            //txtFName.Text = "";
            txtFullNameAr.Text = "";
            txtLastName.Text = "";
            txtcivilNo.Text = "";
            //txtMobile.Text = "";
            // lblResult.Visible = false;
        }
        private void BindRoles()
        {
            DropDownRoles.DataSource = null;
            DropDownRoles.ClearSelection();
            List<eMedical_Roles> groups = UserManager.GetRolesList();
            DropDownRoles.DataSource = groups;
            DropDownRoles.DataValueField = "RoleId";
            DropDownRoles.DataTextField = "RoleName";
            DropDownRoles.DataBind();
            DropDownRoles.Items[0].Selected = true;
            _selectedRole = int.Parse(DropDownRoles.SelectedItem.Value);
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
        protected void DropDownHospitals_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedHospital = int.Parse(DropDownHospitals.SelectedItem.Value);
            BindClinics(_selectedHospital);
        }
        protected void DropDownRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedRole = int.Parse(DropDownRoles.SelectedItem.Value);
        }
        protected void DropDownClinics_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedClinic = int.Parse(DropDownClinics.SelectedItem.Value);
        }
    }
}