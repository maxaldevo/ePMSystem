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
    
    public partial class vBookingTime
    {
        public int ID { get; set; }
        public Nullable<System.DateTime> BookingDate { get; set; }
        public string BookingTimeBegin { get; set; }
        public string BookingTimeEnd { get; set; }
        public Nullable<bool> IsBooked { get; set; }
        public Nullable<System.DateTime> LastUpdated { get; set; }
        public Nullable<int> ServiceID { get; set; }
        public string ServiceName { get; set; }
        public Nullable<int> UpdatedByID { get; set; }
        public string FName { get; set; }
    }
}