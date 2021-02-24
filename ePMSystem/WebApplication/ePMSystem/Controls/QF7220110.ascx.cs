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
    public partial class QF7220110 : System.Web.UI.UserControl
    {
        #region"Definitions"
        Contract_01_10 contract_01_10 = new Contract_01_10();
        AppendixA ObjAppendixA = new AppendixA();
        AppendixB ObjAppendixB = new AppendixB();
        AppendixC ObjAppendixC = new AppendixC();
        AppendixD ObjAppendixD = new AppendixD();
        AppendixE ObjAppendixE = new AppendixE();
        AppendixF ObjAppendixF = new AppendixF();
        ContractManager ContractM = new ContractManager();
        const int ContractTypeID = 10;
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btn_AppB_Click(object sender, EventArgs e)
        {
            using (ePMEntities db = new ePMEntities())
            {
                foreach (HttpPostedFile postedFile in FU_AppendixB.PostedFiles)
                {
                    string filename = Path.GetFileName(postedFile.FileName);
                    string fileextension = Path.GetExtension(filename);
                    string EditedPath = Server.MapPath("~/Uploads/") + Session["UserID_Login"].ToString() + "_AppendixB_ContractID" + ContractM.getMaxContractUniqueID(ContractTypeID).ToString() + Path.GetExtension(filename);
                    FU_AppendixB.PostedFile.SaveAs(EditedPath);
                    using (Stream fs = postedFile.InputStream)
                    {
                        if (fileextension == ".jpg")
                        {
                            using (BinaryReader br = new BinaryReader(fs))
                            {
                                byte[] bytes = br.ReadBytes((Int32)fs.Length);
                                ObjAppendixB.ContractUniqueID = ContractM.getMaxContractUniqueID(ContractTypeID);
                                ObjAppendixB.Conttype = ContractM.getContractNameByTypeID(ContractTypeID);
                                ObjAppendixB.AppendixB_Attachment = bytes;
                                ObjAppendixB.Path = EditedPath;
                                db.AppendixBs.Add(ObjAppendixB);
                                db.SaveChanges();
                            }
                        }
                        else if (fileextension == ".png")
                        {
                            using (BinaryReader br = new BinaryReader(fs))
                            {
                                byte[] bytes = br.ReadBytes((Int32)fs.Length);
                                ObjAppendixB.ContractUniqueID = ContractM.getMaxContractUniqueID(ContractTypeID);
                                ObjAppendixB.Conttype = ContractM.getContractNameByTypeID(ContractTypeID);
                                ObjAppendixB.AppendixB_Attachment = bytes;
                                ObjAppendixB.Path = EditedPath;
                                db.AppendixBs.Add(ObjAppendixB);
                                db.SaveChanges();
                            }
                        }
                        //    else if (fileextension == ".docx")
                        //    {
                        //        ObjAppendixB.ContractID  = HC.gettopContractID(subconremeature.UserID);
                        //        ObjAppendixB.Conttype = lbl_ContType.Text;
                        //        ObjAppendixB.Path = EditedPath;
                        //        db.AppendixBs.Add(ObjAppendixB);
                        //        db.SaveChanges();

                        //        lnkbtn_appendixB.PostBackUrl = "Contract.aspx?file=" + EditedPath;
                        //    }
                        //}


                        /////////////////////////////////////////
                        //string filename = Path.GetFileName(postedFile.FileName);
                        //using (Stream fs = postedFile.InputStream)
                        //{
                        //    using (BinaryReader br = new BinaryReader(fs))
                        //    {
                        //        byte[] bytes = br.ReadBytes((Int32)fs.Length);
                        //        ObjAppendixB.ContractID  = HC.gettopContractID(subconremeature.UserID);
                        //        ObjAppendixB.Conttype = lbl_ContType.Text;
                        //        ObjAppendixB.AppendixB_Attachment = bytes;
                        //        db.AppendixBs.Add(ObjAppendixB);
                        //        db.SaveChanges();
                        //    }
                        //}
                    }
                    //Response.Redirect(Request.Url.AbsoluteUri);
                }
            }
        }
        protected void btn_AppC_Click(object sender, EventArgs e)
        {
            if (chkb_AppendixC.Checked)
            {
                using (ePMEntities db = new ePMEntities())
                {
                    foreach (HttpPostedFile postedFile in FU_AppendixC.PostedFiles)
                    {
                        string filename = Path.GetFileName(postedFile.FileName);
                        using (Stream fs = postedFile.InputStream)
                        {
                            using (BinaryReader br = new BinaryReader(fs))
                            {
                                byte[] bytes = br.ReadBytes((Int32)fs.Length);
                                ObjAppendixB.ContractUniqueID = ContractM.getMaxContractUniqueID(ContractTypeID);
                                ObjAppendixB.Conttype = ContractM.getContractNameByTypeID(ContractTypeID);
                                ObjAppendixC.AppendixC_Attachment = bytes;
                                db.AppendixCs.Add(ObjAppendixC);
                                db.SaveChanges();
                            }
                        }
                    }
                    //Response.Redirect(Request.Url.AbsoluteUri);
                }
            }
        }
    }
}