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
    }
}
