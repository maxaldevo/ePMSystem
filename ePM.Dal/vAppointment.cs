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
    
    public partial class vAppointment
    {
        public int UniqueID { get; set; }
        public string FName { get; set; }
        public string RoomName { get; set; }
        public string ServiceName { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<bool> CheckIN { get; set; }
        public Nullable<bool> CheckOut { get; set; }
    }
}
