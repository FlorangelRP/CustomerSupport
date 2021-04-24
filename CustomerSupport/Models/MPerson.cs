using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerSupport.Models
{
    public class MPerson
    {
        public int IdPerson { get; set; }
        public int IdPersonType { get; set; }
        public int IdIdentificationType { get; set; }
        public string NumIdentification { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public Nullable<System.DateTime> Birthday { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public Nullable<int> IdContactType { get; set; }
        public bool Status { get; set; }
    }
}