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
        public string PhoneNumberType { get; set; } //descripcion del tipo de telefono
        public string IdIsoCountry { get; set; }
        public string CountryAreaCode { get; set; } //codigo de area segun el pais seleccionado
        public string PhoneNumber { get; set; }
        public bool Status { get; set; }
    }
}