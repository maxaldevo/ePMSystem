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
    
    public partial class v_eMedical_ModulePages
    {
        public long Id { get; set; }
        public string ModuleName { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string CssClass { get; set; }
        public string IconUrl { get; set; }
        public string CssIcon { get; set; }
        public Nullable<long> ParentId { get; set; }
        public Nullable<bool> IsVisible { get; set; }
        public Nullable<int> Sort { get; set; }
        public Nullable<int> ModuleId { get; set; }
        public Nullable<int> RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
