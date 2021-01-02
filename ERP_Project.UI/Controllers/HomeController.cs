using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ERP_Project.UI.Models;
using ERP_Project.Model.DTO.CalisanDTOs;
using ERP_Project.Business.Abstract.UnitOfWork;
using System.Security.Claims;
using System.Globalization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Routing;

namespace ERP_Project.UI.Controllers
{
    public class HomeController : Controller
    {
        private IUnitOfWork _unitOfWork;
        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Giris()
        {
            return View();
        } 

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Giris(CalisanGirisDTO girisDTO)
        {
            if (_unitOfWork.OturumManager.EmailSifreGirisKontrol(girisDTO.Email, girisDTO.Sifre))
            {
                CalisanDTO user = _unitOfWork.CalisanManager.Getir(x => x.Email == girisDTO.Email);
                var userClaims = new List<Claim>()
                {
                    new Claim("Id", user.Id.ToString()),
                    new Claim(ClaimTypes.Name, CultureInfo.CurrentCulture.TextInfo.ToTitleCase(user.Adi)),
                    new Claim("Surname", (user.Soyadi).ToUpper()),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim("Fotograf",user.Fotograf),
                    new Claim("CalisanKategoriId",user.CalisanKategoriId.ToString())
                 };
                var grandmaIdentity = new ClaimsIdentity(userClaims, "Login");
                var userPrincipal = new ClaimsPrincipal(new[] { grandmaIdentity });
                await HttpContext.SignInAsync(userPrincipal);
                return RedirectToAction("Hesabim", new RouteValueDictionary(new
                {
                    controller = "InsanKaynaklari",
                    area = "Panel",
                    action = "Hesabim",
                    Id = user.Id
                }));
                
            }
            else
            {
                ViewData["hata"] = "E-Posta veya şifre hatalı.";
                return View(girisDTO);
            }
        }
    }
}
