using ePM_Dal.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;

namespace ePM_Dal.Utilities
{
  public static   class ValidateSession
    {
        public static void ValidateUserSession(Page page,string currentPage)
        {
            int userId, RoleId = 0;
            if (page.Session["UserId"] ==null)
            {
                page.Response.Redirect("~/Login/Login.aspx", true);
            }
            else
            {
                if (int.Parse(page.Session["UserId"].ToString()) != 0)
                {
                    userId = int.Parse(page.Session["UserId"].ToString());
                    RoleId = int.Parse(page.Session["RoleId"].ToString());
                    if (RoleId != 1)
                    {
                        if (!SecurityManager.isPageInRole(currentPage, RoleId))
                        {
                            page. Response.Redirect("~/Unauthorized.aspx", true);
                        }
                    }
                }
                else
                {
                    page.Response.Redirect("~/Login/Login.aspx", true);
                }
            }
        }
        public static int ValidateUserSessionGetUserId(Page page, string currentPage)
        {
            int userId = 0;int RoleId = 0;
            if (page.Session["UserId"] == null)
            {
                page.Response.Redirect("~/Login/Login.aspx", true);
            }
            else
            {
                if (int.Parse(page.Session["UserId"].ToString()) != 0)
                {
                    userId = int.Parse(page.Session["UserId"].ToString());
                    RoleId = int.Parse(page.Session["RoleId"].ToString());
                    if (RoleId != 1)
                    {
                        if (!SecurityManager.isPageInRole(currentPage, RoleId))
                        {
                            page.Response.Redirect("~/Unauthorized.aspx", true);
                        }
                    }
                }
                else
                {
                    page.Response.Redirect("~/Login/Login.aspx", true);
                }
            }
            return userId;
        }
        public static int ValidateUserSessionGetParentGroupId(Page page, string currentPage)
        {
            int userId, RoleId,groupId = 0;
            if (page.Session["UserId"] == null)
            {
                page.Response.Redirect("~/Login/Login.aspx", true);
            }
            else
            {
                if (int.Parse(page.Session["UserId"].ToString()) != 0)
                {
                    userId = int.Parse(page.Session["UserId"].ToString());
                    //this is Access RoleId, we need to get alos the HRRoleId
                    RoleId = int.Parse(page.Session["RoleId"].ToString());
                    groupId= UserManager.GetGroupIdByUserId(userId);
                    if (RoleId != 1)
                    {
                        if (!SecurityManager.isPageInRole(currentPage, RoleId))
                        {
                            page.Response.Redirect("~/Unauthorized.aspx", true);
                        }
                    }
                    else
                    {
                        groupId = 1;
                    }

                }
                else
                {
                    page.Response.Redirect("~/Login/Login.aspx", true);
                }
            }
            return groupId;
        }

    }
}
