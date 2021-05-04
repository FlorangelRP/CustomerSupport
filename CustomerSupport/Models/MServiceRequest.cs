using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomerSupport.Models
{
    public class MServiceRequest
    {
        public int IdServiceRequest { get; set; }
        public int IdServiceType { get; set; }
        public string ServiceType { get; set; } //descripcion del tipo de servicio
        public int IdPerson { get; set; }
        public MPerson PersonClient { get; set; } //aqui se llenaria con linq 
        public Nullable<int> IdPropertyType { get; set; }
        public string Address { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<decimal> ClosingCost { get; set; }
        public Nullable<decimal> MonthlyIncome { get; set; }
        public Nullable<decimal> DebtPayment { get; set; }
        public Nullable<decimal> Piti { get; set; }
        public Nullable<decimal> Ratios { get; set; }
        public Nullable<decimal> EstimatedValue { get; set; }
        public Nullable<decimal> LoanAmount { get; set; }
        public Nullable<decimal> CurrentDebt { get; set; }
        public string Assets { get; set; }
        public string Beneficiaries { get; set; }
        public string Process { get; set; }
        public string Wish { get; set; }
        public Nullable<bool> Plane { get; set; }
        public Nullable<bool> Financing { get; set; }
        public string Note { get; set; }
        public int IdStatus { get; set; } //OJOOOOO falto crear en la tabla de base de datos
        public int IdUser { get; set; }
        public string RegisterUser { get; set; }
        public System.DateTime RegisterDate { get; set; }

    }
}