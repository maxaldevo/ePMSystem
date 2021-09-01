using ePM.Dal;
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
    public partial class UsersList : System.Web.UI.Page
    {
        public List<vPersonnel> usersList = new List<vPersonnel>();
        
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
                if (Cache["UsersList"] == null)

                {
                    usersList = UserManager.getUsersList();
                    Cache["UsersList"] = usersList;
                    Cache.Insert("UsersList", usersList, null, DateTime.MaxValue, TimeSpan.FromMinutes(5));
                    //  Response.Write("<script>alert('Its processing from Data hit');</script>");
                }
                else

                {
                    //If cache has value, It retrive from cache memory and bind into the gridview
                    //  Response.Write("<script>alert('Its processing from cache');</script>");
                }

                gvUsers.DataSource = (List<vPersonnel>)Cache["UsersList"];
                gvUsers.DataBind();
            }
            catch (Exception ex)
            {
                ExceptionsManager.AddException(ex);
                SweetAlert.showToast(this.Page, SweetAlert.ToastType.Error, ex.Message, "Unexpected error", SweetAlert.ToasterPostion.TopCenter, false);
            }
        }
    }
}