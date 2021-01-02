using ERP_Project.Business.Abstract.Service;
using ERP_Project.Business.Abstract.UnitOfWork;
using ERP_Project.Business.Concrete.Manager;
using ERP_Project.DataAccess.Abstraction;
using ERP_Project.DataAccess.Concrete.EntityFrameworkCore.Context;
using ERP_Project.DataAccess.Concrete.EntityFrameworkCore.EfDals;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_Project.Business.Concrete.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private ProjectContext _context;

        private ICalisanDal _calisanDal;
        private ICalisanKategoriDal _calisanKategoriDal;

        private IMapperService _mapperService;
        private ICalisanService _calisanService;
        private IOturumService _oturumService;

        public UnitOfWork()
        {
            _context = new ProjectContext();

            _calisanDal = new EfCalisanDal(_context);
            _calisanKategoriDal = new EfCalisanKategoriDal(_context);

            _mapperService = new AutoMapperManager();
            _calisanService = new CalisanManager(_mapperService, _calisanDal, _calisanKategoriDal);
            _oturumService = new OturumManager(_calisanDal);
        }

        public ICalisanService CalisanManager { get { return _calisanService; } }

        public IOturumService OturumManager { get { return _oturumService; } }

        public bool Complete()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
