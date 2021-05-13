﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerSupport.Models
{
    public class MPerson
    {
        public int IdPerson { get; set; }
        public int IdPersonType { get; set; }
        public string PersonType { get; set; } //descripcion del tipo de persona
        public int IdIdentificationType { get; set; }
        public string IdentificationType { get; set; } //descripcion del tipo de identificacion
        public string NumIdentification { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public Nullable<System.DateTime> Birthday { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public Nullable<int> IdContactType { get; set; }
        public string ContactType { get; set; } //descripcion de la via de contacto
        public Nullable<int> IdPosition { get; set; }
        public string Position { get; set; } //descripcion del cargo, solo si es tipo de persona Empleado
        public bool ClientPermission { get; set; } //debe ser visible solo para tipo persona Empleado
        public bool Status { get; set; }
        public string StatusDesc { get; set; } //descripcion del estado (Activo/Inactivo)
        public List<MPersonContac> listPersonContact { get; set; } //Numeros de telefono de contacto de la persona
    }
}