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
    
    public partial class eMedical_Timing
    {
        public int ID { get; set; }
        public string TimingNo { get; set; }
        public string TimingBegin { get; set; }
        public string TimingEnd { get; set; }
        public Nullable<bool> Status { get; set; }
        public Nullable<System.DateTime> LastUpdated { get; set; }
        public Nullable<int> UpdatedByID { get; set; }
    }
}