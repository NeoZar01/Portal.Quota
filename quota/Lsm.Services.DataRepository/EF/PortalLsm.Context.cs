﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DoE.Lsm.Data.Repositories.EF
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PortalLsm : DbContext
    {
        public PortalLsm()
            : base("name=PortalLsm")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Bookmark> Bookmarks { get; set; }
        public virtual DbSet<BusinessRule> BusinessRules { get; set; }
        public virtual DbSet<Catalogue> Catalogues { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<InventoryRequest> InventoryRequests { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }
        public virtual DbSet<ReqStatu> ReqStatus { get; set; }
        public virtual DbSet<Requisition> Requisitions { get; set; }
        public virtual DbSet<RequisitionsNorm> RequisitionsNorms { get; set; }
        public virtual DbSet<School> Schools { get; set; }
        public virtual DbSet<req_vwOrderItems> req_vwOrderItems { get; set; }
        public virtual DbSet<vw_Requisition_TotalPrice> vw_Requisition_TotalPrice { get; set; }
        public virtual DbSet<vw_RequisitionOrderItems> vw_RequisitionOrderItems { get; set; }
        public virtual DbSet<vw_RequisitionsDashboard> vw_RequisitionsDashboard { get; set; }
        public virtual DbSet<vw_RequisitionsNorms> vw_RequisitionsNorms { get; set; }
        public virtual DbSet<vw_ShoppingCardItems> vw_ShoppingCardItems { get; set; }
        public virtual DbSet<vwTotalSubcityPerCircuit> vwTotalSubcityPerCircuits { get; set; }
    }
}
