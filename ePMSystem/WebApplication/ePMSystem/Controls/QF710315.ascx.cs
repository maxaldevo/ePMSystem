using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ePM.Dal;
using ePM.Dal.Logic;

namespace ePMSystem.Controls
{
    public partial class QF710315 : System.Web.UI.UserControl
    {

        #region"Definitions"
        Contract_03_15 contract_315 = new Contract_03_15();
        AppendixA ObjAppendixA = new AppendixA();
        AppendixB ObjAppendixB = new AppendixB();
        AppendixC ObjAppendixC = new AppendixC();
        AppendixD ObjAppendixD = new AppendixD();
        AppendixE ObjAppendixE = new AppendixE();
        AppendixF ObjAppendixF = new AppendixF();
        ContractManager ContractM = new ContractManager();
        const int ContractTypeID = 6;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnShowData_Click(object sender, EventArgs e)
        {
            using (ePMEntities db = new ePMEntities())
            {
                
                contract_315.UserID = int.Parse(Session["UserId"].ToString());
                contract_315.ContractDay = txt_contractday.Text;
                contract_315.ContractValuenumber = txt_contractvaluenum.Text;
                contract_315.ContractValueText = txt_contractvaluetext.Text;
                contract_315.MainClient = txt_mainclient.Text;
                contract_315.ProjectNo = txt_projno.Text;
                contract_315.Scopeofworks = txt_scopeofwork.Text;
                contract_315.Primaryparty_Address = txt_address.Text;
                contract_315.Primaryparty_AuthpersSign = txt_AuthPer.Text;
                contract_315.Primaryparty_Compname = txt_compname.Text;
                contract_315.Primaryparty_Representative = txt_representative.Text;
                contract_315.Primaryparty_Tele = txt_tele.Text;
                contract_315.Primaryparty_Fax = txt_fax.Text;
                contract_315.Primaryparty_Email = txt_email.Text;
                contract_315.TonAsphaltPricetext = txt_TonAsphaltPricetext.Text;
                contract_315.TonAsphaltPricevalue = txt_TonAsphaltPricevalue.Text;
                contract_315.Durationofpaymentmethod = txt_Durationofpaymentmethod.Text;
                contract_315.Durationofpaymentmethodtext = txt_Durationofpaymentmethodtext.Text;
                contract_315.BalancePercentage = txt_BalancePercentage.Text;
                contract_315.ApprovalDocumentValue = txt_ApprovalDocumentValue.Text;
                contract_315.ApprovalDocumenttext = txt_ApprovalDocumenttext.Text;
                contract_315.ContractDuration = txt_ContractDuration.Text;
                contract_315.ContractTypeID = int.Parse(Session["selectedContractType"].ToString()); ;
                //if (chkb_AppendixB.Checked) subconremeature.Appendix_B = true; else subconremeature.Appendix_B = false;
                //if (chkb_AppendixC.Checked) subconremeature.Appendix_C = true; else subconremeature.Appendix_C = false;
                //if (chkb_AppendixD.Checked) subconremeature.Appendix_D = true; else subconremeature.Appendix_D = false;
                //if (chkb_AppendixE.Checked) subconremeature.Appendix_E = true; else subconremeature.Appendix_E = false;
                //if (chkb_AppendixF.Checked) subconremeature.Appendix_F = true; else subconremeature.Appendix_F = false;
                db.Contract_03_15.Add(contract_315);
                db.SaveChanges();
                //ContContent_Appendix = GEtContractID(int.Parse(Session["UserID_Login"].ToString()));
            }
        }
    }
}