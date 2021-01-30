using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace ePM_Dal.Utilities
{
  public static  class SweetAlert
    {
     

            public static void showToast(Page page, ToastType type, string message, string title = "", ToasterPostion position = ToasterPostion.TopRight,
                bool showCloseButton = true)
            {
                string strType = "", strPosition = "";
                switch (type)
                {
                    case ToastType.Success:
                        strType = "success";
                        break;
                    case ToastType.Info:
                        strType = "info";
                        break;
                    case ToastType.Warning:
                        strType = "warning";
                        break;
                    case ToastType.Error:
                        strType = "error";
                        break;
                    default:
                        strType = "success";
                        break;
                }

                switch (position)
                {
                    case ToasterPostion.TopRight:
                        strPosition = "toast-top-right";
                        break;
                    case ToasterPostion.TopCenter:
                        strPosition = "toast-top-center";
                        break;
                    case ToasterPostion.TopStretch:
                        strPosition = "toast-top-full-width";
                        break;
                    case ToasterPostion.TopLeft:
                        strPosition = "toast-top-left";
                        break;
                    case ToasterPostion.BottomRight:
                        strPosition = "toast-bottom-right";
                        break;

                    case ToasterPostion.BottomLeft:
                        strPosition = "toast-bottom-left";
                        break;
                    case ToasterPostion.BottomCenter:
                        strPosition = "toast-bottom-cente";
                        break;
                    default:
                        strPosition = "toast-bottom-full-width";
                        break;

                }
                //call the toastify function in the js file
                string script = "toastify('" + strType + "','" + CleanStr(message) + "','" + CleanStr(title) + "','" + strPosition + "','" + showCloseButton + "');";
                page.ClientScript.RegisterStartupScript(page.GetType(), "toastedMsg", script, true);
            }
            private static string CleanStr(string Text)
            {
                // This function replaces ' with its html code equivalent
                // in order not to terminate the js statement string
                return Text.Replace("'", "&#39;");
            }
            public enum ToastType
            {
                Success,
                Info,
                Warning,
                Error //Reserved word so we use []
            }

            public enum ToasterPostion
            {
                TopRight,
                TopLeft,
                TopCenter,
                TopStretch,
                BottomRight,
                BottomLeft,
                BottomCenter,
                BottomStretch
            }
        
    }
}
