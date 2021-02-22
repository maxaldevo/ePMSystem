using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ePM.Dal;

namespace ePMSystem.Controls
{
    public partial class QF72201_RA257_L01A : System.Web.UI.UserControl
    {
        Contract_RA257_L01A contract_RA257L01A = new Contract_RA257_L01A();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnShowData_Click(object sender, EventArgs e)
        {
            using (ePMEntities db = new ePMEntities())
            {

                contract_RA257L01A.UserID = int.Parse(Session["UserId"].ToString());
                contract_RA257L01A.ContractDay = txt_contractday.Text;
                contract_RA257L01A.ContractValuenumber = txt_contractvaluenum.Text;
                contract_RA257L01A.ContractValueText = txt_contractvaluetext.Text;
                contract_RA257L01A.MainClient = txt_mainclient.Text;
                contract_RA257L01A.ProjectNo = txt_projno.Text;
                contract_RA257L01A.Scopeofworks = txt_scopeofwork.Text;
                contract_RA257L01A.Secondparty_Address = txt_address.Text;
                contract_RA257L01A.Secondparty_AuthpersSign = txt_AuthPer.Text;
                contract_RA257L01A.Secondparty_Compname = txt_compname.Text;
                contract_RA257L01A.Secondparty_Representative = txt_representative.Text;
                contract_RA257L01A.Secondparty_Tele = txt_tele.Text;
                contract_RA257L01A.Secondparty_Fax = txt_fax.Text;
                contract_RA257L01A.Secondparty_Email = txt_email.Text;
                contract_RA257L01A.ContractDate = Convert.ToDateTime(txt_contrractdate.Value.ToString());
                contract_RA257L01A.CurrencyCode = txt_currencycode.Text;
                contract_RA257L01A.CurrencyName = txt_currencyname.Text;
                contract_RA257L01A.AbsentPenalty = txt_absentpenality.Text;
                //contract_RA257L01A.PerformanceBond = txt_per.Text;
                contract_RA257L01A.ProjectName = txt_projname.Text;
                contract_RA257L01A.ContractTypeID = int.Parse(Session["selectedContractType"].ToString()); ;
                //if (chkb_AppendixB.Checked) subconremeature.Appendix_B = true; else subconremeature.Appendix_B = false;
                //if (chkb_AppendixC.Checked) subconremeature.Appendix_C = true; else subconremeature.Appendix_C = false;
                //if (chkb_AppendixD.Checked) subconremeature.Appendix_D = true; else subconremeature.Appendix_D = false;
                //if (chkb_AppendixE.Checked) subconremeature.Appendix_E = true; else subconremeature.Appendix_E = false;
                //if (chkb_AppendixF.Checked) subconremeature.Appendix_F = true; else subconremeature.Appendix_F = false;
                db.Contract_RA257_L01A.Add(contract_RA257L01A);
                db.SaveChanges();
                //ContContent_Appendix = GEtContractID(int.Parse(Session["UserID_Login"].ToString()));
            }
        }
    }
}