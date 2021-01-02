using ERP_Project.Business.Abstract.Service;
using ERP_Project.DataAccess.Abstraction;
using ERP_Project.Entity.Concrete.CalisanEntities;
using ERP_Project.Model.DTO.CalisanDTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ERP_Project.Business.Concrete.Manager
{
    public class CalisanManager : ICalisanService
    {
        private IMapperService _mapperService;
        private ICalisanDal _calisanDal;
        private ICalisanKategoriDal _calisanKategoriDal;
        public CalisanManager(IMapperService mapperService, ICalisanDal calisanDal, ICalisanKategoriDal calisanKategoriDal)
        {
            _mapperService = mapperService;
            _calisanDal = calisanDal;
            _calisanKategoriDal = calisanKategoriDal;
        }
        public bool CalisanMailKontrol(string email)
        {
            var calisan = _calisanDal.Getir(x => x.Email == email);
            if (calisan != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void Ekle(CalisanKayitDTO calisanKayitDTO)
        {
            var entity = _mapperService.Map<CalisanKayitDTO, Calisan>(calisanKayitDTO);
            _calisanDal.Ekle(entity);
        }

        public CalisanDTO Getir(Expression<Func<Calisan, bool>> filter)
        {
            var calisan = _calisanDal.Getir(filter);
            return _mapperService.Map<Calisan, CalisanDTO>(calisan);
        }

        public void Guncelle(CalisanDTO calisanDTO)
        {
            var calisan = _calisanDal.Getir(x => x.Id == calisanDTO.Id);
            var guncelCalisan = _mapperService.Map<CalisanDTO, Calisan>(calisanDTO, calisan);
            _calisanDal.Guncelle(guncelCalisan);
        }

        public List<CalisanDTO> HepsiniGetir(Expression<Func<Calisan, bool>> filter = null)
        {
            var calisanlar = _calisanDal.HepsiniGetir(filter);
            return _mapperService.Map<IEnumerable<Calisan>, List<CalisanDTO>>(calisanlar);
        }

        public void KalıcıSil(Expression<Func<Calisan, bool>> filter)
        {
            _calisanDal.KaliciSil(filter);
        }

        public List<CalisanDTO> KategoriyeGoreCalisanlariGetir(Expression<Func<CalisanKategori, bool>> filter = null)
        {
            var calisanKategori = _calisanKategoriDal.Getir(filter);
            return _mapperService.Map<IEnumerable<Calisan>, List<CalisanDTO>>(calisanKategori.Calisanlar);
        }

        public void Sil(Expression<Func<Calisan, bool>> filter)
        {
            _calisanDal.Sil(filter);
        }
    }
}
