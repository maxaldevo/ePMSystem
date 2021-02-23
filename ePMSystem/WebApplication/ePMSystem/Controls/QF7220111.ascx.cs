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
    public partial class QF7220111 : System.Web.UI.UserControl
    {
    #region"Definitions"
    Contract_01_11 contract_01_11 = new Contract_01_11();
    AppendixA ObjAppendixA = new AppendixA();
    AppendixB ObjAppendixB = new AppendixB();
    AppendixC ObjAppendixC = new AppendixC();
    AppendixD ObjAppendixD = new AppendixD();
    AppendixE ObjAppendixE = new AppendixE();
    AppendixF ObjAppendixF = new AppendixF();
    ContractManager ContractM = new ContractManager();
    const int ContractTypeID = 11;
    #endregion
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}