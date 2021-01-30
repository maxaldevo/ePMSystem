using ePM.Dal;
using ePM_Dal;
using ePM_Dal.Logic;
using ePM_Dal.Utilities;
using ePM_Dal.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class SecurityAdmin : System.Web.UI.Page
    {
        public static string _selectedDept, _fname, _firstName, _lastName,  _empno, _email, _mobile = "";
        public static int _selectedRole, _selectedHRRole = 0;
        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (gvGroups.Rows.Count > 0)
            {
                gvGroups.UseAccessibleHeader = true;
                gvGroups.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
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
                        else
                        {
                            BindGrid();
                          
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
        private void BindRoles()
        {
            DropDownRoles.DataSource = null;
            DropDownRoles.ClearSelection();
            List<LMS_Roles> groups = UserManager.GetRolesList();
            DropDownRoles.DataSource = groups;
            DropDownRoles.DataValueField = "RoleId";
            DropDownRoles.DataTextField = "RoleName";
            DropDownRoles.DataBind();
            DropDownRoles.Items[0].Selected = true;
            _selectedRole = int.Parse(DropDownRoles.SelectedItem.Value);
        }
       
        private void clearControlsAddUser()
        {
            txtEmail.Text = "";
            txtFName.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtEmpNo.Text = "";
            txtMobile.Text = "";
            // lblResult.Visible = false;
        }
        protected void btnShowData_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (DropDownHRRoles.SelectedValue == "0")
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Error", "<script>showpoperror('" + " Please Select a Role!" + "')</script>", false);
                    return;
                }
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
                        string result = UserManager.AddNewUser(_fname, _firstName, _lastName, _email, _mobile, _empno,   _selectedRole,_selectedHRRole);
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
                            clearControlsAddUser();
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
                    if (ex.HelpLink == null)
                    {
                        ex.HelpLink = HttpContext.Current.Request.Url.LocalPath;
                    }
                    ExceptionsManager.AddExceptionDetails(ex, new Page());
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "unexpected error", "<script>showpoperror('" + "Unexpected error, Please contact your Admin!" + "')</script>", false);
                }

            }

        }


        protected void DropDownRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedRole = int.Parse(DropDownRoles.SelectedItem.Value);
        }
        private void BindGridRoles()
        {
            try
            {
                gvUsers.DataSource = UserManager.GetUserroles();
                gvUsers.DataBind();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Error", "<script>showpoperror('" + "Unexpected Error! " + ex.Message + "')</script>", false);
                if (ex.HelpLink == null)
                {
                    ex.HelpLink = HttpContext.Current.Request.Url.LocalPath;
                }
                ExceptionsManager.AddExceptionDetails(ex, new Page());
            }
        }

        private void BindGrid()
        {
            try
            {
                gvGroups.DataSource = SecurityManager.Get_RoleswithCount();
                gvGroups.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
                //  Response.Write(ex.Message);
            }
        }

        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            gvGroups.EditIndex = e.NewEditIndex;
            this.BindGrid();
        }

        protected void OnRowCancelingEdit(object sender, EventArgs e)
        {
            gvGroups.EditIndex = -1;
            this.BindGrid();
        }

        protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gvGroups.Rows[e.RowIndex];
            int roleId = Convert.ToInt32(gvGroups.DataKeys[e.RowIndex].Values[0]);
            string txtRoleName = (row.FindControl("txtRoleName") as TextBox).Text;
            string txtNotes = (row.FindControl("txtNotes") as TextBox).Text;
            LMS_Roles role = new LMS_Roles()
            {
                RoleId = roleId,
                RoleName = txtRoleName,
                Notes = txtNotes
            };
            ////UPDATE user role
            SecurityManager.UpdateRole(role);
            gvGroups.EditIndex = -1;
            this.BindGrid();
        }

        #region Grid Data Bound

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                foreach (ImageButton button in e.Row.Cells[3].Controls.OfType<ImageButton>())
                {
                    if (button.CommandName == "Delete")
                    {
                        button.Attributes["onclick"] = "if(!confirm('Do you want to delete " + "?')){ return false; };";
                    }
                }
            }
        }

        #endregion Grid Data Bound

        #region delete Group

        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var roleId = Convert.ToInt32(gvGroups.DataKeys[e.RowIndex].Values[0]);
            try
            {
                //make sure group does not have any users. RoleId not in LMS_user Table
                int result = SecurityManager.DeleteRole(roleId);
                if (result == 0)
                {
                    //SweetAlert.showToast(this.Page, SweetAlert.ToastType.Warning, "Can not delete this grop as it has users!", "Unable to delete", SweetAlert.ToasterPostion.TopCenter, false);
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Unexpected error", "<script>showpoperror('" + "Can not delete this group as it has users!" + "')</script>", false);
                }
                else if (result == 1)
                {
                    // SweetAlert.showToast(this.Page, SweetAlert.ToastType.Success, "Group deleted successfully!", "Success", SweetAlert.ToasterPostion.TopCenter, false);
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Success", "<script>showpopsuccess('" + "Deleted successfully!" + "')</script>", false);
                }
                else
                {
                    // SweetAlert.showToast(this.Page, SweetAlert.ToastType.Error, "Unexpected error!", "Problem deleting", SweetAlert.ToasterPostion.TopCenter, false);
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Unexpected error", "<script>showpoperror('" + "Unexpected error!" + "')</script>", false);
                }
            }
            catch (Exception ex)
            {
                SweetAlert.showToast(this.Page, SweetAlert.ToastType.Error, ex.Message, "Problem deleting", SweetAlert.ToasterPostion.TopCenter, false);
            }
            //Delete logic

            this.BindGrid();
        }

        #endregion delete Group

        protected void btnAddGroup_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                #region Add Group in db

                LMS_Roles newGroup = new LMS_Roles()
                {
                    RoleName = txtGroupName.Text,
                    DateAdded = DateTime.Now,
                    Notes = txtGroupNotes.Text
                };
                bool res = SecurityManager.AddRole(newGroup);
                if (res)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Success", "<script>showpopsuccess('" + "Group addedd successfully!" + "')</script>", false);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Unexpected error", "<script>showpoperror('" + "Can not Add group!" + "')</script>", false);
                }

                #endregion Add Group in db

                //Rebind Grid
                BindGrid();
                //clear controls
                ClearControls();
            }
        }

        protected void DropDownHRRoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedHRRole = int.Parse(DropDownHRRoles.SelectedItem.Value);
        }
        private void BindHRRoles()
        {
            DropDownHRRoles.DataSource = null;
            DropDownHRRoles.ClearSelection();
            List<HR_RolesDTO> roles = UserManager.GetHR_Roles();
            DropDownHRRoles.DataSource = roles;
            DropDownHRRoles.DataValueField = "RoleId";
            DropDownHRRoles.DataTextField = "RoleName";
            DropDownHRRoles.DataBind();
            DropDownHRRoles.Items[0].Selected = true;
            _selectedHRRole = int.Parse(DropDownHRRoles.SelectedItem.Value);
        }
        private void ClearControls()
        {
            txtGroupName.Text = "";
            txtGroupNotes.Text = "";
        }
        protected void OnRowEditing2(object sender, GridViewEditEventArgs e)
        {

                gvUsers.EditIndex = e.NewEditIndex;
                this.BindGridRoles();
        }
        protected void OnRowCancelingEdit2(object sender, EventArgs e)
        {

                gvUsers.EditIndex = -1;
                this.BindGridRoles();
        }
        protected void gvUsers_RowDataBound2(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && gvUsers.EditIndex == e.Row.RowIndex)
            {
                string roleId = (e.Row.FindControl("lblRoleId") as Label).Text;
                DropDownList ddlroles = (e.Row.FindControl("DropDownListRoles") as DropDownList);
                ddlroles.DataSource = UserManager.GetRolesList();
                ddlroles.DataTextField = "RoleName";
                ddlroles.DataValueField = "RoleId";
                ddlroles.DataBind();
                ddlroles.Items.FindByValue(roleId).Selected = true;
            }
        }
        protected string IsActive(object active)
        {
            bool _isActive =(Boolean)active;
            string linkText = "Deactivate";
            if (_isActive == false)
            {
                linkText = "Activate";
            }
            return linkText;
        }
        protected void OnRowUpdating2(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                GridViewRow row = gvUsers.Rows[e.RowIndex];
                int userId = Convert.ToInt32(gvUsers.DataKeys[e.RowIndex].Values[0]);
                DropDownList dropdown = (row.FindControl("DropDownListRoles") as DropDownList);
                //UPDATE user role
                UserManager.ChangeRole(userId, int.Parse(dropdown.SelectedItem.Value));
                gvUsers.EditIndex = -1;
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Success", "<script>showpopsuccess('" + "Group updated  successfully" + "')</script>", false);
                this.BindGridRoles();
            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(this, typeof(Page), "Error", "<script>showpoperror('" + "Unexpected Error! " + ex.Message + "')</script>", false);
            }
        }
        protected void TabContainer1_ActiveTabChanged(object sender, EventArgs e)
        {
            if (TabContainer1.ActiveTabIndex == 0)
            {
                BindGrid();
            }
            else if (TabContainer1.ActiveTabIndex == 1)
            {
                BindGridRoles();
            }
            else if (TabContainer1.ActiveTabIndex == 2)//Add user
            {
                BindRoles();
                BindHRRoles();
            }

        }
        protected void gvUsers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Reset")
            {

                try
                {
                    int rowIndex = ((GridViewRow)((LinkButton)e.CommandSource).Parent.Parent).RowIndex;
                    GridViewRow row = (GridViewRow)(((Control)e.CommandSource).NamingContainer);
                    int _userId = Convert.ToInt32(gvUsers.DataKeys[rowIndex].Values[0]);
                    UserManager.ChangePassword(_userId, "Kipic123");
                    string userFName    = (row.FindControl("lblFName") as Label).Text;
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Success", "<script>showpopsuccess('" + "password was rest successfully for the user :"+ userFName + "')</script>", false);
                }
                catch (Exception ex)
                {
                    if (ex.HelpLink == null)
                    {
                        ex.HelpLink = HttpContext.Current.Request.Url.LocalPath;
                    }
                    ExceptionsManager.AddExceptionDetails(ex, new Page());
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Unexpected error", "<script>showpoperror('" + "Error reseting password "+ ex.Message + "')</script>", false);
                }
            } //DeActivate
            if (e.CommandName == "DeActivate")
            {

                try
                {
                    int rowIndex = ((GridViewRow)((LinkButton)e.CommandSource).Parent.Parent).RowIndex;
                    GridViewRow row = (GridViewRow)(((Control)e.CommandSource).NamingContainer);
                    int _userId = Convert.ToInt32(gvUsers.DataKeys[rowIndex].Values[0]);
                     string linkText = (row.FindControl("lblActive") as Label).Text;
                    if (linkText.ToLower() == "false")//InActive
                    {
                        UserManager.ChangeUserActive(_userId,true);
                        string userFName = (row.FindControl("lblFName") as Label).Text;
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Success", "<script>showpopsuccess('" + "Activated  user: " + userFName + " Successfully" + "')</script>", false);
                        BindGridRoles();
                    }
                    else
                    {
                        UserManager.ChangeUserActive(_userId, false);
                        string userFName = (row.FindControl("lblFName") as Label).Text;
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Success", "<script>showpopsuccess('" + "Deactivated  user: " + userFName + " Successfully" + "')</script>", false);
                        BindGridRoles();
                    }

                }
                catch (Exception ex)
                {
                    if (ex.HelpLink == null)
                    {
                        ex.HelpLink = HttpContext.Current.Request.Url.LocalPath;
                    }
                    ExceptionsManager.AddExceptionDetails(ex, new Page());
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Unexpected error", "<script>showpoperror('" + "Error Deactivating user!" + ex.Message + "')</script>", false);
                }
            }
           
        }
    }
}