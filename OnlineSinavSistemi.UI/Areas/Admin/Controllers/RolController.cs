using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineSinavSistemi.Bll.Abstract;
using OnlineSinavSistemi.Model.Data;

namespace OnlineSinavSistemi.UI.Areas.Admin.Controllers
{
    public class RolController : AdminBaseController

    {
        IUnitOfWork service;
        public RolController(IUnitOfWork _Rolservice)
        {
            service = _Rolservice;
        }
        
        public IActionResult Listele()
        {
            ICollection<Rol> liste = service.Rol.GetAll(x => x.SilindiMi == false).Data;
            return View(liste);
        }
        [HttpGet]
        public IActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Ekle(Rol model)
        {
            model.KayitTarihi = DateTime.Now;
            model.SilindiMi = false;
            service.Rol.Add(model);
            service.SaveChanges();
            return RedirectToAction(nameof(Ekle));
        }


        [HttpPost]
        public IActionResult Sil(int id)
        {
            service.Rol.SoftDelete(id);
            service.SaveChanges();
            return RedirectToAction(nameof(Listele));
        }


        
        public IActionResult Guncelle(int RolId)
        {
            var sonuc = service.Rol.GetAll(x => x.Id == RolId && x.SilindiMi == false).Data;
            return View(sonuc);
        }

        [HttpPost]
        public IActionResult Guncelle(Rol model)
        {
            //ekleme işlemi ypaulacak.
            model.GuncellemeTarihi = DateTime.Now;
            service.Rol.Update(model);
            service.SaveChanges();
            return RedirectToAction(nameof(Listele));
        }

    }
}