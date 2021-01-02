using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_Project.Model.DTO.CalisanDTOs
{
    public class CalisanDTO
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string Sifre { get; set; }
        public string Fotograf { get; set; }
        public int CalisanKategoriId { get; set; }
        public virtual CalisanKategoriDTO CalisanKategori { get; set; }
    }
}
