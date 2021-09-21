using ePM.Dal;
using ePM.Dal.Logic;
using ePM_Dal.Logic;
using ePM_Dal.Utilities;
using ePM_Dal.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class AddBookingTiming : System.Web.UI.Page
    {
        public static int _userID, _DaysNumber, _selectedServiceId = 0;
        public static List<DateTime> selectedDateslist = new List<DateTime>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                #region Page Validation

                int RoleId, ClinicId = 0;
                if (Session["UserId"] == null)
                {
                    Response.Redirect("~/Login/Login.aspx", true);
                }
                else
                {
                    if (int.Parse(Session["UserId"].ToString()) != 0)
                    {
                        _userID = int.Parse(Session["UserId"].ToString());
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
                bindServices(); 
            }
        }
        protected void btnShowData_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    //Validate user name and emp No
                    foreach (DateTime dt in selectedDateslist)
                    {
                        Calendar1.SelectedDates.Add(dt);
                        txt_date.Text = Calendar1.SelectedDate.ToShortDateString();
                    }
                    //    _DaysNumber = int.Parse(txtDaysNumber.Text);

                    //    string result = BookingManager.CreateSchedule(_DaysNumber, Convert.ToDateTime(txt_date.Text), _selectedServiceId, _userID);
                    //    if (result != "inserted")
                    //    {
                    //        lblResult.Visible = true;
                    //        lblResult.ForeColor = System.Drawing.Color.Red;
                    //        lblResult.Text = result;
                    //        ScriptManager.RegisterStartupScript(this, typeof(Page), "Error", "<script>showpoperror('" + result + " Please contact your Admin!" + "')</script>", false);
                    //    }
                    //    else
                    //    {
                    //        lblResult.Visible = true;
                    //        lblResult.ForeColor = System.Drawing.Color.Green;
                    //        lblResult.Text = result;
                    //        clearControls();
                    //        ScriptManager.RegisterStartupScript(this, typeof(Page), "Success", "<script>showpopsuccess('" + "User added successfully!" + "')</script>", false);
                    //        //Re-Bind the user grid based on the User's role.
                    //        //if (int.Parse(Session["RoleId"].ToString()) == 1) BindProductsGrid(0, 0); else BindProductsGrid(int.Parse(Session["ClinicId"].ToString()), int.Parse(Session["UserId"].ToString()));
                    //    }


                }
                catch (Exception ex)
                {

                    ScriptManager.RegisterStartupScript(this, typeof(Page), "unexpected error", "<script>showpoperror('" + "Unexpected error, Please contact your Admin!" + ex.Message + "')</script>", false);
                }

            }

        }
        private void clearControls()
        {
            txtDaysNumber.Text = "";
            // lblResult.Visible = false;
        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            //try
            //{
            //    int cnt = BookingManager.GetBookingTimingList_distinct().Count;
            //    for (int i = 0; i < cnt - 1; i++)
            //    {
            //        if (e.Day.Date.CompareTo(BookingManager.GetBookingTimingList_distinct()[i].bookingDate) < 0)
            //        {
            //            e.Day.IsSelectable = false;
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{

            //    ScriptManager.RegisterStartupScript(this, typeof(Page), "unexpected error", "<script>showpoperror('" + "Unexpected error, Please contact your Admin!" + ex.Message + "')</script>", false);
            //}
            Color NormColor = new Color();
            NormColor = e.Cell.BackColor;
            if (e.Day.IsSelected == true)
            {
                selectedDateslist.Add(e.Day.Date);
                e.Cell.BackColor = Color.Orange;
            }
            else
            {
                selectedDateslist.Remove(e.Day.Date);
                e.Cell.BackColor = NormColor;
            }
            Session["SelectedDates"] = selectedDateslist;
        }
        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            if (Session["SelectedDates"] != null)
            {
                List<DateTime> newList = (List<DateTime>)Session["SelectedDates"];
                foreach (DateTime dt in newList)
                {
                    Calendar1.SelectedDates.Add(dt);
                    TextBox1.Text = Calendar1.SelectedDate.ToShortDateString();
                    TextBox1.Text.Replace("\r\n", "<br />");
                }
                selectedDateslist.Clear();
            }
        }

        private void bindServices()
        {
            DropDownService.DataSource = null;
            DropDownService.ClearSelection();
            List<vService> Services = ServiceManager.GetservicesList();
            DropDownService.DataSource = Services;
            DropDownService.DataValueField = "SID";
            DropDownService.DataTextField = "ServiceName";
            DropDownService.DataBind();
            //DropDownHRRoles.Items.Insert(0, new ListItem("All", "0"));
            DropDownService.Items[0].Selected = true;
            _selectedServiceId = int.Parse(DropDownService.SelectedItem.Value);
        }

        protected void DropDownService_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedServiceId = int.Parse(DropDownService.SelectedItem.Value);
        }


    }
}