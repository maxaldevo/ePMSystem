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
    public partial class QF72201E15 : System.Web.UI.UserControl
    {
        #region"Definitions"
        Contract_01_E15 contract_01_E15 = new Contract_01_E15();
        AppendixA ObjAppendixA = new AppendixA();
        AppendixB ObjAppendixB = new AppendixB();
        AppendixC ObjAppendixC = new AppendixC();
        AppendixD ObjAppendixD = new AppendixD();
        AppendixE ObjAppendixE = new AppendixE();
        AppendixF ObjAppendixF = new AppendixF();
        ContractManager ContractM = new ContractManager();
        const int ContractTypeID = 18;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btn_AppA_Click(object sender, EventArgs e)
        {
            //string inputContent;
            //using (StreamReader inputStreamReader = new StreamReader(FU_AppendixA.PostedFile.InputStream))
            //{
            //inputContent = inputStreamReader.ReadToEnd();
            //TextBox1.Text = inputContent;

            using (ePMEntities db = new ePMEntities())
            {
                int MaxId = ContractM.getMaxContractUniqueID(int.Parse(Session["selectedContractType"].ToString()));
                ObjAppendixA.ContractUniqueID = MaxId++;

                ObjAppendixA.Conttype = ContractM.getContractNameByTypeID(int.Parse(Session["selectedContractType"].ToString()));
                ObjAppendixA.AppendixA_Attachment = TextBox1.Text;
                db.AppendixAs.Add(ObjAppendixA);
                db.SaveChanges();
            }
            //}
        }
    }
}