using AutoMapper;
using AutoMapper.EquivalencyExpression;
using ERP_Project.Business.Abstract.Service;
using ERP_Project.Business.Concrete.Utilities.AutoMapperProfiles.CalisanProfiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_Project.Business.Concrete.Manager
{
    public class AutoMapperManager : IMapperService
    {
        private Mapper _mapper;
        public AutoMapperManager()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddCollectionMappers();

                cfg.AddProfile(new CalisanProfile());
                cfg.AddProfile(new CalisanGirisProfile());
                cfg.AddProfile(new CalisanKategoriProfile());
                cfg.AddProfile(new CalisanKayitProfile());
            });

            config.CreateMapper();

            _mapper = new Mapper(config);
        }

        public THedef Map<TKaynak, THedef>(TKaynak kaynak)
        {
            return _mapper.Map<THedef>(kaynak);
        }

        public THedef Map<TKaynak, THedef>(TKaynak kaynak, THedef hedef)
        {
            return _mapper.Map(kaynak, hedef);
        }
    }
}
