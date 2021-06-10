﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class MMEnterprisesEntities : DbContext
    {
        public MMEnterprisesEntities()
            : base("name=MMEnterprisesEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Catalog> Catalog { get; set; }
        public virtual DbSet<CatalogDetail> CatalogDetail { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<OptionMenu> OptionMenu { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<PersonContact> PersonContact { get; set; }
        public virtual DbSet<ServiceRequest> ServiceRequest { get; set; }
        public virtual DbSet<Task> Task { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserAcces> UserAcces { get; set; }
        public virtual DbSet<VWListCatalog> VWListCatalog { get; set; }
    
        public virtual int GNAuthenticationUser(string strLogin, string strPassword, ObjectParameter idUser)
        {
            var strLoginParameter = strLogin != null ?
                new ObjectParameter("strLogin", strLogin) :
                new ObjectParameter("strLogin", typeof(string));
    
            var strPasswordParameter = strPassword != null ?
                new ObjectParameter("strPassword", strPassword) :
                new ObjectParameter("strPassword", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GNAuthenticationUser", strLoginParameter, strPasswordParameter, idUser);
        }
    
        public virtual ObjectResult<GNListCountry_Result> GNListCountry(Nullable<int> idCountry, string idIsoCountry)
        {
            var idCountryParameter = idCountry.HasValue ?
                new ObjectParameter("IdCountry", idCountry) :
                new ObjectParameter("IdCountry", typeof(int));
    
            var idIsoCountryParameter = idIsoCountry != null ?
                new ObjectParameter("IdIsoCountry", idIsoCountry) :
                new ObjectParameter("IdIsoCountry", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GNListCountry_Result>("GNListCountry", idCountryParameter, idIsoCountryParameter);
        }
    
        public virtual ObjectResult<GNListPerson_Result> GNListPerson(Nullable<int> idPerson, Nullable<int> idPersonType, Nullable<bool> status)
        {
            var idPersonParameter = idPerson.HasValue ?
                new ObjectParameter("IdPerson", idPerson) :
                new ObjectParameter("IdPerson", typeof(int));
    
            var idPersonTypeParameter = idPersonType.HasValue ?
                new ObjectParameter("IdPersonType", idPersonType) :
                new ObjectParameter("IdPersonType", typeof(int));
    
            var statusParameter = status.HasValue ?
                new ObjectParameter("Status", status) :
                new ObjectParameter("Status", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GNListPerson_Result>("GNListPerson", idPersonParameter, idPersonTypeParameter, statusParameter);
        }
    
        public virtual ObjectResult<GNListPersonContact_Result> GNListPersonContact(Nullable<int> idPerson, Nullable<int> idPersonType, Nullable<int> idContact)
        {
            var idPersonParameter = idPerson.HasValue ?
                new ObjectParameter("IdPerson", idPerson) :
                new ObjectParameter("IdPerson", typeof(int));
    
            var idPersonTypeParameter = idPersonType.HasValue ?
                new ObjectParameter("IdPersonType", idPersonType) :
                new ObjectParameter("IdPersonType", typeof(int));
    
            var idContactParameter = idContact.HasValue ?
                new ObjectParameter("IdContact", idContact) :
                new ObjectParameter("IdContact", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GNListPersonContact_Result>("GNListPersonContact", idPersonParameter, idPersonTypeParameter, idContactParameter);
        }
    
        public virtual ObjectResult<GNListServiceConstructionOption_Result> GNListServiceConstructionOption(Nullable<int> idServiceRequest, Nullable<int> idConstructionOption)
        {
            var idServiceRequestParameter = idServiceRequest.HasValue ?
                new ObjectParameter("IdServiceRequest", idServiceRequest) :
                new ObjectParameter("IdServiceRequest", typeof(int));
    
            var idConstructionOptionParameter = idConstructionOption.HasValue ?
                new ObjectParameter("IdConstructionOption", idConstructionOption) :
                new ObjectParameter("IdConstructionOption", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GNListServiceConstructionOption_Result>("GNListServiceConstructionOption", idServiceRequestParameter, idConstructionOptionParameter);
        }
    
        public virtual ObjectResult<GNListServiceRequest_Result> GNListServiceRequest(Nullable<int> idServiceRequest, Nullable<int> idServiceType, Nullable<int> idServiceStatus, Nullable<int> idPerson, Nullable<int> idUser)
        {
            var idServiceRequestParameter = idServiceRequest.HasValue ?
                new ObjectParameter("IdServiceRequest", idServiceRequest) :
                new ObjectParameter("IdServiceRequest", typeof(int));
    
            var idServiceTypeParameter = idServiceType.HasValue ?
                new ObjectParameter("IdServiceType", idServiceType) :
                new ObjectParameter("IdServiceType", typeof(int));
    
            var idServiceStatusParameter = idServiceStatus.HasValue ?
                new ObjectParameter("IdServiceStatus", idServiceStatus) :
                new ObjectParameter("IdServiceStatus", typeof(int));
    
            var idPersonParameter = idPerson.HasValue ?
                new ObjectParameter("IdPerson", idPerson) :
                new ObjectParameter("IdPerson", typeof(int));
    
            var idUserParameter = idUser.HasValue ?
                new ObjectParameter("IdUser", idUser) :
                new ObjectParameter("IdUser", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GNListServiceRequest_Result>("GNListServiceRequest", idServiceRequestParameter, idServiceTypeParameter, idServiceStatusParameter, idPersonParameter, idUserParameter);
        }
    
        public virtual ObjectResult<GNListTask_Result> GNListTask(string selectType, Nullable<int> idTask, Nullable<int> idServiceRequest, Nullable<int> idUser)
        {
            var selectTypeParameter = selectType != null ?
                new ObjectParameter("SelectType", selectType) :
                new ObjectParameter("SelectType", typeof(string));
    
            var idTaskParameter = idTask.HasValue ?
                new ObjectParameter("IdTask", idTask) :
                new ObjectParameter("IdTask", typeof(int));
    
            var idServiceRequestParameter = idServiceRequest.HasValue ?
                new ObjectParameter("IdServiceRequest", idServiceRequest) :
                new ObjectParameter("IdServiceRequest", typeof(int));
    
            var idUserParameter = idUser.HasValue ?
                new ObjectParameter("IdUser", idUser) :
                new ObjectParameter("IdUser", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GNListTask_Result>("GNListTask", selectTypeParameter, idTaskParameter, idServiceRequestParameter, idUserParameter);
        }
    
        public virtual ObjectResult<GNListUser_Result> GNListUser(Nullable<int> idUser)
        {
            var idUserParameter = idUser.HasValue ?
                new ObjectParameter("IdUser", idUser) :
                new ObjectParameter("IdUser", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GNListUser_Result>("GNListUser", idUserParameter);
        }
    
        public virtual ObjectResult<GNListUserAcces_Result> GNListUserAcces(Nullable<int> idUser, Nullable<int> idAssociated)
        {
            var idUserParameter = idUser.HasValue ?
                new ObjectParameter("IdUser", idUser) :
                new ObjectParameter("IdUser", typeof(int));
    
            var idAssociatedParameter = idAssociated.HasValue ?
                new ObjectParameter("IdAssociated", idAssociated) :
                new ObjectParameter("IdAssociated", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GNListUserAcces_Result>("GNListUserAcces", idUserParameter, idAssociatedParameter);
        }
    
        public virtual int GNTranPerson(string transactionType, ObjectParameter idPerson, Nullable<int> idPersonType, Nullable<int> idIdentificationType, string strNumIdentification, string strName, string strLastName, Nullable<System.DateTime> dttBirthday, string strAddress, string strEmail, Nullable<int> idContactType, Nullable<int> idPosition, Nullable<bool> btClientPermission, Nullable<bool> btStatus)
        {
            var transactionTypeParameter = transactionType != null ?
                new ObjectParameter("TransactionType", transactionType) :
                new ObjectParameter("TransactionType", typeof(string));
    
            var idPersonTypeParameter = idPersonType.HasValue ?
                new ObjectParameter("IdPersonType", idPersonType) :
                new ObjectParameter("IdPersonType", typeof(int));
    
            var idIdentificationTypeParameter = idIdentificationType.HasValue ?
                new ObjectParameter("IdIdentificationType", idIdentificationType) :
                new ObjectParameter("IdIdentificationType", typeof(int));
    
            var strNumIdentificationParameter = strNumIdentification != null ?
                new ObjectParameter("strNumIdentification", strNumIdentification) :
                new ObjectParameter("strNumIdentification", typeof(string));
    
            var strNameParameter = strName != null ?
                new ObjectParameter("strName", strName) :
                new ObjectParameter("strName", typeof(string));
    
            var strLastNameParameter = strLastName != null ?
                new ObjectParameter("strLastName", strLastName) :
                new ObjectParameter("strLastName", typeof(string));
    
            var dttBirthdayParameter = dttBirthday.HasValue ?
                new ObjectParameter("dttBirthday", dttBirthday) :
                new ObjectParameter("dttBirthday", typeof(System.DateTime));
    
            var strAddressParameter = strAddress != null ?
                new ObjectParameter("strAddress", strAddress) :
                new ObjectParameter("strAddress", typeof(string));
    
            var strEmailParameter = strEmail != null ?
                new ObjectParameter("strEmail", strEmail) :
                new ObjectParameter("strEmail", typeof(string));
    
            var idContactTypeParameter = idContactType.HasValue ?
                new ObjectParameter("IdContactType", idContactType) :
                new ObjectParameter("IdContactType", typeof(int));
    
            var idPositionParameter = idPosition.HasValue ?
                new ObjectParameter("IdPosition", idPosition) :
                new ObjectParameter("IdPosition", typeof(int));
    
            var btClientPermissionParameter = btClientPermission.HasValue ?
                new ObjectParameter("btClientPermission", btClientPermission) :
                new ObjectParameter("btClientPermission", typeof(bool));
    
            var btStatusParameter = btStatus.HasValue ?
                new ObjectParameter("btStatus", btStatus) :
                new ObjectParameter("btStatus", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GNTranPerson", transactionTypeParameter, idPerson, idPersonTypeParameter, idIdentificationTypeParameter, strNumIdentificationParameter, strNameParameter, strLastNameParameter, dttBirthdayParameter, strAddressParameter, strEmailParameter, idContactTypeParameter, idPositionParameter, btClientPermissionParameter, btStatusParameter);
        }
    
        public virtual int GNTranPersonContact(string transactionType, ObjectParameter idContact, Nullable<int> idPerson, Nullable<int> idPhoneNumberType, string strIdIsoCountry, string strPhoneNumber, Nullable<bool> btStatus)
        {
            var transactionTypeParameter = transactionType != null ?
                new ObjectParameter("TransactionType", transactionType) :
                new ObjectParameter("TransactionType", typeof(string));
    
            var idPersonParameter = idPerson.HasValue ?
                new ObjectParameter("IdPerson", idPerson) :
                new ObjectParameter("IdPerson", typeof(int));
    
            var idPhoneNumberTypeParameter = idPhoneNumberType.HasValue ?
                new ObjectParameter("IdPhoneNumberType", idPhoneNumberType) :
                new ObjectParameter("IdPhoneNumberType", typeof(int));
    
            var strIdIsoCountryParameter = strIdIsoCountry != null ?
                new ObjectParameter("strIdIsoCountry", strIdIsoCountry) :
                new ObjectParameter("strIdIsoCountry", typeof(string));
    
            var strPhoneNumberParameter = strPhoneNumber != null ?
                new ObjectParameter("strPhoneNumber", strPhoneNumber) :
                new ObjectParameter("strPhoneNumber", typeof(string));
    
            var btStatusParameter = btStatus.HasValue ?
                new ObjectParameter("btStatus", btStatus) :
                new ObjectParameter("btStatus", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GNTranPersonContact", transactionTypeParameter, idContact, idPersonParameter, idPhoneNumberTypeParameter, strIdIsoCountryParameter, strPhoneNumberParameter, btStatusParameter);
        }
    
        public virtual int GNTranServiceConstructionOption(string transactionType, Nullable<int> idServiceRequest, Nullable<int> idConstructionOption)
        {
            var transactionTypeParameter = transactionType != null ?
                new ObjectParameter("TransactionType", transactionType) :
                new ObjectParameter("TransactionType", typeof(string));
    
            var idServiceRequestParameter = idServiceRequest.HasValue ?
                new ObjectParameter("IdServiceRequest", idServiceRequest) :
                new ObjectParameter("IdServiceRequest", typeof(int));
    
            var idConstructionOptionParameter = idConstructionOption.HasValue ?
                new ObjectParameter("IdConstructionOption", idConstructionOption) :
                new ObjectParameter("IdConstructionOption", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GNTranServiceConstructionOption", transactionTypeParameter, idServiceRequestParameter, idConstructionOptionParameter);
        }
    
        public virtual int GNTranServiceRequest(string transactionType, ObjectParameter idServiceRequest, Nullable<int> idServiceType, Nullable<int> idServiceStatus, Nullable<int> idPerson, Nullable<int> idPropertyType, string address, Nullable<decimal> price, Nullable<decimal> closingCost, Nullable<decimal> monthlyIncome, Nullable<decimal> debtPayment, Nullable<decimal> piti, Nullable<decimal> ratios, Nullable<decimal> estimatedValue, Nullable<decimal> loanAmount, Nullable<decimal> currentDebt, string assets, string beneficiaries, string process, string wish, Nullable<bool> plane, Nullable<bool> financing, string note, Nullable<int> idUser)
        {
            var transactionTypeParameter = transactionType != null ?
                new ObjectParameter("TransactionType", transactionType) :
                new ObjectParameter("TransactionType", typeof(string));
    
            var idServiceTypeParameter = idServiceType.HasValue ?
                new ObjectParameter("IdServiceType", idServiceType) :
                new ObjectParameter("IdServiceType", typeof(int));
    
            var idServiceStatusParameter = idServiceStatus.HasValue ?
                new ObjectParameter("IdServiceStatus", idServiceStatus) :
                new ObjectParameter("IdServiceStatus", typeof(int));
    
            var idPersonParameter = idPerson.HasValue ?
                new ObjectParameter("IdPerson", idPerson) :
                new ObjectParameter("IdPerson", typeof(int));
    
            var idPropertyTypeParameter = idPropertyType.HasValue ?
                new ObjectParameter("IdPropertyType", idPropertyType) :
                new ObjectParameter("IdPropertyType", typeof(int));
    
            var addressParameter = address != null ?
                new ObjectParameter("Address", address) :
                new ObjectParameter("Address", typeof(string));
    
            var priceParameter = price.HasValue ?
                new ObjectParameter("Price", price) :
                new ObjectParameter("Price", typeof(decimal));
    
            var closingCostParameter = closingCost.HasValue ?
                new ObjectParameter("ClosingCost", closingCost) :
                new ObjectParameter("ClosingCost", typeof(decimal));
    
            var monthlyIncomeParameter = monthlyIncome.HasValue ?
                new ObjectParameter("MonthlyIncome", monthlyIncome) :
                new ObjectParameter("MonthlyIncome", typeof(decimal));
    
            var debtPaymentParameter = debtPayment.HasValue ?
                new ObjectParameter("DebtPayment", debtPayment) :
                new ObjectParameter("DebtPayment", typeof(decimal));
    
            var pitiParameter = piti.HasValue ?
                new ObjectParameter("Piti", piti) :
                new ObjectParameter("Piti", typeof(decimal));
    
            var ratiosParameter = ratios.HasValue ?
                new ObjectParameter("Ratios", ratios) :
                new ObjectParameter("Ratios", typeof(decimal));
    
            var estimatedValueParameter = estimatedValue.HasValue ?
                new ObjectParameter("EstimatedValue", estimatedValue) :
                new ObjectParameter("EstimatedValue", typeof(decimal));
    
            var loanAmountParameter = loanAmount.HasValue ?
                new ObjectParameter("LoanAmount", loanAmount) :
                new ObjectParameter("LoanAmount", typeof(decimal));
    
            var currentDebtParameter = currentDebt.HasValue ?
                new ObjectParameter("CurrentDebt", currentDebt) :
                new ObjectParameter("CurrentDebt", typeof(decimal));
    
            var assetsParameter = assets != null ?
                new ObjectParameter("Assets", assets) :
                new ObjectParameter("Assets", typeof(string));
    
            var beneficiariesParameter = beneficiaries != null ?
                new ObjectParameter("Beneficiaries", beneficiaries) :
                new ObjectParameter("Beneficiaries", typeof(string));
    
            var processParameter = process != null ?
                new ObjectParameter("Process", process) :
                new ObjectParameter("Process", typeof(string));
    
            var wishParameter = wish != null ?
                new ObjectParameter("Wish", wish) :
                new ObjectParameter("Wish", typeof(string));
    
            var planeParameter = plane.HasValue ?
                new ObjectParameter("Plane", plane) :
                new ObjectParameter("Plane", typeof(bool));
    
            var financingParameter = financing.HasValue ?
                new ObjectParameter("Financing", financing) :
                new ObjectParameter("Financing", typeof(bool));
    
            var noteParameter = note != null ?
                new ObjectParameter("Note", note) :
                new ObjectParameter("Note", typeof(string));
    
            var idUserParameter = idUser.HasValue ?
                new ObjectParameter("IdUser", idUser) :
                new ObjectParameter("IdUser", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GNTranServiceRequest", transactionTypeParameter, idServiceRequest, idServiceTypeParameter, idServiceStatusParameter, idPersonParameter, idPropertyTypeParameter, addressParameter, priceParameter, closingCostParameter, monthlyIncomeParameter, debtPaymentParameter, pitiParameter, ratiosParameter, estimatedValueParameter, loanAmountParameter, currentDebtParameter, assetsParameter, beneficiariesParameter, processParameter, wishParameter, planeParameter, financingParameter, noteParameter, idUserParameter);
        }
    
        public virtual int GNTranServiceRequestTask(string transactionType, Nullable<int> idTask, Nullable<int> idServiceRequest)
        {
            var transactionTypeParameter = transactionType != null ?
                new ObjectParameter("TransactionType", transactionType) :
                new ObjectParameter("TransactionType", typeof(string));
    
            var idTaskParameter = idTask.HasValue ?
                new ObjectParameter("IdTask", idTask) :
                new ObjectParameter("IdTask", typeof(int));
    
            var idServiceRequestParameter = idServiceRequest.HasValue ?
                new ObjectParameter("IdServiceRequest", idServiceRequest) :
                new ObjectParameter("IdServiceRequest", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GNTranServiceRequestTask", transactionTypeParameter, idTaskParameter, idServiceRequestParameter);
        }
    
        public virtual int GNTranTask(string transactionType, ObjectParameter idTask, Nullable<int> idUser, string activity, Nullable<System.DateTime> dateIni, Nullable<System.DateTime> dateEnd, Nullable<System.TimeSpan> hourIni, Nullable<System.TimeSpan> hourEnd, string place)
        {
            var transactionTypeParameter = transactionType != null ?
                new ObjectParameter("TransactionType", transactionType) :
                new ObjectParameter("TransactionType", typeof(string));
    
            var idUserParameter = idUser.HasValue ?
                new ObjectParameter("IdUser", idUser) :
                new ObjectParameter("IdUser", typeof(int));
    
            var activityParameter = activity != null ?
                new ObjectParameter("Activity", activity) :
                new ObjectParameter("Activity", typeof(string));
    
            var dateIniParameter = dateIni.HasValue ?
                new ObjectParameter("DateIni", dateIni) :
                new ObjectParameter("DateIni", typeof(System.DateTime));
    
            var dateEndParameter = dateEnd.HasValue ?
                new ObjectParameter("DateEnd", dateEnd) :
                new ObjectParameter("DateEnd", typeof(System.DateTime));
    
            var hourIniParameter = hourIni.HasValue ?
                new ObjectParameter("HourIni", hourIni) :
                new ObjectParameter("HourIni", typeof(System.TimeSpan));
    
            var hourEndParameter = hourEnd.HasValue ?
                new ObjectParameter("HourEnd", hourEnd) :
                new ObjectParameter("HourEnd", typeof(System.TimeSpan));
    
            var placeParameter = place != null ?
                new ObjectParameter("Place", place) :
                new ObjectParameter("Place", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GNTranTask", transactionTypeParameter, idTask, idUserParameter, activityParameter, dateIniParameter, dateEndParameter, hourIniParameter, hourEndParameter, placeParameter);
        }
    
        public virtual int GNTranUser(Nullable<int> idPerson, string strLogin, string strPassword, string transactionType, ObjectParameter idUser, Nullable<bool> btStatus)
        {
            var idPersonParameter = idPerson.HasValue ?
                new ObjectParameter("IdPerson", idPerson) :
                new ObjectParameter("IdPerson", typeof(int));
    
            var strLoginParameter = strLogin != null ?
                new ObjectParameter("strLogin", strLogin) :
                new ObjectParameter("strLogin", typeof(string));
    
            var strPasswordParameter = strPassword != null ?
                new ObjectParameter("strPassword", strPassword) :
                new ObjectParameter("strPassword", typeof(string));
    
            var transactionTypeParameter = transactionType != null ?
                new ObjectParameter("TransactionType", transactionType) :
                new ObjectParameter("TransactionType", typeof(string));
    
            var btStatusParameter = btStatus.HasValue ?
                new ObjectParameter("btStatus", btStatus) :
                new ObjectParameter("btStatus", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GNTranUser", idPersonParameter, strLoginParameter, strPasswordParameter, transactionTypeParameter, idUser, btStatusParameter);
        }
    
        public virtual int GNTranUserAcces(Nullable<int> idUser, Nullable<int> idOption, Nullable<int> blnVisible, Nullable<int> blnCreate, Nullable<int> blnSearch, Nullable<int> blnEdit, Nullable<int> blnDelete)
        {
            var idUserParameter = idUser.HasValue ?
                new ObjectParameter("IdUser", idUser) :
                new ObjectParameter("IdUser", typeof(int));
    
            var idOptionParameter = idOption.HasValue ?
                new ObjectParameter("IdOption", idOption) :
                new ObjectParameter("IdOption", typeof(int));
    
            var blnVisibleParameter = blnVisible.HasValue ?
                new ObjectParameter("blnVisible", blnVisible) :
                new ObjectParameter("blnVisible", typeof(int));
    
            var blnCreateParameter = blnCreate.HasValue ?
                new ObjectParameter("blnCreate", blnCreate) :
                new ObjectParameter("blnCreate", typeof(int));
    
            var blnSearchParameter = blnSearch.HasValue ?
                new ObjectParameter("blnSearch", blnSearch) :
                new ObjectParameter("blnSearch", typeof(int));
    
            var blnEditParameter = blnEdit.HasValue ?
                new ObjectParameter("blnEdit", blnEdit) :
                new ObjectParameter("blnEdit", typeof(int));
    
            var blnDeleteParameter = blnDelete.HasValue ?
                new ObjectParameter("blnDelete", blnDelete) :
                new ObjectParameter("blnDelete", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GNTranUserAcces", idUserParameter, idOptionParameter, blnVisibleParameter, blnCreateParameter, blnSearchParameter, blnEditParameter, blnDeleteParameter);
        }
    }
}
