using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CustomerSupport.Models
{
    public class MPerson
    {
        public MPerson() 
        {
            listPersonContact = new List<MPersonContact>();
        }
        public int IdPerson { get; set; }
        public int IdPersonType { get; set; }
        public string PersonType { get; set; } //descripcion del tipo de persona

        [Required(ErrorMessage = "Seleccione un tipo de identificacion.")]
        public int IdIdentificationType { get; set; }        
        public string IdentificationType { get; set; } //descripcion del tipo de identificacion
        [Required(ErrorMessage = "Ingrese el numero identificacion.")]
        public string NumIdentification { get; set; }

        [Required(ErrorMessage = "Debe Ingresar Nombres.")]
        [StringLength(100, ErrorMessage = "Nombres no puede tener mas de 100 caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Debe Ingresar Apellidos.")]
        [StringLength(100, ErrorMessage = "Apellidos no puede tener mas de 100 caracteres.")]
        public string LastName { get; set; }

        public Nullable<System.DateTime> Birthday { get; set; }

        [Required(ErrorMessage = "Debe Ingresar una dirección.")]
        [StringLength(100, ErrorMessage = "Dirección no puede tener mas de 300 caracteres.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Debe Ingresar un correo electrónico.")]
        [StringLength(100, ErrorMessage = "Email no puede tener mas de 100 caracteres.")]
        public string Email { get; set; }

        public Nullable<int> IdContactType { get; set; }
        public string ContactType { get; set; } //descripcion de la via de contacto

        public Nullable<int> IdPosition { get; set; }
        public string Position { get; set; } //descripcion del cargo, solo si es tipo de persona Empleado

        public bool ClientPermission { get; set; } //debe ser visible solo para tipo persona Empleado
        public bool Status { get; set; }
        public string StatusDesc { get; set; } //descripcion del estado (Activo/Inactivo)
        public List<MPersonContact> listPersonContact { get; set; } //Numeros de telefono de contacto de la persona
    }
}