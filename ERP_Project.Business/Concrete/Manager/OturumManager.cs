using ERP_Project.Business.Abstract.Service;
using ERP_Project.DataAccess.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_Project.Business.Concrete.Manager
{
    public class OturumManager : IOturumService
    {
        private ICalisanDal _calisanDal;
        public OturumManager(ICalisanDal calisanDal)
        {
            _calisanDal = calisanDal;
        }
        public bool EmailSifreGirisKontrol(string email, string sifre)
        {
            var calisan = _calisanDal.Getir(x => x.Email == email && x.Sifre == sifre);
            if (calisan != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
