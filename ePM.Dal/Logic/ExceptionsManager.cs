using ePM.Dal;
using ePM_Dal.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Validation;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace ePM_Dal.Logic
{
    public static class ExceptionsManager
    {
        public static void AddException(Exception exp)
        {
            if (exp != null)
            {
                // string exepurl = context.Current.Request.Url.ToString();
               
                LMS_ExceptionLog newExp = new LMS_ExceptionLog()
                {
                    ExceptionMsg = exp.Message,
                    ExceptionSource = exp.StackTrace,
                    ExceptionType = exp.GetType().Name.ToString(),
                    Logdate = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("Arabic Standard Time")),
                    ExceptionURL = exp.Source + " " + exp.HelpLink 
                   
                };
                using (var db = new eMedicalEntities())
                {
                    //stop logging thread abort exception
                    if (newExp.ExceptionType != "ThreadAbortException")//Thread Abort Exception
                    {
                        db.LMS_ExceptionLog.Add(newExp);
                        db.SaveChanges();
                    }
                }
            }
        }
        public static void AddExceptionDetails(Exception exp,Page page)
        {
            if (exp != null)
            {
                // string exepurl = context.Current.Request.Url.ToString();
                string environment = ConfigurationManager.AppSettings["Environment"]?.ToString();
                var guid = Guid.NewGuid();
                page.Session["GUID"] = guid.ToString();
                int? userId = null;
                if (page.Session["UserId"] !=null)
                {
                    userId = int.Parse(page.Session["UserId"].ToString());
                }
                //send email
                if (environment == "Deployment" && exp.GetType().Name.Contains("ThreadAbortException"))
                {
                 
                    EmailManager.SendMail(userId.ToString(), exp);
                }
                LMS_ExceptionLog newExp = new LMS_ExceptionLog()
                {
                    ExceptionMsg = exp.Message,UserId= userId,Environment= environment,
                    UniqueGUID = guid.ToString(),
                    ExceptionSource = exp.StackTrace,
                    ExceptionType = exp.GetType().Name.ToString(),
                    //local time of kuwait
                    Logdate = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("Arabic Standard Time")),
                    ExceptionURL = exp.Source + " " + exp.HelpLink
                };
                using (var db = new eMedicalEntities())
                {
                    //stop logging thread abort exception
                    if (newExp.ExceptionType != "ThreadAbortException")//Thread Abort Exception
                    {
                        db.LMS_ExceptionLog.Add(newExp);
                        db.SaveChanges();
                    }
                }
            }
        }
        public static void AddExceptionwithString(Exception exp, string additional_string)
        {
            if (exp != null)
            {
                // string exepurl = context.Current.Request.Url.ToString();
                LMS_ExceptionLog newExp = new LMS_ExceptionLog()
                {
                    ExceptionMsg = additional_string + "__" + exp.Message,
                    ExceptionSource = exp.StackTrace,
                    ExceptionType = exp.GetType().Name.ToString(),
                    Logdate = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("Arabic Standard Time"))
                    //  ExceptionURL = exepurl
                };
                using (var db = new eMedicalEntities())
                {
                    db.LMS_ExceptionLog.Add(newExp);
                    db.SaveChanges();
                }
            }
        }
    }
}
