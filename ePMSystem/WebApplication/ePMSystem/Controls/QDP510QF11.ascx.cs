using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ePMSystem.Controls
{
    public partial class QDP510QF11 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnShowData_Click(object sender, EventArgs e)
        {

            //using (ePMEntities db = new ePMEntities())
            //{

            //    contract_QF11.UserID = int.Parse(Session["UserID_Login"].ToString());
            //    contract_QF11.Secondparty_AuthpersSign = txt_SecondAuthPer.Text;
            //    contract_QF11.Primaryparty_AuthpersSign = txt_primaryAuthPer.Text;
            //    contract_QF11.AuthpersSignNationality = txt_Secondcompname.Text;
            //    contract_QF11.ContractDate = Convert.ToDateTime(txt_contrractdate.Value);
            //    DateTime pp;
            //    pp = DayOfWeek(Convert.ToDateTime(txt_contrractdate.Value));
            //    contract_QF11.ContractDay = pp.DayOfWeek.ToString();
            //    contract_QF11.ContractValuenumber = txt_contractvaluenum.Text;
            //    contract_QF11.AuthpersSignCivilID = txt_civilId.Text;
            //    //contract_QF11.ContractTypeID = ContractTypeID;
            //    contract_QF11.AuthpersSignCivilID = txt_civilId.Text;
            //    contract_QF11.materialtype = txt_materialtype.Text;
            //    contract_QF11.materialserial = txt_materialserial.Text;
            //    contract_QF11.materialmanufactureyear = txt_materialmanufactureyear.Text;
            //    contract_QF11.materialstatus = txt_materialstatus.Text;
            //    contract_QF11.bulkvalue = txt_bulkvalue.Text;
            //    contract_QF11.balancepayafterdays = txt_balancepayafterdays.Text;
            //    contract_QF11.receiveduration = txt_receiveduration.Text;
            //    db.Contract_QDP510_QF11.Add(contract_QF11);
            //    db.SaveChanges();
            //}
        }
        public static DateTime DayOfWeek(DateTime dt)
        {
            DateTime ss = new DateTime(dt.Year, dt.Month, dt.Day);
            return ss;
        }
    }
}