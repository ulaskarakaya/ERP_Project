using ERP_Project.DataAccess.Concrete.EntityFrameworkCore.Mappings.CalisanMaps;
using ERP_Project.DataAccess.Concrete.EntityFrameworkCore.SeedData;
using ERP_Project.Entity.Concrete.CalisanEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_Project.DataAccess.Concrete.EntityFrameworkCore.Context
{
    public class ProjectContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ERP_Project;Trusted_Connection=True;");
        }
        public DbSet<Calisan> Calisanlar { get; set; }
        public DbSet<CalisanKategori> CalisanKategorileri { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CalisanMap());
            modelBuilder.ApplyConfiguration(new CalisanKategoriMap());


            modelBuilder.Seed();
        }
    }
}
