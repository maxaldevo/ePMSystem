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
    
    public partial class eMedical_Room
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public eMedical_Room()
        {
            this.eMedical_Service = new HashSet<eMedical_Service>();
        }
    
        public int ID { get; set; }
        public string RoomName { get; set; }
        public Nullable<bool> Status { get; set; }
        public Nullable<System.DateTime> LastUpdated { get; set; }
        public Nullable<int> UpdatedByID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<eMedical_Service> eMedical_Service { get; set; }
    }
}