using ePM.Dal;
using ePM.Dal.Logic;
using ePM_Dal.Logic;
using ePM_Dal.Utilities;
using System;
using System.Collections.Generic;
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
                        else if (RoleId == 1)
                        {
                            BindRoomsGrid(); // 0 means The SuperAdmin user.
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
                if (Cache["RoomsList"] == null)
                {
                    roomList = ServiceManager.GetRoomsList();
                    Cache["RoomsList"] = roomList;
                    Cache.Insert("RoomsList", roomList, null, DateTime.MaxValue, TimeSpan.FromMinutes(5));
                }
                gvRooms.DataSource = (List<eMedical_Room>)Cache["RoomsList"];
                gvRooms.DataBind();
            }
            catch (Exception ex)
            {
                ExceptionsManager.AddException(ex);
                SweetAlert.showToast(this.Page, SweetAlert.ToastType.Error, ex.Message, "Unexpected error", SweetAlert.ToasterPostion.TopCenter, false);
            }
        }
    }
}