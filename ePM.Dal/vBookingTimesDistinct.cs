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
    
    public partial class vBookingTimesDistinct
    {
        public Nullable<System.DateTime> BookingDate { get; set; }
        public string TimeBegins { get; set; }
        public string TimeEnds { get; set; }
        public string RoomName { get; set; }
        public int ID { get; set; }
        public Nullable<bool> IsBooked { get; set; }
        public Nullable<bool> IsAvailable { get; set; }
        public Nullable<int> UpdatedByID { get; set; }
    }
}
