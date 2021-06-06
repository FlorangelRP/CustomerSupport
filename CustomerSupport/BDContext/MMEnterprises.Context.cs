﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
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
    
        public virtual DbSet<Catalog> Catalogs { get; set; }
        public virtual DbSet<CatalogDetail> CatalogDetails { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<OptionMenu> OptionMenus { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<PersonContact> PersonContacts { get; set; }
        public virtual DbSet<ServiceRequest> ServiceRequests { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserAcce> UserAcces { get; set; }
        public virtual DbSet<VWListCatalog> VWListCatalogs { get; set; }
    
        public virtual ObjectResult<GNListPerson_Result> GNListPerson(Nullable<int> idPerson, Nullable<int> idPersonType)
        {
            var idPersonParameter = idPerson.HasValue ?
                new ObjectParameter("IdPerson", idPerson) :
                new ObjectParameter("IdPerson", typeof(int));
    
            var idPersonTypeParameter = idPersonType.HasValue ?
                new ObjectParameter("IdPersonType", idPersonType) :
                new ObjectParameter("IdPersonType", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GNListPerson_Result>("GNListPerson", idPersonParameter, idPersonTypeParameter);
        }
    
        public virtual ObjectResult<GNListUser_Result> GNListUser(Nullable<int> idUser)
        {
            var idUserParameter = idUser.HasValue ?
                new ObjectParameter("IdUser", idUser) :
                new ObjectParameter("IdUser", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GNListUser_Result>("GNListUser", idUserParameter);
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
    }
}
