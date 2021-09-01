using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ePM_Dal.Logic;

namespace ePMSystem
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserId"] == null)
                {
                    Response.Redirect("~/Login/Login.aspx", false);
                }
                else
                {
                    if (int.Parse(Session["UserId"].ToString()) != 0)
                    {
                        var user = PersonnelManager.GetSingleByUserId(int.Parse(Session["UserId"].ToString()));
                        if (user != null)
                        {
                            lblUser.Text = user.FName;
                        }
                        else
                        {
                            Response.Redirect("~/Login/Login.aspx", true);
                        }
                    }
                    else
                    {
                        Response.Redirect("~/Login/Login.aspx", true);
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
            }

        }



        protected void linkFeedback_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/FeedbackCourseByUser.aspx", false);

        }

        protected void ImageButtonTaining_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/CLACourses_Trainee.aspx", false);
        }


        //protected void ImageButtonAssessment_Click(object sender, ImageClickEventArgs e)
        //{
        //    // Response.Redirect("https://kipiclms.azurewebsites.net/", false);
        //    Response.Redirect("ClassroomAssessmentByUser.aspx",false);
        //}

        protected void ImageButtonELearning_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/Courses.aspx", false);
        }

        protected void ImageButtonAssessment2_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/ClassroomAssessmentByUser.aspx", false);
        }

        protected void ImageButtonOJT_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/OJTTrainingStatus.aspx", false);
        }

        protected void ImageButtonOTS_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/OTSTrainingStatus.aspx", false);
        }
    }
}