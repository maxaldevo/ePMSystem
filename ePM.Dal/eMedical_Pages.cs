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
    
    public partial class eMedical_Pages
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public eMedical_Pages()
        {
            this.eMedical_RolesRights = new HashSet<eMedical_RolesRights>();
        }
    
        public long Id { get; set; }
        public Nullable<long> ParentId { get; set; }
        public Nullable<int> ModuleId { get; set; }
        public string Url { get; set; }
        public string SearchUrl { get; set; }
        public string HelpUrl { get; set; }
        public string UniqueName { get; set; }
        public string Title { get; set; }
        public string IconUrl { get; set; }
        public string CssClass { get; set; }
        public Nullable<int> Sort { get; set; }
        public Nullable<bool> IsVisible { get; set; }
        public string CssIcon { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<eMedical_RolesRights> eMedical_RolesRights { get; set; }
    }
}