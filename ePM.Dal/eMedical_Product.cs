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
    
    public partial class eMedical_Product
    {
        public int ID { get; set; }
        public string ProductName { get; set; }
        public Nullable<int> Qty { get; set; }
        public Nullable<int> CostPrice { get; set; }
        public Nullable<int> ProfitPrice { get; set; }
        public Nullable<int> SalePrice { get; set; }
        public Nullable<int> HospitalID { get; set; }
        public Nullable<int> ClinicID { get; set; }
        public Nullable<bool> Status { get; set; }
        public Nullable<System.DateTime> LastUpdated { get; set; }
        public Nullable<int> UpdatedByID { get; set; }
    
        public virtual eMedical_Clinic eMedical_Clinic { get; set; }
        public virtual eMedical_Hospital eMedical_Hospital { get; set; }
    }
}
