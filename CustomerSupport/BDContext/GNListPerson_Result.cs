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
    
    public partial class GNListPerson_Result
    {
        public int IdPerson { get; set; }
        public int IdPersonType { get; set; }
        public string PersonType { get; set; }
        public int IdIdentificationType { get; set; }
        public string IdentificationType { get; set; }
        public string NumIdentification { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public Nullable<System.DateTime> Birthday { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public Nullable<int> IdContactType { get; set; }
        public string ContactType { get; set; }
        public Nullable<int> IdPosition { get; set; }
        public string Position { get; set; }
        public bool ClientPermission { get; set; }
        public bool Status { get; set; }
    }
}
