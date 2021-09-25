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
    public partial class ServiceTypesList : System.Web.UI.Page
    {
        public List<vServiceType> ServiceTypeList = new List<vServiceType>();

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (gvServiceTypes.Rows.Count > 0)
            {
                gvServiceTypes.UseAccessibleHeader = true;
                gvServiceTypes.HeaderRow.TableSection = TableRowSection.TableHeader;
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
                            BindServiceTypesGrid(0, 0); // 0 means The SuperAdmin user.
                        }
                        else
                        {
                            ClinicId = int.Parse(Session["ClinicId"].ToString());
                            BindServiceTypesGrid(ClinicId, userId);
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

        private void BindServiceTypesGrid(int Clinic_ID, int userID)
        {
            try
            {
                if (Cache["ServiceTypeList"] == null)
                {
                    if (Clinic_ID == 0 && userID == 0) ServiceTypeList = ServiceManager.GetservicesTypeList(); else ServiceTypeList = ServiceManager.GetservicesTypeList(Clinic_ID, userID);
                    Cache["ServiceTypeList"] = ServiceTypeList;
                    Cache.Insert("ServiceTypeList", ServiceTypeList, null, DateTime.MaxValue, TimeSpan.FromMinutes(5));
                }
                gvServiceTypes.DataSource = (List<vServiceType>)Cache["ServiceTypeList"];
                gvServiceTypes.DataBind();
            }
            catch (Exception ex)
            {
                ExceptionsManager.AddException(ex);
                SweetAlert.showToast(this.Page, SweetAlert.ToastType.Error, ex.Message, "Unexpected error", SweetAlert.ToasterPostion.TopCenter, false);
            }
        }
        protected void btnAddNewRecord_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AddNewServiceType.aspx", true);
        }
    }
}