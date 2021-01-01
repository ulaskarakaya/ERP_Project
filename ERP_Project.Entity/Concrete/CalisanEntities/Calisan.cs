using ERP_Project.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_Project.Entity.Concrete.CalisanEntities
{
    public class Calisan : IEntity
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string Sifre { get; set; }
        public string Fotograf { get; set; }
        public bool AktifMi { get; set; }
        public int CalisanKategoriId { get; set; }
        public virtual CalisanKategori CalisanKategori { get; set; }
    }
}
