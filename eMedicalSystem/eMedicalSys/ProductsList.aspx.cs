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
    public partial class ProductsList : System.Web.UI.Page
    {
        public List<vProductInfo> ProdList = new List<vProductInfo>();

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (gvProducts.Rows.Count > 0)
            {
                gvProducts.UseAccessibleHeader = true;
                gvProducts.HeaderRow.TableSection = TableRowSection.TableHeader;
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
                        if (RoleId == 1)
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

                if (ProdList.Count <= 0)
                {
                    if (Clinic_ID == 0 && userID == 0) ProdList = ProductManager.getProductsList(); else ProdList = ProductManager.getProductsList(Clinic_ID, userID);
                    Cache["ProductsList"] = ProdList;
                    Cache.Insert("ProductsList", ProdList, null, DateTime.MaxValue, TimeSpan.FromMinutes(5));
                }
                gvProducts.DataSource = ProdList;
                gvProducts.DataBind();
            }
            catch (Exception ex)
            {
                ExceptionsManager.AddException(ex);
                SweetAlert.showToast(this.Page, SweetAlert.ToastType.Error, ex.Message, "Unexpected error", SweetAlert.ToasterPostion.TopCenter, false);
            }
        }
        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            gvProducts.EditIndex = e.NewEditIndex;
            if (int.Parse(Session["RoleId"].ToString()) == 1)
            {
                BindProductsGrid(0, 0); // 0 means The SuperAdmin user.
            }
            else
            {
                
                this.BindProductsGrid(int.Parse(Session["ClinicId"].ToString()), int.Parse(Session["UserId"].ToString()));
            }
        }

        protected void OnRowCancelingEdit(object sender, EventArgs e)
        {
            gvProducts.EditIndex = -1;
            if (int.Parse(Session["RoleId"].ToString()) == 1)
            {
                BindProductsGrid(0, 0); // 0 means The SuperAdmin user.
            }
            else
            {

                this.BindProductsGrid(int.Parse(Session["ClinicId"].ToString()), int.Parse(Session["UserId"].ToString()));
            }
        }

        protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gvProducts.Rows[e.RowIndex];
            int productId = Convert.ToInt32(gvProducts.DataKeys[e.RowIndex].Values[0]);
            string txtProductName = (row.FindControl("txtPName") as TextBox).Text;
            int txtQty = int.Parse((row.FindControl("txtQty") as TextBox).Text);
            int txtCostPrice = int.Parse((row.FindControl("txtCostPrice") as TextBox).Text);
            int txtProfitPrice = int.Parse((row.FindControl("txtProfitPrice") as TextBox).Text);
            int txtSalePrice = int.Parse((row.FindControl("txtSalePrice") as TextBox).Text);
            bool isAvaialbe = (row.FindControl("chk_IsAvailable") as CheckBox).Checked;
            eMedical_Product product = new eMedical_Product()
            {
                ID = productId,
                ProductName = txtProductName,
                Qty = txtQty,
                CostPrice = txtCostPrice,
                ProfitPrice = txtProfitPrice,
                SalePrice = txtSalePrice,
                Status = isAvaialbe
            };
            ////UPDATE user productrecord
            ProductManager.updateProduct(product);
            gvProducts.EditIndex = -1;
            if (int.Parse(Session["RoleId"].ToString()) == 1)
            {
                BindProductsGrid(0, 0); // 0 means The SuperAdmin user.
            }
            else
            {

                this.BindProductsGrid(int.Parse(Session["ClinicId"].ToString()), int.Parse(Session["UserId"].ToString()));
            }
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
            var roleId = Convert.ToInt32(gvProducts.DataKeys[e.RowIndex].Values[0]);
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
                BindProductsGrid(0, 0); // 0 means The SuperAdmin user.
            }
            else
            {

                this.BindProductsGrid(int.Parse(Session["ClinicId"].ToString()), int.Parse(Session["UserId"].ToString()));
            }
        }
        protected void btnAddNewRecord_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AddNewProduct.aspx", true);
        }
    }
}