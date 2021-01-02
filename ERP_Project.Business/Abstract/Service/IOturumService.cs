using System;
using System.Collections.Generic;
using System.Text;

namespace ERP_Project.Business.Abstract.Service
{
    public interface IOturumService
    {
        bool EmailSifreGirisKontrol(string email, string sifre);
    }
}
