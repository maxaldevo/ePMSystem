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
    
    public partial class LMS_RolesRights
    {
        public long Id { get; set; }
        public int RoleId { get; set; }
        public long MenuItemId { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<long> CreatedBy { get; set; }
        public Nullable<long> LastUpdatedBy { get; set; }
        public Nullable<System.DateTime> LastUpdateDate { get; set; }
    
        public virtual LMS_Roles LMS_Roles { get; set; }
        public virtual LMS_Pages LMS_Pages { get; set; }
    }
}