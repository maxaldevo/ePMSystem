using ePM.Dal;
using ePM.Dal.Logic;
using ePM_Dal.Logic;
using ePM_Dal.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class AddNewClinic : System.Web.UI.Page
    {
        public static string _clinicname;
        public static int _selectedHospital;
       
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
                        }
                    }
                    else
                    {
                        Response.Redirect("~/Login/Login.aspx", true);
                    }
                }

                #endregion Page Validation
               // BindDepartments();
                BindRoles();
                //BindHRRoles();
            }
        }
        protected void btnShowData_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    //Validate user name and emp No

                    _clinicname = txtClinicName.Text;

                    bool clinicExist =ClinicManager.checkUserClinicName(_clinicname);
                    if (!clinicExist)
                    {
                        string result = ClinicManager.AddNewClinic(_clinicname, _selectedHospital, int.Parse(Session["UserId"].ToString()));
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
                    else
                    {
                        lblResult.Visible = true;
                        lblResult.ForeColor = System.Drawing.Color.Red;
                        lblResult.Text = "User email or Employee No exists";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Warning", "<script>showpopwarning('" + "Clinic No exists!" + "')</script>", false);
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
            txtClinicName.Text = "";
           // lblResult.Visible = false;
        }


        private void BindRoles()
        {
            DropDownHospitals.DataSource = null;
            DropDownHospitals.ClearSelection();
            List<eMedical_Hospital> groups = ClinicManager.GetHospitalsList();
            DropDownHospitals.DataSource = groups;
            DropDownHospitals.DataValueField = "ID";
            DropDownHospitals.DataTextField = "HospitalName";
            DropDownHospitals.DataBind();
            DropDownHospitals.Items[0].Selected = true;
            _selectedHospital = int.Parse(DropDownHospitals.SelectedItem.Value);
        }


        protected void DropDownHospitals_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedHospital = int.Parse(DropDownHospitals.SelectedItem.Value);
        }

    }
}