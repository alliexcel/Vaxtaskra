﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Vaxtaskra.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class VaxtaDbEntities : DbContext
    {
        public VaxtaDbEntities()
            : base("name=VaxtaDbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__RefactorLog> C__RefactorLog { get; set; }
        public virtual DbSet<Vaxtafotur> Vaxtafoturs { get; set; }
        public virtual DbSet<Vaxtafotur_interests> Vaxtafotur_interests { get; set; }
        public virtual DbSet<Vaxtaruna> Vaxtarunas { get; set; }
        public virtual DbSet<Vaxtaruna_interests> Vaxtaruna_interests { get; set; }
        public virtual DbSet<Vextir_greidast> Vextir_greidast { get; set; }
        public virtual DbSet<Vaxtasaga> Vaxtasagas { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<ProductType> ProductTypes { get; set; }
        public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }
        public virtual DbSet<Product_indexation> Product_indexation { get; set; }
        public virtual DbSet<ProductInterest> ProductInterests { get; set; }
        public virtual DbSet<ProductPayment> ProductPayments { get; set; }
        public virtual DbSet<Gjaldskra> Gjaldskras { get; set; }
        public virtual DbSet<Gjaldskra_Product> Gjaldskra_Product { get; set; }
        public virtual DbSet<Tegund_gjalds> Tegund_gjalds { get; set; }
        public virtual DbSet<SourceSystem> SourceSystems { get; set; }
    }
}
