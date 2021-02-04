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
                Page.Title = "Contract";
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
                //Panel1.Visible = true;
                //  lblResult.Visible = false;
                //shutDownAllForms();
                this.BindDropContractType();

            }
        }
        protected void btnfillform_Click(object sender, EventArgs e)
        {

        }
        void shutDownAllForms()
        {
            QDP510QF11.Visible = false;
            QDP510QF17.Visible = false;
            QF710315.Visible = false;
            QF710316.Visible = false;
            QF710405.Visible = false;
            QF7220109.Visible = false;
            QF7220110.Visible = false;
            QF7220111.Visible = false;
            QF7220112.Visible = false;
            QF72201E15.Visible = false;
            QF72201L01A.Visible = false;
            QF72201L01B.Visible = false;
            QF72201L01C.Visible = false;
            QF72201L01D.Visible = false;
            QF72201L02A.Visible = false;
            QF72201L02B.Visible = false;
            QF72201L03A.Visible = false;
            QF72201L03B.Visible = false;
            QF72201L09.Visible = false;
            QF72201L10.Visible = false;
            QF72201L12.Visible = false;
            QF72201L15.Visible = false;
            QF72201L1511.Visible = false;
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

        protected void dropdownContractType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //shutDownAllForms();
            if (dropdownContractType.Items.Count > 0)
            {
                _selectedContractType = int.Parse(dropdownContractType.SelectedItem.Value);

                //switch (_selectedContractType)
                //{
                //    case 1:
                //        QF72201L01A.Visible = true;
                //        break;
                //    case 2:
                //        QF72201L01B.Visible = true;
                //        break;
                //    case 3:
                //        QF72201L02A.Visible = true;
                //        break;
                //    case 4:
                //        QF72201L02B.Visible = true;
                //        break;
                //    case 5:
                //        QF72201L01D.Visible = true;
                //        break;
                //    case 6:
                //        QF710315.Visible = true;
                //        break;
                //    case 7:
                //        QF710316.Visible = true;
                //        break;
                //    case 8:
                //        QF710405.Visible = true;
                //        break;
                //    case 9:
                //        QF7220109.Visible = true;
                //        break;
                //    case 10:
                //        QF7220110.Visible = true;
                //        break;
                //    case 11:
                //        QF7220111.Visible = true;
                //        break;
                //    case 12:
                //        QF7220112.Visible = true;
                //        break;
                //    case 13:
                //        QF72201L12.Visible = true;
                //        break;
                //    case 14:
                //        QF72201L01C.Visible = true;
                //        break;
                //    case 15:
                //        QDP510QF11.Visible = true;
                //        break;
                //    case 16:
                //        QDP510QF17.Visible = true;
                //        break;
                //    case 17:
                //        QF72201L09.Visible = true;
                //        break;
                //    case 18:
                //        QF72201E15.Visible = true;
                //        break;
                //    case 19:
                //        QF72201L03A.Visible = true;
                //        break;
                //    case 20:
                //        QF72201L03B.Visible = true;
                //        break;
                //    case 21:
                //        QF72201L10.Visible = true;
                //        break;
                //    case 22:
                //        QF72201L15.Visible = true;
                //        break;
                //    case 23:
                //        QF72201L1511.Visible = true;
                //        break;
                //}
            }
            else
            {
                //Panel1.Visible = false;
                SweetAlert.showToast(this.Page, SweetAlert.ToastType.Warning, "Unable to load data", "problem loading data ", SweetAlert.ToasterPostion.TopCenter, false);
            }
        }
    }
}