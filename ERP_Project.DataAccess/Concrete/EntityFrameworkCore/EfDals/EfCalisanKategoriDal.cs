using ERP_Project.DataAccess.Abstraction;
using ERP_Project.DataAccess.Concrete.EntityFrameworkCore.Context;
using ERP_Project.Entity.Concrete.CalisanEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_Project.DataAccess.Concrete.EntityFrameworkCore.EfDals
{
    public class EfCalisanKategoriDal : EfBaseDal<CalisanKategori, ProjectContext>, ICalisanKategoriDal
    {
        public EfCalisanKategoriDal(ProjectContext context) : base(context) { }
        
    }
}
