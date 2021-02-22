//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ePM.Dal
{
    using System;
    using System.Collections.Generic;
    
    public partial class Contract_03_15
    {
        public int ID { get; set; }
        public string Language { get; set; }
        public string Rev { get; set; }
        public Nullable<System.DateTime> Revdate { get; set; }
        public string QualityCode { get; set; }
        public Nullable<System.DateTime> ContractDate { get; set; }
        public string ContractDay { get; set; }
        public Nullable<int> UserID { get; set; }
        public string ContractValuenumber { get; set; }
        public string ContractValueText { get; set; }
        public string MainClient { get; set; }
        public string ProjectNo { get; set; }
        public string Scopeofworks { get; set; }
        public string Primaryparty_Address { get; set; }
        public string Primaryparty_AuthpersSign { get; set; }
        public string Primaryparty_Compname { get; set; }
        public string Primaryparty_Representative { get; set; }
        public string Primaryparty_Tele { get; set; }
        public string Primaryparty_Fax { get; set; }
        public string Primaryparty_Email { get; set; }
        public string TonAsphaltPricetext { get; set; }
        public string TonAsphaltPricevalue { get; set; }
        public string Durationofpaymentmethod { get; set; }
        public string Durationofpaymentmethodtext { get; set; }
        public string BalancePercentage { get; set; }
        public string ApprovalDocumentValue { get; set; }
        public string ApprovalDocumenttext { get; set; }
        public string ContractDuration { get; set; }
        public Nullable<int> ContractTypeID { get; set; }
        public Nullable<bool> Appendix_A { get; set; }
        public Nullable<bool> Appendix_B { get; set; }
        public Nullable<bool> Appendix_C { get; set; }
        public Nullable<bool> Appendix_D { get; set; }
        public Nullable<bool> Appendix_E { get; set; }
        public Nullable<bool> Appendix_F { get; set; }
    
        public virtual Contracttype Contracttype { get; set; }
        public virtual LMS_User LMS_User { get; set; }
    }
}
