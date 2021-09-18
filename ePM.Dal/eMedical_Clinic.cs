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
    
    public partial class eMedical_Clinic
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public eMedical_Clinic()
        {
            this.eMedical_User = new HashSet<eMedical_User>();
            this.eMedical_Product = new HashSet<eMedical_Product>();
            this.eMedical_Service = new HashSet<eMedical_Service>();
            this.eMedical_ServiceType = new HashSet<eMedical_ServiceType>();
        }
    
        public int ID { get; set; }
        public string Clinicname { get; set; }
        public Nullable<int> HospitalID { get; set; }
        public Nullable<bool> Status { get; set; }
        public Nullable<System.DateTime> LastUpdated { get; set; }
        public Nullable<int> UpdatedByID { get; set; }
    
        public virtual eMedical_Hospital eMedical_Hospital { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<eMedical_User> eMedical_User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<eMedical_Product> eMedical_Product { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<eMedical_Service> eMedical_Service { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<eMedical_ServiceType> eMedical_ServiceType { get; set; }
    }
}
