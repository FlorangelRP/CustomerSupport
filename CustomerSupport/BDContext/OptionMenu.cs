//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CustomerSupport.BDContext
{
    using System;
    using System.Collections.Generic;
    
    public partial class OptionMenu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OptionMenu()
        {
            this.OptionMenu1 = new HashSet<OptionMenu>();
            this.RoleAcces = new HashSet<RoleAcces>();
            this.UserAcces = new HashSet<UserAcces>();
        }
    
        public int IdOption { get; set; }
        public string OptionName { get; set; }
        public Nullable<int> IdAssociated { get; set; }
        public string AssociatedName { get; set; }
        public bool Status { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OptionMenu> OptionMenu1 { get; set; }
        public virtual OptionMenu OptionMenu2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RoleAcces> RoleAcces { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserAcces> UserAcces { get; set; }
    }
}
