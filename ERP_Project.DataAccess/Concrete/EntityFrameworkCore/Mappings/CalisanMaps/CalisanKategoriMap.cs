using ERP_Project.Entity.Concrete.CalisanEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_Project.DataAccess.Concrete.EntityFrameworkCore.Mappings.CalisanMaps
{
    public class CalisanKategoriMap : IEntityTypeConfiguration<CalisanKategori>
    {
        public void Configure(EntityTypeBuilder<CalisanKategori> builder)
        {
            builder.ToTable("CalisanKategorileri");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Adi).HasMaxLength(20);
        }
    }
}
