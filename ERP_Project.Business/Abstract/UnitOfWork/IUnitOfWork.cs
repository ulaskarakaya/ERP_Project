using ERP_Project.Business.Abstract.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_Project.Business.Abstract.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        public bool Complete();
        public ICalisanService CalisanManager { get; }
        public IOturumService OturumManager { get; }
    }
}
