using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.Demos;

namespace eMedicalSys
{
    public partial class testpage : System.Web.UI.Page
    {
        protected void Page_Init()
        {
            //DemoHelper.Instance.ControlAreaMaxWidth = Unit.Percentage(100);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            //SchedulerDemoUtils.ApplyDefaults(this, ASPxScheduler1);
            //DataHelper.SetupDefaultMappings(ASPxScheduler1);
            //DataHelper.ProvideRowInsertion(ASPxScheduler1, SqlDataSource1);
            //DataHelper.SetupStatuses(ASPxScheduler1);
            //DataHelper.SetupLabels(ASPxScheduler1);
            //if (!IsPostBack)
            //{
            //    ASPxScheduler1.DayView.FirstVisibleResourceIndex = 2;
            //    ASPxScheduler1.WorkWeekView.FirstVisibleResourceIndex = 2;
            //}
            //ASPxScheduler1.DataBind();
        }

        //protected void ASPxScheduler1_ActiveViewChanged(object sender, EventArgs e)
        //{
        //    ASPxScheduler1.DayView.WorkTime.Start = TimeSpan.FromHours(8);
        //    ASPxScheduler1.DayView.WorkTime.End = TimeSpan.FromHours(20);
        //}

        //protected void ASPxScheduler1_ActiveViewChanging(object sender, DevExpress.Web.ASPxScheduler.ActiveViewChangingEventArgs e)
        //{
        //    ASPxScheduler1.DayView.WorkTime.Start = TimeSpan.FromHours(8);
        //    ASPxScheduler1.DayView.WorkTime.End = TimeSpan.FromHours(20);
        //}
    }
}