﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CustomerSupport.Models
{
    public class MServiceRequest
    {
        public MServiceRequest()
        {
            listConstructionOption = new List<MServiceConstructionOption>();
        }

        public int IdServiceRequest { get; set; }
        public int IdServiceType { get; set; }
        public string ServiceType { get; set; } //descripcion del tipo de servicio
        public int IdServiceStatus { get; set; }
        public string ServiceStatus { get; set; } //descripcion del estatus del servicio
        public int IdPerson { get; set; }
        public MPerson PersonClient { get; set; }
        public Nullable<int> IdContactType { get; set; }
        public string ContactType { get; set; } //descripcion de la via de contacto
        public Nullable<int> IdPropertyType { get; set; }
        public string PropertyType { get; set; } //descripcion de tipo de propiedad
        public string Address { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:N2}")]
        public Nullable<decimal> Price { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:N2}")]
        public Nullable<decimal> ClosingCost { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:N2}")]
        public Nullable<decimal> MonthlyIncome { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:N2}")]
        public Nullable<decimal> DebtPayment { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:N2}")]
        public Nullable<decimal> Piti { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:N2}")]
        public Nullable<decimal> Ratios { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:N2}")]
        public Nullable<decimal> EstimatedValue { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:N2}")]
        public Nullable<decimal> LoanAmount { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:N2}")]
        public Nullable<decimal> CurrentDebt { get; set; }

        public string Assets { get; set; }
        public string Beneficiaries { get; set; }
        public string Process { get; set; }
        public string Wish { get; set; }
        public Nullable<bool> Plane { get; set; }
        public Nullable<bool> Financing { get; set; }
        public string Note { get; set; }
        public int IdUser { get; set; }
        public string RegisterUser { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        [DataType(DataType.Date)]
        public System.DateTime RegisterDate { get; set; }

        public List<MServiceConstructionOption> listConstructionOption { get; set; } //lista las opciones de construccion para tipo de servicios Construccion/Planos
        public List<MTask> listTask { get; set; }
    }
}