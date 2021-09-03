using ePM.Dal;
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
    public partial class AddNewUser : System.Web.UI.Page
    {
        public static string _selectedDept , _fname, _firstName,_lastName,_empno,_email,_mobile = "";
        public static int _selectedRole, _selectedHRRole = 0;
       
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
                        string result = UserManager.AddNewUser(_fname, _firstName, _lastName, _email, _mobile, _empno,  _selectedRole);
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
        //private void BindHRRoles()
        //{
        //    DropDownHRRoles.DataSource = null;
        //    DropDownHRRoles.ClearSelection();
        //    List<HR_RolesDTO> roles = UserManager.GetHR_Roles();
        //    DropDownHRRoles.DataSource = roles;
        //    DropDownHRRoles.DataValueField = "RoleId";
        //    DropDownHRRoles.DataTextField = "RoleName";
        //    DropDownHRRoles.DataBind();
        //    //DropDownHRRoles.Items.Insert(0, new ListItem("All", "0"));
        //    DropDownHRRoles.Items[0].Selected = true;
        //    _selectedHRRole =int.Parse( DropDownHRRoles.SelectedItem.Value);
        //}

        protected void DropDownRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedRole = int.Parse(DropDownRoles.SelectedItem.Value);
        }

    }
}