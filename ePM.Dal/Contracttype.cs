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
    
    public partial class Contracttype
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Contracttype()
        {
            this.Contract_01_09 = new HashSet<Contract_01_09>();
            this.Contract_01_10 = new HashSet<Contract_01_10>();
            this.Contract_01_11 = new HashSet<Contract_01_11>();
            this.Contract_01_12 = new HashSet<Contract_01_12>();
            this.Contract_01_E15 = new HashSet<Contract_01_E15>();
            this.Contract_01_L01C = new HashSet<Contract_01_L01C>();
            this.Contract_01_L03A = new HashSet<Contract_01_L03A>();
            this.Contract_01_L03B = new HashSet<Contract_01_L03B>();
            this.Contract_01_L09 = new HashSet<Contract_01_L09>();
            this.Contract_01_L10 = new HashSet<Contract_01_L10>();
            this.Contract_01_L12 = new HashSet<Contract_01_L12>();
            this.Contract_01L15 = new HashSet<Contract_01L15>();
            this.Contract_01_L15 = new HashSet<Contract_01_L15>();
            this.Contract_03_15 = new HashSet<Contract_03_15>();
            this.Contract_03_16 = new HashSet<Contract_03_16>();
            this.Contract_04_05 = new HashSet<Contract_04_05>();
            this.Contract_L01A = new HashSet<Contract_L01A>();
            this.Contract_L01B = new HashSet<Contract_L01B>();
            this.Contract_L01D = new HashSet<Contract_L01D>();
            this.Contract_L02A = new HashSet<Contract_L02A>();
            this.Contract_L02B = new HashSet<Contract_L02B>();
            this.Contract_QDP510_QF11 = new HashSet<Contract_QDP510_QF11>();
            this.Contract_QDP510_QF17 = new HashSet<Contract_QDP510_QF17>();
        }
    
        public int ID { get; set; }
        public string Contname { get; set; }
        public string ContType { get; set; }
        public string Lang { get; set; }
        public string QualityCode { get; set; }
        public Nullable<System.DateTime> RevDate { get; set; }
        public string Notes { get; set; }
        public string Revno { get; set; }
        public Nullable<bool> Active { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contract_01_09> Contract_01_09 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contract_01_10> Contract_01_10 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contract_01_11> Contract_01_11 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contract_01_12> Contract_01_12 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contract_01_E15> Contract_01_E15 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contract_01_L01C> Contract_01_L01C { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contract_01_L03A> Contract_01_L03A { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contract_01_L03B> Contract_01_L03B { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contract_01_L09> Contract_01_L09 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contract_01_L10> Contract_01_L10 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contract_01_L12> Contract_01_L12 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contract_01L15> Contract_01L15 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contract_01_L15> Contract_01_L15 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contract_03_15> Contract_03_15 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contract_03_16> Contract_03_16 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contract_04_05> Contract_04_05 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contract_L01A> Contract_L01A { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contract_L01B> Contract_L01B { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contract_L01D> Contract_L01D { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contract_L02A> Contract_L02A { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contract_L02B> Contract_L02B { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contract_QDP510_QF11> Contract_QDP510_QF11 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Contract_QDP510_QF17> Contract_QDP510_QF17 { get; set; }
    }
}
