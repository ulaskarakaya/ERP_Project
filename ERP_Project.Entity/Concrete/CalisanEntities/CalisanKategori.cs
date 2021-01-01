using ERP_Project.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_Project.Entity.Concrete.CalisanEntities
{
    public class CalisanKategori : IEntity  
    {
        public CalisanKategori()
        {
            this.Calisanlar = new HashSet<Calisan>();
        }
        public int Id { get; set; }
        public string Adi { get; set; }
        public virtual ICollection<Calisan> Calisanlar { get; set; }
    }
}
