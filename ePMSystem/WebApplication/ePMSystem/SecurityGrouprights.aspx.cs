using ePM.Dal;
using ePM_Dal.Logic;
using ePM_Dal.Utilities;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class SecurityGrouprights : System.Web.UI.Page
    {
        public static string _selectedGroup = "";
        public DateTime _selectedDate;
        public static int pageId, _selectedGroupId = 0;
        public string trainer, comments = "";
        public string timein, timeout = null;
        public static List<eMedical_RolesRights> _DeleterolesRights;
        public static List<eMedical_RolesRights> _InsertRolesRights;

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

                //#region Page Validation

                Panel1.Visible = false;
                lblResult.Visible = false;
                this.BindDropGroups();
                _DeleterolesRights = new List<eMedical_RolesRights>();
                _InsertRolesRights = new List<eMedical_RolesRights>();
            }
        }

        private void BindDropGroups()
        {
            dropdownGroups.DataSource = null;
            dropdownGroups.ClearSelection();
            List<eMedical_Roles> groups = SecurityManager.Get_Roles();
            dropdownGroups.DataSource = groups;
            dropdownGroups.DataValueField = "RoleId";
            dropdownGroups.DataTextField = "RoleName";
            dropdownGroups.DataBind();
            dropdownGroups.Items[0].Selected = true;
            _selectedGroupId = int.Parse(dropdownGroups.SelectedItem.Value);
            _selectedGroup = dropdownGroups.SelectedItem.Text;
        }

        protected void dropdownGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedGroupId = int.Parse(dropdownGroups.SelectedItem.Value);
            _selectedGroup = dropdownGroups.SelectedItem.Text;
            Panel1.Visible = false;
            lblResult.Visible = false;
        }

        protected void btnShowData_Click(object sender, EventArgs e)
        {
            this.BindGrid(_selectedGroupId);

            if (Repeater1.Items.Count > 0)
            {
                Panel1.Visible = true;
            }
            else
            {
                Panel1.Visible = false;
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Unexpected error", "<script>showpopwarning('" + "No records found!" + "')</script>", false);
                SweetAlert.showToast(this.Page, SweetAlert.ToastType.Warning, "No Records  found!", "No Data", SweetAlert.ToasterPostion.TopCenter, false);
            }
        }

        protected void chkSelect_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            RepeaterItem item = (RepeaterItem)chk.NamingContainer;
            string ModuleId = ((Label)item.FindControl("lblModuleId")).Text;
            string ParentId = ((Label)item.FindControl("lblParentId")).Text;
            if (ParentId != "0")
            {
                foreach (RepeaterItem row in Repeater1.Items)
                {
                    string ModuleIdInner = ((Label)row.FindControl("lblModuleId")).Text;
                    string ParentIdInner = ((Label)row.FindControl("lblParentId")).Text;
                    CheckBox checkBox = (CheckBox)row.FindControl("chkSelect");
                    if (ModuleIdInner == ModuleId && ParentIdInner =="0")
                    {
                        if (checkBox.Checked ==false)
                        {
                            checkBox.Checked = true;
                        }
                    }
                }
            }
            else if(ParentId == "0" && chk.Checked == true)
            {
                foreach (RepeaterItem row in Repeater1.Items)
                {
                    string ModuleIdInner = ((Label)row.FindControl("lblModuleId")).Text;
                    string ParentIdInner = ((Label)row.FindControl("lblParentId")).Text;
                    CheckBox checkBox = (CheckBox)row.FindControl("chkSelect");
                    if (ModuleIdInner == ModuleId && ParentIdInner != "0")
                    {
                        if (checkBox.Checked == false)
                        {
                            checkBox.Checked = true;
                        }
                    }
                }

            }
            else if (ParentId == "0" && chk.Checked==false)
            {
                foreach (RepeaterItem row in Repeater1.Items)
                {
                    string ModuleIdInner = ((Label)row.FindControl("lblModuleId")).Text;
                    string ParentIdInner = ((Label)row.FindControl("lblParentId")).Text;
                    CheckBox checkBox = (CheckBox)row.FindControl("chkSelect");
                    if (ModuleIdInner == ModuleId && ParentIdInner != "0")
                    {
                            checkBox.Checked = false;
                    }
                }

            }

        }

        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                foreach (Control c in e.Item.Controls)
                {
                    if (c is System.Web.UI.HtmlControls.HtmlTableRow)
                    {
                        HtmlTableRow tr = (HtmlTableRow)c;
                        foreach (Control c1 in tr.Controls)
                        {
                            Label lblParent = (Label)c1.FindControl("lblParentId");
                            if (int.Parse(lblParent.Text) == 0)
                            {
                                tr.BgColor = "#a9a9a9";
                                tr.BorderColor = "Black";
                                tr.Attributes["style"] = "Color: white;";
                                tr.Attributes["style"] = "font-weight: bolder;";
                            }
                            else
                            {
                                tr.BgColor = "#e4e1e1";
                            }
                        }
                    }
                }
            }
        }

        private void BindGrid(int group)
        {
            var data = SecurityManager.GetMS_PagesByRole(group);
            Repeater1.DataSource = data;
            Repeater1.DataBind();
            Repeater1.Visible = true;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    _InsertRolesRights.Clear();
                    _DeleterolesRights.Clear();
                    _selectedGroupId = int.Parse(dropdownGroups.SelectedItem.Value);
                    foreach (RepeaterItem item in Repeater1.Items)
                    {
                        Label lblPageId = item.FindControl("lblId") as Label;
                        Label lblRoleId = item.FindControl("lblRoleId") as Label;
                        Label lblRRId = item.FindControl("lblRRId") as Label;
                        int? RRId = 0;
                        if (!string.IsNullOrWhiteSpace(lblRRId.Text))
                        {
                            RRId = int.Parse(lblRRId.Text);
                        }
                        if (RRId == 0)
                        {
                            RRId = null;
                        }
                        CheckBox check = item.FindControl("chkSelect") as CheckBox;
                       
                        pageId = int.Parse(lblPageId.Text);
                        DateTime insertDate = DateTime.Now;
                        if ( RRId !=null & check.Checked ==false)//Delete Records
                        {
                            eMedical_RolesRights newRecord = new eMedical_RolesRights()
                            {
                                MenuItemId = pageId,
                                Id = (int)RRId,
                                RoleId = _selectedGroupId,
                                CreateDate = insertDate,
                                LastUpdateDate = insertDate,
                                LastUpdatedBy = int.Parse(Session["UserId"].ToString())
                            };
                            _DeleterolesRights.Add(newRecord);
                        }
                        else if( RRId ==null & check.Checked ==true)
                        {
                            eMedical_RolesRights newRecord = new eMedical_RolesRights()
                            {
                                MenuItemId = pageId,
                                RoleId = _selectedGroupId,
                                CreateDate = insertDate,
                                LastUpdateDate = insertDate,
                                LastUpdatedBy = int.Parse(Session["UserId"].ToString())
                            };
                            _InsertRolesRights.Add(newRecord);
                        }
                      
                    }
                    bool afftected = false;
                    if (_InsertRolesRights.Count > 0 && _DeleterolesRights.Count == 0)
                    {
                         afftected = SecurityManager.AddRolesRights(_InsertRolesRights);

                    }
                    else if (_InsertRolesRights.Count > 0 && _DeleterolesRights .Count > 0)
                    {
                        afftected = SecurityManager.AddOrDeleteRolesRights(_InsertRolesRights,_DeleterolesRights);

                    }
                    else if (_DeleterolesRights.Count > 0 && _InsertRolesRights.Count ==0)
                    {
                        afftected = SecurityManager.AddOrDeleteRolesRights(_InsertRolesRights, _DeleterolesRights);
                    }

                    if (afftected)
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Data Saved", "<script>showpopsuccess('" + "Data Saved successfully! " + afftected.ToString() + " records inserted." + "')</script>", false);
                        SweetAlert.showToast(this.Page, SweetAlert.ToastType.Success, "Data inserted successfully", "Data saved", SweetAlert.ToasterPostion.TopCenter, false);
                        lblResult.Text = "Records inserted successfully";
                        lblResult.ForeColor = System.Drawing.Color.Green;
                        lblResult.Visible = true;
                        Panel1.Visible = false;
                        BindDropGroups();
                    }
                    else if (afftected == false)
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), $"Unexpected error", "<script>showpoperror('" + "Problem saving data" + "')</script>", false);
                        SweetAlert.showToast(this.Page, SweetAlert.ToastType.Error, "The Records already exist. Please contact  your admin!", "Unexpected error", SweetAlert.ToasterPostion.TopCenter, false);
                        lblResult.Text = "Please Note that those records already exist";
                        lblResult.ForeColor = System.Drawing.Color.Red;
                        lblResult.Visible = true;

                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.HelpLink == null)
                {
                    ex.HelpLink = HttpContext.Current.Request.Url.LocalPath;
                }
                ExceptionsManager.AddExceptionDetails(ex, new Page());
                ScriptManager.RegisterStartupScript(this, typeof(Page), "Unexpected error", "<script>showpoperror('" + "Please contact  your admin! " + ex.Message + "')</script>", false);
                SweetAlert.showToast(this.Page, SweetAlert.ToastType.Error, "Unexpected error, please contact  your admin", "Unexpected error", SweetAlert.ToasterPostion.TopCenter, false);
                lblResult.Text = "Unexpected error, please contact  your admin";
                lblResult.ForeColor = System.Drawing.Color.Red;
                lblResult.Visible = true;
                return;
            }
        }
        protected void selectall_CheckedChanged(object sender, System.EventArgs e)
        {
            CheckBox select_all = (CheckBox)(Control)sender;

            foreach (RepeaterItem row in Repeater1.Items)
            {
                CheckBox chckrw = (CheckBox)row.FindControl("chkSelect");
                if (select_all.Checked == true)
                {
                    chckrw.Checked = true;
                }
                else
                {
                    chckrw.Checked = false;
                }
            }
        }
    }
}