using ePM_Dal;
using ePM_Dal.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class UserRoles : System.Web.UI.Page
    {
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
                                Response.Redirect("~/Unauthorized.aspx",true);
                            }
                           
                        }
                    }
                    else
                    {
                        Response.Redirect("~/Login/Login.aspx", true);
                    }
                }
                #endregion
   
                    this.BindGrid();
            }
        }

        private void BindGrid()
        {
            try
            {
                gvUsers.DataSource = UserManager.GetUserroles();
                gvUsers.DataBind();
            }
            catch (Exception ex)
            {
                ExceptionsManager.AddException(ex);
                Response.Write(ex.Message);
            }
        }
        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            gvUsers.EditIndex = e.NewEditIndex;
            this.BindGrid();
        }

        protected void OnRowCancelingEdit(object sender, EventArgs e)
        {
            gvUsers.EditIndex = -1;
            this.BindGrid();
        }

        protected void gvUsers_RowDataBound(object sender, GridViewRowEventArgs e)
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

        protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gvUsers.Rows[e.RowIndex];
            int userId = Convert.ToInt32(gvUsers.DataKeys[e.RowIndex].Values[0]);
            DropDownList dropdown = (row.FindControl("DropDownListRoles") as DropDownList);
           // TextBox txtPosition = (row.FindControl("txtPosition") as TextBox);
            //UPDATE user role
            UserManager.ChangeRole(userId, int.Parse(dropdown.SelectedItem.Value));
            gvUsers.EditIndex = -1;
            this.BindGrid();
        }
    }
}