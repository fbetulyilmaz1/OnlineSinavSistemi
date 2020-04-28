using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineSinavSistemi.Bll.Abstract;
using OnlineSinavSistemi.Model.Data;
using OnlineSinavSistemi.UI.Filters;
using OnlineSinavSistemi.UI.Models;

namespace OnlineSinavSistemi.UI.Controllers
{
    public class KullaniciController : Controller
    {
        IUnitOfWork service;
      private readonly  IHttpContextAccessor accessor;
        public KullaniciController(IUnitOfWork _service, IHttpContextAccessor _accessor)
        {
            service = _service;
            accessor = _accessor;
        }
        public IActionResult Login()
        {
            Kullanici loginUser = accessor.HttpContext.Session.GetObject<Kullanici>("lgnUser");
            if (loginUser != null)
            {
                return RedirectToAction("Index", "Home");
            }
                return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            var user = service.Kullanici.Login(model.EMail, model.Sifre);
            if (user.Data != null)
            {
                //Session["LoginUser"] = user;
                accessor.HttpContext.Session.SetObject<Kullanici>("lgnUser", user.Data);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Logout()
        {
            //Session["LoginUser"] = null;
            //Session.Remove("LoginUser");
            accessor.HttpContext.Session.Remove("lgnUser");
            accessor.HttpContext.Session.Clear();
            return RedirectToAction("Login", "Kullanici");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            service.Kullanici.Add(new Kullanici { Ad = model.Ad, Soyad = model.Soyad, Tc = model.Tc, DogumTarihi = model.DogumTarihi, EMail = model.EMail, Sifre = model.Sifre, FotoUrl = model.FotoURL, KayitTarihi = DateTime.Now, SilindiMi = false });
            var sonuc = service.SaveChanges();
            //var userId = service.Kullanici.GetAll(x => x.EMail == model.EMail).Data.FirstOrDefault().Id;
            return RedirectToAction(nameof(Login));
        }
    }
}