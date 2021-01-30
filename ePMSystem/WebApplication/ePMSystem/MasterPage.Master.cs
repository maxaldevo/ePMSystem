using System;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ePM_Dal.Logic;

namespace ePMSystem
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        public string defaultImagePath = "images/avatar1.png";
        //public static   int _personnelId=0;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {

                LabelYear.Text = DateTime.Now.Year.ToString();

                int userId, RoleId = 0;
                if (Session["UserId"] == null || Session["RoleId"] == null)
                {
                    Response.Redirect("~/Login/Login.aspx", true);
                }
                else
                {
                    userId = int.Parse(Session["UserId"].ToString());
                    var user = UserManager.getSingleUser(userId);
                    if (user.PersonnelID == null)
                    {
                        Session["PersonnelId"] = userId; //(int)user.PersonnelID;
                    }
                    else
                    {
                        Session["PersonnelId"] = (int)user.PersonnelID;
                    }
                    RoleId = int.Parse(Session["RoleId"].ToString());
                    BindRepeater(int.Parse(Session["RoleId"].ToString()));
                    var u = UserProfile.GetUserByPersonnelId(int.Parse(Session["PersonnelId"].ToString()));
                    lblUserEmail.Text = u.Email;
                    lblUserName.Text = u.FName;
                    ImagePopup.ImageUrl = File.Exists(HttpContext.Current.Server.MapPath(u.ProfilePicPath))
                             ? u.ProfilePicPath : defaultImagePath;
                    ImageHeader.ImageUrl = File.Exists(HttpContext.Current.Server.MapPath(u.ProfilePicPath))
                            ? u.ProfilePicPath : defaultImagePath;

                }
            }
        }
        private void BindRepeater(int _roleId)
        {
            var data = SecurityManager.GetPagesByRoleAndLevel(_roleId, 0);
            Repeater1.DataSource = data;
            Repeater1.DataBind();
        }
        protected void ItemBound(object sender, RepeaterItemEventArgs args)
        {
            if (args.Item.ItemType == ListItemType.Item || args.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label lblmodule = (Label)args.Item.FindControl("lblModuleId");
                int moduleId = int.Parse(lblmodule.Text);
                Repeater childRepeater = (Repeater)args.Item.FindControl("ChildRepeater");
                childRepeater.DataSource = SecurityManager.GetPagesByRoleAndLevel(int.Parse(Session["RoleId"].ToString()), moduleId);
                childRepeater.DataBind();
                //childRepeater.DataSource = GetChildItems(moduleId);
                //childRepeater.DataBind();
            }
        }
        //private DataTable GetLevel0(int parentId)
        //{
        //    string query = "select  P.Id,P.ParentId, P.ModuleId,P.CssClass,P.CssIcon,  P.URL, P.Title from lms_pages P where P.ParentId = @ParentMenuId and P.IsVisible = 1";
        //    string constr = ConfigurationManager.ConnectionStrings["Smart"].ConnectionString;
        //    using (SqlConnection con = new SqlConnection(constr))
        //    {
        //        DataTable dt = new DataTable();
        //        using (SqlCommand cmd = new SqlCommand(query))
        //        {
        //            using (SqlDataAdapter sda = new SqlDataAdapter())
        //            {
        //                cmd.Parameters.AddWithValue("@ParentMenuId", parentId);
        //                cmd.CommandType = CommandType.Text;
        //                cmd.Connection = con;
        //                sda.SelectCommand = cmd;
        //                sda.Fill(dt);
        //            }
        //        }
        //        return dt;
        //    }
        //}
        //private DataTable GetChildItems(int ModuleId)
        //{
        //    string query = "select  P.Id,P.ParentId, P.ModuleId,P.CssClass,P.CssIcon,  P.URL, P.Title from lms_pages P where P.ModuleId = @ModuleId and P.ParentId != 0 and P.IsVisible = 1";
        //    string constr = ConfigurationManager.ConnectionStrings["Smart"].ConnectionString;
        //    using (SqlConnection con = new SqlConnection(constr))
        //    {
        //        DataTable dt = new DataTable();
        //        using (SqlCommand cmd = new SqlCommand(query))
        //        {
        //            using (SqlDataAdapter sda = new SqlDataAdapter())
        //            {
        //                cmd.Parameters.AddWithValue("@ModuleId", ModuleId);
        //                cmd.CommandType = CommandType.Text;
        //                cmd.Connection = con;
        //                sda.SelectCommand = cmd;
        //                sda.Fill(dt);
        //            }
        //        }
        //        return dt;
        //    }
        //}
        //Logout BTN
        protected void LinB1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login/Login.aspx");

        }
    }
}