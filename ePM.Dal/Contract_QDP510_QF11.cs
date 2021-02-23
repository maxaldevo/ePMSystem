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
    
    public partial class Contract_QDP510_QF11
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
        public string AuthpersSignCivilID { get; set; }
        public string Secondparty_AuthpersSign { get; set; }
        public string Primaryparty_AuthpersSign { get; set; }
        public string AuthpersSignNationality { get; set; }
        public string materialtype { get; set; }
        public string materialserial { get; set; }
        public string materialmanufactureyear { get; set; }
        public string materialstatus { get; set; }
        public string bulkvalue { get; set; }
        public string balancepayafterdays { get; set; }
        public string receiveduration { get; set; }
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
