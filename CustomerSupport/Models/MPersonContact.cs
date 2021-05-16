using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerSupport.Models
{
    public class MPersonContact
    {
        public int IdContact { get; set; }
        public int IdPerson { get; set; }
        public int IdPhoneNumberType { get; set; }
        public string IdIsoCountry { get; set; }
        public string PhoneNumber { get; set; }
        public bool Status { get; set; }
    }
}