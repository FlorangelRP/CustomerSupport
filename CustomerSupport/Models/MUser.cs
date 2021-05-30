using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CustomerSupport.Models
{
    public class MUser
    {
        public int IdUser { get; set; }
        public int IdPerson { get; set; }

        [Required(ErrorMessage = "Debe indicar el Login.")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Debe indicar la Contraseña.")]
        public string Password { get; set; }
        public bool Status { get; set; }
        public string StatusDesc { get; set; } //descripcion del estado (Activo/Inactivo)

        [Required(ErrorMessage = "Debe indicar la Persona.")]
        public MPerson PersonEmployee { get; set; }

        public List<MUserAcces> UserAccesPadre { get; set; }
        public List<MUserAcces> UserAcces { get; set; }

    }
}