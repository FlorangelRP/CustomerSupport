using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerSupport.Models
{
    public class MUser
    {
        public int IdUser { get; set; }
        public int IdPerson { get; set; }
        public int IdPosition { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }
        public MPerson PersonEmployee { get; set; }

    }
}