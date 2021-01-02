
using ERP_Project.Entity.Concrete.CalisanEntities;
using ERP_Project.Model.DTO.CalisanDTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ERP_Project.Business.Abstract.Service
{
    public interface ICalisanService
    {
        List<CalisanDTO> HepsiniGetir(Expression<Func<Calisan, bool>> filter = null);
        CalisanDTO Getir(Expression<Func<Calisan, bool>> filter);
        void Ekle(CalisanKayitDTO calisanKayitDTO);
        void Guncelle(CalisanDTO calisanDTO);
        void Sil(Expression<Func<Calisan, bool>> filter);
        void KalıcıSil(Expression<Func<Calisan, bool>> filter);
        List<CalisanDTO> KategoriyeGoreCalisanlariGetir(Expression<Func<CalisanKategori, bool>> filter = null);
        bool CalisanMailKontrol(string email);
    }
}
