using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_Project.Business.Abstract.Service
{
    public interface IMapperService
    {
        THedef Map<TKaynak, THedef>(TKaynak kaynak);
        THedef Map<TKaynak, THedef>(TKaynak kaynak, THedef hedef);
    }
}
