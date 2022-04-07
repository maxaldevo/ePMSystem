using ePM.Dal;
using ePM.Dal.Logic;
using ePM_Dal.Logic;
using ePM_Dal.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class EmployeesList : System.Web.UI.Page
    {
        public List<vHREmployee> EmployeeList = new List<vHREmployee>();

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (gvEmployees.Rows.Count > 0)
            {
                gvEmployees.UseAccessibleHeader = true;
                gvEmployees.HeaderRow.TableSection = TableRowSection.TableHeader;
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
                        string currentPage = HttpContext.Current.Request.Url.LocalPath;
                        if (RoleId != 1)
                        {
                            if (!SecurityManager.isPageInRole(currentPage, RoleId))
                            {
                                Response.Redirect("~/Unauthorized.aspx", true);
                            }
                        }
                        if (RoleId == 1)
                        {
                            BindEmployeesGrid(0, 0); // 0 means The SuperAdmin user.
                        }
                        else
                        {
                            ClinicId = int.Parse(Session["ClinicId"].ToString());
                            BindEmployeesGrid(ClinicId, userId);
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
        private void BindEmployeesGrid(int Clinic_ID, int userID)
        {
            try
            {
                if (EmployeeList.Count <= 0)
                {
                    EmployeeList = UserManager.GetEmployeesList(); 

                }
                gvEmployees.DataSource = EmployeeList;
                gvEmployees.DataBind();
            }
            catch (Exception ex)
            {
                ExceptionsManager.AddException(ex);
                SweetAlert.showToast(this.Page, SweetAlert.ToastType.Error, ex.Message, "Unexpected error", SweetAlert.ToasterPostion.TopCenter, false);
            }
        }
        protected void btnAddNewRecord_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AddNewEmployee.aspx", true);
        }
        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            gvEmployees.EditIndex = e.NewEditIndex;
            if (int.Parse(Session["RoleId"].ToString()) == 1)
            {
                BindEmployeesGrid(0, 0); // 0 means The SuperAdmin user.
            }
            else
            {
                this.BindEmployeesGrid(int.Parse(Session["ClinicId"].ToString()), int.Parse(Session["UserId"].ToString()));
            }
        }
        protected void OnRowCancelingEdit(object sender, EventArgs e)
        {
            gvEmployees.EditIndex = -1;
            if (int.Parse(Session["RoleId"].ToString()) == 1)
            {
                BindEmployeesGrid(0, 0); // 0 means The SuperAdmin user.
            }
            else
            {

                this.BindEmployeesGrid(int.Parse(Session["ClinicId"].ToString()), int.Parse(Session["UserId"].ToString()));
            }
        }
        protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gvEmployees.Rows[e.RowIndex];
            int employeeId = Convert.ToInt32(gvEmployees.DataKeys[e.RowIndex].Values[0]);
            string Empno = (row.FindControl("lblEmpId") as Label).Text;

            Session["EmpID"] = employeeId;
            Session["EmpNo"] = Empno;


            Response.Redirect("~/AddNewEmployee.aspx", true);
        }
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                foreach (ImageButton button in e.Row.Cells[5].Controls.OfType<ImageButton>())
                {
                    if (button.CommandName == "Delete")
                    {
                        button.Attributes["onclick"] = "if(!confirm('Do you want to delete " + "?')){ return false; };";
                    }
                }
            }
        }
        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var roleId = Convert.ToInt32(gvEmployees.DataKeys[e.RowIndex].Values[0]);
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

            if (int.Parse(Session["RoleId"].ToString()) == 1)
            {
                BindEmployeesGrid(0, 0); // 0 means The SuperAdmin user.
            }
            else
            {

                this.BindEmployeesGrid(int.Parse(Session["ClinicId"].ToString()), int.Parse(Session["UserId"].ToString()));
            }
        }
        //protected void DropDownServiceTypes_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    _selectedServiceType = int.Parse(DropDownServiceTypes.SelectedItem.Value);
        //}
        //private void BindServiceTypes(int usrID, int clinicId)
        //{
        //    DropDownServiceTypes.DataSource = null;
        //    DropDownServiceTypes.ClearSelection();
        //    List<vServiceType> ServicesTypes = ServiceManager.GetservicesTypeList(usrID, clinicId);
        //    DropDownServiceTypes.DataSource = ServicesTypes;
        //    DropDownServiceTypes.DataValueField = "ID";
        //    DropDownServiceTypes.DataTextField = "ServiceType";
        //    DropDownServiceTypes.DataBind();
        //    DropDownServiceTypes.Items[0].Selected = true;
        //    _selectedServiceType = int.Parse(DropDownServiceTypes.SelectedItem.Value);
        //}
    }
}