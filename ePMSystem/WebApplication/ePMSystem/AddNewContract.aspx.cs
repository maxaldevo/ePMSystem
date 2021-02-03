using ePM_Dal.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ePM.Dal.Logic;
using ePM.Dal;
using ePM_Dal.Logic;

namespace WebApplication1
{
    public partial class AddNewContract : System.Web.UI.Page
    {
        public static int _selectedContractType = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Page.Title))
            {
                Page.Title = "Courses Sessions";
            }
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
                        string currentPage = HttpContext.Current.Request.Url.LocalPath;
                        RoleId = int.Parse(Session["RoleId"].ToString());
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
                #endregion
                Panel1.Visible = true;
                //  lblResult.Visible = false;
                this.BindDropContractType();

            }
        }
        protected void btnfillform_Click(object sender, EventArgs e)
        {
            if (dropdownContractType.Items.Count > 0)
            {
                _selectedContractType = int.Parse(dropdownContractType.SelectedItem.Value);

                switch (_selectedContractType)
                {
                    case 1:
                        break;
                        UsrContrlTest.Visible = true;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    case 7:
                        break;
                    case 8:
                        break;
                    case 9:
                        break;
                    case 10:
                        break;
                    case 11:
                        break;
                    case 12:
                        break;
                    case 13:
                        break;
                    case 14:
                        break;
                    case 15:
                        break;
                    case 16:
                        break;
                    case 17:
                        break;
                    case 18:
                        break;
                    case 19:
                        break;
                    case 20:
                        break;
                    case 21:
                        break;
                    case 22:
                        break;
                    case 23:
                        break;
                }
            }
            else
            {
                Panel1.Visible = false;
                SweetAlert.showToast(this.Page, SweetAlert.ToastType.Warning, "Unable to load data", "problem loading data ", SweetAlert.ToasterPostion.TopCenter, false);
            }
        }

        private void BindDropContractType()
        {
            dropdownContractType.DataSource = null;
            dropdownContractType.ClearSelection();
            List<Contracttype> groups = ContractManager.getTypesList();
            dropdownContractType.DataSource = groups;

            dropdownContractType.DataValueField = "ID";
            dropdownContractType.DataTextField = "Contname";
            dropdownContractType.DataBind();
            dropdownContractType.Items[0].Selected = true;
            _selectedContractType = int.Parse(dropdownContractType.SelectedItem.Value);
        }



        protected void linkbManage_Click(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as LinkButton).NamingContainer as RepeaterItem;
            string _sessionId = (item.FindControl("lblID") as Label).Text;
            Response.Redirect($"~/TrainingSessionUpdate.aspx?SessionId={_sessionId}", true);
        }

        protected void linBAddSession_Click(object sender, EventArgs e)
        {
            Response.Redirect($"~/TrainingSessionDetails.aspx", true);
        }
    }
}