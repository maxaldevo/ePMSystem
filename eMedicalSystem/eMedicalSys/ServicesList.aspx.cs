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
    public partial class ServicesList : System.Web.UI.Page
    {
        public List<vService> ServiceList = new List<vService>();

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (gvServices.Rows.Count > 0)
            {
                gvServices.UseAccessibleHeader = true;
                gvServices.HeaderRow.TableSection = TableRowSection.TableHeader;
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
                            BindProductsGrid(0, 0); // 0 means The SuperAdmin user.
                        }
                        else
                        {
                            ClinicId = int.Parse(Session["ClinicId"].ToString());
                            BindProductsGrid(ClinicId, userId);
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

        private void BindProductsGrid(int Clinic_ID, int userID)
        {
            try
            {
                if (ServiceList.Count<=0)
                {
                    if (Clinic_ID == 0 && userID == 0) ServiceList = ServiceManager.GetservicesList(); else ServiceList = ServiceManager.GetservicesList(Clinic_ID, userID);
                    
                }
                gvServices.DataSource = ServiceList;
                gvServices.DataBind();
            }
            catch (Exception ex)
            {
                ExceptionsManager.AddException(ex);
                SweetAlert.showToast(this.Page, SweetAlert.ToastType.Error, ex.Message, "Unexpected error", SweetAlert.ToasterPostion.TopCenter, false);
            }
        }
        protected void btnAddNewRecord_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AddNewService.aspx", true);
        }
        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            gvServices.EditIndex = e.NewEditIndex;
            if (int.Parse(Session["RoleId"].ToString()) == 1)
            {
                BindProductsGrid(0, 0); // 0 means The SuperAdmin user.
            }
            else
            {

                this.BindProductsGrid(int.Parse(Session["ClinicId"].ToString()), int.Parse(Session["UserId"].ToString()));
            }
        }

        protected void OnRowCancelingEdit(object sender, EventArgs e)
        {
            gvServices.EditIndex = -1;
            if (int.Parse(Session["RoleId"].ToString()) == 1)
            {
                BindProductsGrid(0, 0); // 0 means The SuperAdmin user.
            }
            else
            {

                this.BindProductsGrid(int.Parse(Session["ClinicId"].ToString()), int.Parse(Session["UserId"].ToString()));
            }
        }

        protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gvServices.Rows[e.RowIndex];
            int serviceId = Convert.ToInt32(gvServices.DataKeys[e.RowIndex].Values[0]);
            string txtserviceName = (row.FindControl("txtServiceName") as TextBox).Text;
            int DurationofSession = int.Parse((row.FindControl("txtDurationofSession") as TextBox).Text);
            int Price = int.Parse((row.FindControl("txtPrice") as TextBox).Text);
            bool isAvaialbe = (row.FindControl("chk_IsAvailable") as CheckBox).Checked;
            eMedical_Service servic = new eMedical_Service()
            {
                ID = serviceId,
                ServiceName = txtserviceName,
                NoofSessions = DurationofSession,
                Price = Price,
                Status = isAvaialbe
            };
            ////UPDATE user productrecord
            ServiceManager.updateService(servic);
            gvServices.EditIndex = -1;
            if (int.Parse(Session["RoleId"].ToString()) == 1)
            {
                BindProductsGrid(0, 0); // 0 means The SuperAdmin user.
            }
            else
            {

                this.BindProductsGrid(int.Parse(Session["ClinicId"].ToString()), int.Parse(Session["UserId"].ToString()));
            }
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
            var roleId = Convert.ToInt32(gvServices.DataKeys[e.RowIndex].Values[0]);
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
                BindProductsGrid(0, 0); // 0 means The SuperAdmin user.
            }
            else
            {

                this.BindProductsGrid(int.Parse(Session["ClinicId"].ToString()), int.Parse(Session["UserId"].ToString()));
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