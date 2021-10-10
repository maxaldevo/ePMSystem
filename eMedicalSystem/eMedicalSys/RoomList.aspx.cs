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

    public partial class RoomList : System.Web.UI.Page
    {
        public List<eMedical_Room> roomList = new List<eMedical_Room>();

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (gvRooms.Rows.Count > 0)
            {
                gvRooms.UseAccessibleHeader = true;
                gvRooms.HeaderRow.TableSection = TableRowSection.TableHeader;
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
                        if (RoleId == 1)
                        {
                            BindRoomsGrid(); // 0 means The SuperAdmin user.
                        }
                        else
                        {
                            BindRoomsGrid(userId);
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

        private void BindRoomsGrid()
        {
            try
            {
                if (roomList.Count <= 0)
                {
                    roomList = ServiceManager.GetRoomsList();
                    
                }
                gvRooms.DataSource = roomList;
                gvRooms.DataBind();
            }
            catch (Exception ex)
            {
                ExceptionsManager.AddException(ex);
                SweetAlert.showToast(this.Page, SweetAlert.ToastType.Error, ex.Message, "Unexpected error", SweetAlert.ToasterPostion.TopCenter, false);
            }
        }
        private void BindRoomsGrid(int userId)
        {
            try
            {
                if (roomList.Count <= 0)
                {
                    roomList = ServiceManager.GetRoomsList(userId);
                    
                }
                gvRooms.DataSource = roomList;
                gvRooms.DataBind();
            }
            catch (Exception ex)
            {
                ExceptionsManager.AddException(ex);
                SweetAlert.showToast(this.Page, SweetAlert.ToastType.Error, ex.Message, "Unexpected error", SweetAlert.ToasterPostion.TopCenter, false);
            }
        }
        protected void btnAddNewRecord_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AddNewRoom.aspx", true);
        }
        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            gvRooms.EditIndex = e.NewEditIndex;
            if (int.Parse(Session["RoleId"].ToString()) == 1)
            {
                BindRoomsGrid(0); // 0 means The SuperAdmin user.
            }
            else
            {

                BindRoomsGrid(int.Parse(Session["UserId"].ToString()));
            }
        }
        protected void OnRowCancelingEdit(object sender, EventArgs e)
        {
            gvRooms.EditIndex = -1;
            if (int.Parse(Session["RoleId"].ToString()) == 1)
            {
                BindRoomsGrid(0); // 0 means The SuperAdmin user.
            }
            else
            {

                BindRoomsGrid(int.Parse(Session["UserId"].ToString()));
            }
        }
        protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gvRooms.Rows[e.RowIndex];
            int roomId = Convert.ToInt32(gvRooms.DataKeys[e.RowIndex].Values[0]);
            string txtroomName = (row.FindControl("txtRoomName") as TextBox).Text;
            string txtSessionDura = (row.FindControl("txtSessionDuration") as TextBox).Text;

            bool isAvaialbe = (row.FindControl("chk_IsAvailable") as CheckBox).Checked;
            eMedical_Room room = new eMedical_Room()
            {
                ID = roomId,
                RoomName = txtroomName,
                SessionDuration = int.Parse(txtSessionDura),
                Status = isAvaialbe
            };
            ////UPDATE user productrecord
            ClinicManager.updateRoom(room);
            gvRooms.EditIndex = -1;
            if (int.Parse(Session["RoleId"].ToString()) == 1)
            {
                BindRoomsGrid(0); // 0 means The SuperAdmin user.
            }
            else
            {

                BindRoomsGrid(int.Parse(Session["UserId"].ToString()));
            }
        }
        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                foreach (ImageButton button in e.Row.Cells[2].Controls.OfType<ImageButton>())
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
            var roleId = Convert.ToInt32(gvRooms.DataKeys[e.RowIndex].Values[0]);
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
                BindRoomsGrid(0); // 0 means The SuperAdmin user.
            }
            else
            {

                BindRoomsGrid(int.Parse(Session["UserId"].ToString()));
            }
        }
    }
}