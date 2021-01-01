using ERP_Project.Entity.Concrete.CalisanEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_Project.DataAccess.Concrete.EntityFrameworkCore.Mappings.CalisanMaps
{
    public class CalisanMap : IEntityTypeConfiguration<Calisan>
    {
        public void Configure(EntityTypeBuilder<Calisan> builder)
        {
            builder.ToTable("Calisanlar");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Adi).HasMaxLength(20);
            builder.Property(x => x.Soyadi).HasMaxLength(20);
            builder.Property(x => x.Email).HasMaxLength(30);
            builder.Property(x => x.Telefon).HasMaxLength(11);
            builder.Property(x => x.Sifre).HasMaxLength(20);
        }
    }
}
