using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ePM.Dal;
using ePM.Dal.Logic;

namespace ePMSystem.Controls
{
    public partial class QDP510QF17 : System.Web.UI.UserControl
    {
        #region"Definitions"
        Contract_QDP510_QF17 contract_QF17 = new Contract_QDP510_QF17();
        AppendixA ObjAppendixA = new AppendixA();
        AppendixB ObjAppendixB = new AppendixB();
        AppendixC ObjAppendixC = new AppendixC();
        AppendixD ObjAppendixD = new AppendixD();
        AppendixE ObjAppendixE = new AppendixE();
        AppendixF ObjAppendixF = new AppendixF();
        ContractManager ContractM = new ContractManager();
        const int ContractTypeID = 16;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnShowData_Click(object sender, EventArgs e)
        {

            using (ePMEntities db = new ePMEntities())
            {
                contract_QF17.ContractDate = Convert.ToDateTime(txt_contrractdate.Value);
                contract_QF17.UserID = int.Parse(Session["UserId"].ToString());
                contract_QF17.ContractDay = txt_contractday.Text;
                contract_QF17.ContractValuenumber = txt_contractvaluenum.Text;
                contract_QF17.Secondparty_Address = txt_address.Text;
                contract_QF17.Secondparty_AuthpersSign = txt_AuthPer.Text;
                contract_QF17.Primaryparty_AuthpersSign = txt_primaryAuthPer.Text;
                contract_QF17.Secondparty_Compname = txt_compname.Text;
                contract_QF17.Secondparty_Representative = txt_representative.Text;
                contract_QF17.Primaryparty_Representative = txt_primaryrepresentative.Text;
                contract_QF17.Secondparty_Tele = txt_tele.Text;
                contract_QF17.Secondparty_Fax = txt_fax.Text;
                contract_QF17.Secondparty_Email = txt_email.Text;
                contract_QF17.RequiredMachinetotransfer = txt_RequiredMachinetotransfer.Text;
                contract_QF17.Requiredtotransferoutofkuwait = txt_Requiredtotransferoutofkuwait.Text;
                contract_QF17.ContractTypeID = int.Parse(Session["selectedContractType"].ToString());
                db.Contract_QDP510_QF17.Add(contract_QF17);
                db.SaveChanges();
            }
        }
    }
}