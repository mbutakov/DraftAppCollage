﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DraftApp.database
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class entities : DbContext
    {
        public entities()
            : base("name=entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<material> material { get; set; }
        public virtual DbSet<provider> provider { get; set; }
        public virtual DbSet<provider_material> provider_material { get; set; }
        public virtual DbSet<storage> storage { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<type_material> type_material { get; set; }
        public virtual DbSet<units> units { get; set; }
    }
}
