using ePM.Dal;
using ePM.Dal.Logic;
using ePM_Dal.Logic;
using ePM_Dal.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class BookingTimesList : System.Web.UI.Page
    {
        public static DateTime _selectedDate = DateTime.Now;
        public List<vBookingTime> bookingTimesList = new List<vBookingTime>();
        
        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (gvBookingTimes.Rows.Count > 0)
            {
                gvBookingTimes.UseAccessibleHeader = true;
                gvBookingTimes.HeaderRow.TableSection = TableRowSection.TableHeader;
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
                    }
                    else
                    {
                        Response.Redirect("~/Login/Login.aspx", true);
                    }
                }

                #endregion Page Validation

                this.BindGrid();
            }
        }

        private void BindGrid()
        {
            try
            {
                if (Cache["bookingTimesList"] == null)
                {
                    bookingTimesList = BookingManager.GetBookingTimingList();
                    Cache["bookingTimesList"] = bookingTimesList;
                    Cache.Insert("bookingTimesList", bookingTimesList, null, DateTime.MaxValue, TimeSpan.FromMinutes(5));
                }

                gvBookingTimes.DataSource = (List<vBookingTime>)Cache["bookingTimesList"];
                gvBookingTimes.DataBind();
            }
            catch (Exception ex)
            {
                ExceptionsManager.AddException(ex);
                SweetAlert.showToast(this.Page, SweetAlert.ToastType.Error, ex.Message, "Unexpected error", SweetAlert.ToasterPostion.TopCenter, false);
            }
        }
        public static String convert(int mins)
        {
            int hours = (mins - mins % 60) / 60;
            return "" + hours + ":" + (mins - hours * 60);
        }

        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            gvBookingTimes.EditIndex = e.NewEditIndex;
            this.BindGrid();
        }

        protected void OnRowCancelingEdit(object sender, EventArgs e)
        {
            gvBookingTimes.EditIndex = -1;
            this.BindGrid();
        }

        protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gvBookingTimes.Rows[e.RowIndex];
            int BookingTimeId = Convert.ToInt32(gvBookingTimes.DataKeys[e.RowIndex].Values[0]);
            bool isAvaialbe = (row.FindControl("chk_IsAvailable") as CheckBox).Checked;
            eMedical_BookingTiming bookingTimeRecord = new eMedical_BookingTiming()
            {
                ID = BookingTimeId,
                IsAvailable = isAvaialbe
            };
            ////UPDATE user role
            BookingManager.updateBookingTimeRecord(bookingTimeRecord);
            gvBookingTimes.EditIndex = -1;
            this.BindGrid();
        }

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

        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var roleId = Convert.ToInt32(gvBookingTimes.DataKeys[e.RowIndex].Values[0]);
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
        //protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        //{
        //    gvBookingTimes.DataSource = "";
        //    _selectedDate = Calendar1.SelectedDate;
        //    this.BindGrid(_selectedDate);
        //}

        //protected void gvBookingTimes_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    DataRowView data = (DataRowView)e.Row.DataItem;
        //    if (data == null)
        //        return;
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        if (data["IsBooked"].ToString() != "true")
        //            e.Row.BackColor = Color.Red;
        //        else
        //        {
        //            e.Row.BackColor = Color.Green;
        //        }
        //    }
        //}
    }
}