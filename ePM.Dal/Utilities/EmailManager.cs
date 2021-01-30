using ePM_Dal.Logic;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Configuration;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ePM_Dal.Utilities
{
    public static class EmailManager
    {
        public static bool SendMail(string _userName, Exception excep)
        {
            bool result = false;
            const string ToAddress = "muhammadmahmoud.mabrouk@snclavalin.com";
            //m.corresponds@gmail.com
            // const string FromAddress = "elms.snc@gmail.com";
            const string Subject = "unexpecter issue in ELMS!";
            string exceptionMessage = excep.Message;
            if (excep.InnerException != null)
            {
                exceptionMessage += " " + excep.InnerException.Message;
            }
            try
            {
                SmtpSection smtpSection = (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");
                using (MailMessage mailMsg = new MailMessage(smtpSection.From, ToAddress))
                {
                    mailMsg.Subject = Subject;
                    mailMsg.Priority = MailPriority.High;
                    mailMsg.IsBodyHtml = true;
                    mailMsg.CC.Add("m.shaker@kipic.com.kw");
                    mailMsg.CC.Add("mm.mabrouk@kipic.com.kw");
                    // mailMsg.CC.Add("m.mabrouk88@gamil.com");
                    mailMsg.Body = string.Format(@"
                                                    <html>
                                                    <body>
                                                      <h3>Unexpected issue in ELMS!</h3>
                                                      <table cellpadding=""5"" cellspacing=""0"" border=""1"">
                                                      <tr>
                                                      <tdtext-align: right;font-weight: bold"">URL:</td>
                                                      <td>{0}</td>
                                                      </tr>
                                                      <tr>
                                                      <tdtext-align: right;font-weight: bold"">User:</td>
                                                      <td>{1}</td>
                                                      </tr>
                                                      <tr>
                                                      <tdtext-align: right;font-weight: bold"">Exception Type:</td>
                                                      <td>{2}</td>
                                                      </tr>
                                                      <tr>
                                                      <tdtext-align: right;font-weight: bold"">Message:</td>
                                                      <td>{3}</td>
                                                      </tr>
                                                      <tr>
                                                      <tdtext-align: right;font-weight: bold"">Stack Trace:</td>
                                                      <td>{4}</td>
                                                      </tr> 
                                                      </table>
                                                    </body>
                                                    </html>",
                                                   excep.HelpLink,
                                                  _userName,
                                                   excep.GetType().ToString(),
                                                   exceptionMessage,
                                                   excep.StackTrace.Replace(Environment.NewLine, "<br />"));
                    if (!exceptionMessage.Contains("Thread was being aborted"))
                    {
                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = smtpSection.Network.Host;
                        smtp.EnableSsl = smtpSection.Network.EnableSsl;
                        NetworkCredential networkCred = new NetworkCredential(smtpSection.Network.UserName, smtpSection.Network.Password);
                        smtp.UseDefaultCredentials = smtpSection.Network.DefaultCredentials;
                        smtp.Credentials = networkCred;
                        smtp.Port = smtpSection.Network.Port;
                        smtp.Send(mailMsg);
                        result = true;
                    }
            
                }
            }
            catch (SmtpException e)
            {
                ExceptionsManager.AddExceptionwithString(e,"Problem sending eamil, Status code : " + e.StatusCode.ToString());
            }
            catch (Exception ex)
            {

                ExceptionsManager.AddException(ex);
            }

            return result;
        }
    }
}
