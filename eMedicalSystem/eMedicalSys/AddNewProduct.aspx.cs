using ePM.Dal;
using ePM.Dal.Logic;
using ePM_Dal.Logic;
using ePM_Dal.Utilities;
using ePM_Dal.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Caching;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class AddNewProduct : System.Web.UI.Page
    {
        public static string  _pName;
        public static int _qty, _costPrice, _profitPrice, _salePrice, _clinicId, _hospitalID, _userID, _selectedHospital, _selectedClinic = 0;
        //public List<vProductInfo> ProductsList = new List<vProductInfo>();

        //protected void Page_PreRender(object sender, EventArgs e)
        //{
        //    if (gvProducts.Rows.Count > 0)
        //    {
        //        gvProducts.UseAccessibleHeader = true;
        //        gvProducts.HeaderRow.TableSection = TableRowSection.TableHeader;
        //    }
        //}
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                #region Page Validation

                int RoleId = 0;
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
                        _clinicId = int.Parse(Session["ClinicId"].ToString());
                        _hospitalID = int.Parse(Session["HospitalID"].ToString());
                        if (RoleId == 1)
                        {
                            BindHospitals();
                            BindClinics(_selectedHospital);
                            DropDownClinics.Visible = true;
                            DropDownHospitals.Visible = true;
                        }
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
                
            }
        }
        protected void btnShowData_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {

                    _pName = txtPName.Text;
                    _qty = int.Parse(txtqty.Text);
                    _costPrice = int.Parse(txtCPrice.Text);
                    _profitPrice = int.Parse(txtProfitPrice.Text);
                    _salePrice = int.Parse(txtSalePrice.Text);
                    string result = "";

                    if (_selectedHospital > 0 && _selectedClinic > 0)
                    {
                        result = ProductManager.AddNewProduct_By_HospitalID_ClinicID(_pName, _qty, _costPrice, _profitPrice, _salePrice, _userID, _selectedHospital, _selectedClinic);
                    }
                    else
                    {
                        result = ProductManager.AddNewProduct_By_HospitalID_ClinicID(_pName, _qty, _costPrice, _profitPrice, _salePrice, _userID, _hospitalID, _clinicId);
                    }
                    
                    if (result != "inserted")
                    {
                        lblResult.Visible = true;
                        lblResult.ForeColor = System.Drawing.Color.Red;
                        lblResult.Text = result;
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Error", "<script>showpoperror('" + result + " Please contact your Admin!" + "')</script>", false);
                    }
                    else
                    {
                        lblResult.Visible = true;
                        lblResult.ForeColor = System.Drawing.Color.Green;
                        lblResult.Text = result;
                        clearControls();
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Success", "<script>showpopsuccess('" + "User added successfully!" + "')</script>", false);
                        //Re-Bind the user grid based on the User's role.
                        //if (int.Parse(Session["RoleId"].ToString()) == 1) BindProductsGrid(0, 0); else BindProductsGrid(int.Parse(Session["ClinicId"].ToString()), int.Parse(Session["UserId"].ToString()));
                    }


                }
                catch (Exception ex)
                {

                    ScriptManager.RegisterStartupScript(this, typeof(Page), "unexpected error", "<script>showpoperror('" + "Unexpected error, Please contact your Admin!" + ex.Message + "')</script>", false);
                }

            }

        }
        private void clearControls()
        {
            txtPName.Text = "";
            txtqty.Text = "";
            txtCPrice.Text = "";
            txtProfitPrice.Text = "";
            txtSalePrice.Text = "";
            // lblResult.Visible = false;
        }


        //private void BindProductsGrid(int Clinic_ID, int userID)
        //{
        //    try
        //    {
        //        if (Cache["ProductsList"] == null)
        //        {
        //            if (Clinic_ID == 0 && userID == 0) ProductsList = ProductManager.getProductsList(); else ProductsList = ProductManager.getProductsList(Clinic_ID, userID);
        //            Cache["ProductsList"] = ProductsList;
        //            Cache.Insert("ProductsList", ProductsList, null, DateTime.MaxValue, TimeSpan.FromMinutes(5));
        //        }
        //        gvProducts.DataSource = (List<vProductInfo>)Cache["ProductsList"];
        //        gvProducts.DataBind();
        //    }
        //    catch (Exception ex)
        //    {
        //        ExceptionsManager.AddException(ex);
        //        SweetAlert.showToast(this.Page, SweetAlert.ToastType.Error, ex.Message, "Unexpected error", SweetAlert.ToasterPostion.TopCenter, false);
        //    }
        //}


        private void BindHospitals()
        {
            DropDownHospitals.DataSource = null;
            DropDownHospitals.ClearSelection();
            List<eMedical_Hospital> Hospitals = ClinicManager.GetHospitalsList();
            DropDownHospitals.DataSource = Hospitals;
            DropDownHospitals.DataValueField = "ID";
            DropDownHospitals.DataTextField = "HospitalName";
            DropDownHospitals.DataBind();
            //DropDownHRRoles.Items.Insert(0, new ListItem("All", "0"));
            DropDownHospitals.Items[0].Selected = true;
            _selectedHospital = int.Parse(DropDownHospitals.SelectedItem.Value);
        }
        private void BindClinics(int selectedHospital)
        {
            DropDownClinics.DataSource = null;
            DropDownClinics.ClearSelection();
            List<eMedical_Clinic> Clinics = ClinicManager.GetClinicsList(selectedHospital);
            DropDownClinics.DataSource = Clinics;
            DropDownClinics.DataValueField = "ID";
            DropDownClinics.DataTextField = "ClinicName";
            DropDownClinics.DataBind();
            //DropDownHRRoles.Items.Insert(0, new ListItem("All", "0"));
            DropDownClinics.Items[0].Selected = true;
            _selectedClinic = int.Parse(DropDownClinics.SelectedItem.Value);
        }

        protected void DropDownHospitals_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedHospital = int.Parse(DropDownHospitals.SelectedItem.Value);
            BindClinics(_selectedHospital);
        }

        protected void DropDownClinics_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedClinic = int.Parse(DropDownClinics.SelectedItem.Value);
        }

    }
}