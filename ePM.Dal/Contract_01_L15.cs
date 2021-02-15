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
    
    public partial class Contract_01_L15
    {
        public int ID { get; set; }
        public string Language { get; set; }
        public string Rev { get; set; }
        public Nullable<System.DateTime> Revdate { get; set; }
        public string QualityCode { get; set; }
        public Nullable<System.DateTime> ContractDate { get; set; }
        public string ContractDay { get; set; }
        public Nullable<int> UserID { get; set; }
        public string AbsentPenalty { get; set; }
        public string ContractValuenumber { get; set; }
        public string ContractValueText { get; set; }
        public string CurrencyCode { get; set; }
        public string CurrencyName { get; set; }
        public string DelayPenaltyValue { get; set; }
        public string DelayPenalty { get; set; }
        public string Insurance { get; set; }
        public string InsuranceValue { get; set; }
        public string MainClient { get; set; }
        public string PerformanceBond { get; set; }
        public string ProjectName { get; set; }
        public string ProjectNo { get; set; }
        public string Scopeofworks { get; set; }
        public string Secondparty_Address { get; set; }
        public string Secondparty_AuthpersSign { get; set; }
        public string Secondparty_Compname { get; set; }
        public string Secondparty_Representative { get; set; }
        public string Secondparty_Tele { get; set; }
        public string Secondparty_Email { get; set; }
        public string Secondparty_Fax { get; set; }
        public Nullable<int> ContractTypeID { get; set; }
    
        public virtual Contracttype Contracttype { get; set; }
        public virtual LMS_User LMS_User { get; set; }
    }
}
