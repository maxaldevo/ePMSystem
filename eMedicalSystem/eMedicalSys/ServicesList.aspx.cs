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
                        else if (RoleId == 1)
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
                if (Cache["ServicessList"] == null)
                {
                    if (Clinic_ID == 0 && userID == 0) ServiceList = ServiceManager.GetservicesList(); else ServiceList = ServiceManager.GetservicesList(Clinic_ID, userID);
                    Cache["ServicessList"] = ServiceList;
                    Cache.Insert("ServicessList", ServiceList, null, DateTime.MaxValue, TimeSpan.FromMinutes(5));
                }
                gvServices.DataSource = (List<vService>)Cache["ServicessList"];
                gvServices.DataBind();
            }
            catch (Exception ex)
            {
                ExceptionsManager.AddException(ex);
                SweetAlert.showToast(this.Page, SweetAlert.ToastType.Error, ex.Message, "Unexpected error", SweetAlert.ToasterPostion.TopCenter, false);
            }
        }
    }
}