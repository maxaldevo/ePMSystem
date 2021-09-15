﻿using ePM.Dal;
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
    public partial class AddNewProduct : System.Web.UI.Page
    {
        public static string _selectedDept , _fname, _firstName,_lastName,_empno,_email,_mobile = "";
        public static int _selectedRole, _selectedHospital, _selectedClinic = 0;
        public List<vPersonnel> usersList = new List<vPersonnel>();

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

                int userId, RoleId, ClinicId = 0;
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
                        if (RoleId == 1)
                        {
                            BindUsersGrid(0); // 0 means The SuperAdmin user.
                        }
                        else
                        {
                            ClinicId = int.Parse(Session["ClinicId"].ToString());
                            BindUsersGrid(ClinicId);
                        }
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
                BindHospitals();
                BindRoles();
                BindClinics(); 
            }
        }
        protected void btnShowData_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    //Validate user name and emp No
                  
                    _fname = txtFName.Text;
                    _firstName = txtFirstName.Text;
                    _lastName = txtLastName.Text;
                    _email = txtEmail.Text;

                    _empno = txtEmpNo.Text;
                    _mobile = !string.IsNullOrWhiteSpace(txtMobile.Text) ? txtMobile.Text : null;
                    bool emailExist = UserManager.checkUserEmail(_email);
                    bool empoExist = UserManager.checkUserEmpNo(_empno);
                    if (!emailExist && !empoExist)
                    {
                        string result = UserManager.AddNewUser_By_HospitalID_ClinicID(_fname, _firstName, _lastName, _email, _mobile, _empno, _selectedRole, _selectedHospital, _selectedClinic);
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
                            if (int.Parse(Session["RoleId"].ToString()) == 1) BindUsersGrid(0); else BindUsersGrid(int.Parse(Session["ClinicId"].ToString()));
                        }
                    }
                    else
                    {
                        lblResult.Visible = true;
                        lblResult.ForeColor = System.Drawing.Color.Red;
                        lblResult.Text = "User email or Employee No exists";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpopwarning('" + "User email or Employee No exists!" + "')</script>", false);
                    } 
                   
                }
                catch (Exception ex)
                {

                    ScriptManager.RegisterStartupScript(this, typeof(Page), "unexpected error", "<script>showpoperror('" +  "Unexpected error, Please contact your Admin!" + ex.Message+  "')</script>", false);
                }
          
            }

        }
        private void clearControls()
        {
            txtEmail.Text = "";
            txtFName.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtEmpNo.Text = "";
            txtMobile.Text = "";
            // lblResult.Visible = false;
        }
        //protected void DropDownHRRoles_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    _selectedHRRole = int.Parse(DropDownHRRoles.SelectedItem.Value);
        //}

        private void BindUsersGrid(int Clinic_ID)
        {
            try
            {
                if (Cache["UsersList"] == null)
                {
                    if (Clinic_ID == 0) usersList = UserManager.getUsersList(); else usersList = UserManager.getUsersList(Clinic_ID);
                    Cache["UsersList"] = usersList;
                    Cache.Insert("UsersList", usersList, null, DateTime.MaxValue, TimeSpan.FromMinutes(5));
                    //  Response.Write("<script>alert('Its processing from Data hit');</script>");
                }
                else
                {
                    //If cache has value, It retrive from cache memory and bind into the gridview
                    //  Response.Write("<script>alert('Its processing from cache');</script>");
                }
                gvUsers.DataSource = (List<vPersonnel>)Cache["UsersList"];
                gvUsers.DataBind();
            }
            catch (Exception ex)
            {
                ExceptionsManager.AddException(ex);
                SweetAlert.showToast(this.Page, SweetAlert.ToastType.Error, ex.Message, "Unexpected error", SweetAlert.ToasterPostion.TopCenter, false);
            }
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
        private void BindClinics()
        {
            DropDownClinics.DataSource = null;
            DropDownClinics.ClearSelection();
            List<eMedical_Clinic> Clinics = ClinicManager.GetClinicsList(_selectedHospital);
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