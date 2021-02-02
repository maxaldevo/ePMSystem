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
                Panel1.Visible = false;
                //  lblResult.Visible = false;
                this.BindDropContractType();

            }
        }
        protected void btnShowData_Click(object sender, EventArgs e)
        {
            if (dropdownContractType.Items.Count > 0)
            {
                _selectedContractType = int.Parse(dropdownContractType.SelectedItem.Value);

                switch (_selectedContractType)
                {
                    case 0:
                        break;
                    case 1:
                        break;
                }
            }
            else
            {
                Panel1.Visible = false;
                SweetAlert.showToast(this.Page, SweetAlert.ToastType.Warning, "Unable to load data", "problem loading data ", SweetAlert.ToasterPostion.TopCenter, false);
            }
        }


        protected void dropdownStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            //_selectedContractType = int.Parse(dropdownContractType.SelectedItem.Value);
            //this.BindDropTrainers(_selectedContractType);
            //Panel1.Visible = false;
            //lblResult.Visible = false;
        }
        private void BindDropContractType()
        {
            dropdownContractType.DataSource = null;
            dropdownContractType.ClearSelection();
            List<Contracttype> groups = ContractManager.getTypesList();
            dropdownContractType.DataSource = groups;

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