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
    
    public partial class Contract_01_12
    {
        public int ID { get; set; }
        public string Language { get; set; }
        public string Rev { get; set; }
        public Nullable<System.DateTime> Revdate { get; set; }
        public string QualityCode { get; set; }
        public Nullable<System.DateTime> ContractDate { get; set; }
        public Nullable<int> UserID { get; set; }
        public string ContractDay { get; set; }
        public string ContractValuenumber { get; set; }
        public string ContractValueText { get; set; }
        public string Articlesdownloadsite { get; set; }
        public string Materialhandlingcapacitybygallons { get; set; }
        public string pricemovingtrail { get; set; }
        public string Primaryparty_AuthpersSign { get; set; }
        public string Primaryparty_Representative { get; set; }
        public string Secondparty_Address { get; set; }
        public string Secondparty_AuthpersSign { get; set; }
        public string Secondparty_Compname { get; set; }
        public string Secondparty_Representative { get; set; }
        public string Secondparty_Tele { get; set; }
        public string Secondparty_Email { get; set; }
        public string Secondparty_Fax { get; set; }
        public Nullable<int> ContractTypeID { get; set; }
        public Nullable<bool> Appendix_A { get; set; }
        public Nullable<bool> Appendix_B { get; set; }
        public Nullable<bool> Appendix_C { get; set; }
        public Nullable<bool> Appendix_D { get; set; }
        public Nullable<bool> Appendix_E { get; set; }
        public Nullable<bool> Appendix_F { get; set; }
        public Nullable<int> UniqueID { get; set; }
    
        public virtual Contracttype Contracttype { get; set; }
        public virtual LMS_User LMS_User { get; set; }
    }
}
