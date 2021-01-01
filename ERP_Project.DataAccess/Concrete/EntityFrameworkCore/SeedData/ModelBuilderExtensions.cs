using ERP_Project.Entity.Concrete.CalisanEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_Project.DataAccess.Concrete.EntityFrameworkCore.SeedData
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CalisanKategori>().HasData(
                new CalisanKategori { Id = 1, Adi = "İnsan Kaynakları" },
                new CalisanKategori { Id = 2, Adi = "Üretim" },
                new CalisanKategori { Id = 3, Adi = "Tedarik Zinciri" },
                new CalisanKategori { Id = 4, Adi = "Müşteri İlişkileri" }
                );
        }
    }
}
