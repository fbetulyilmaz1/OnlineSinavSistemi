using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineSinavSistemi.Bll.Abstract;
using OnlineSinavSistemi.Model.Data;

namespace OnlineSinavSistemi.UI.Areas.Admin.Controllers
{
    public class SinavController : AdminBaseController
    {
        IUnitOfWork service;
        public SinavController(IUnitOfWork _sinav)
        {
            service = _sinav;
        }
        [HttpGet]
        public IActionResult Listele()
        {
            var sinavlar = service.Sinav.GetAll(x => x.SilindiMi == false).Data;
            return View(sinavlar);
        }
        [HttpGet]
        public IActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Ekle(Sinav sinav)
        {
            sinav.OturumBittiMi = false;
            sinav.SilindiMi = false;
            sinav.KayitTarihi = DateTime.Now;
            service.Sinav.Add(sinav);
            service.SaveChanges();
            TempData["Message"] = "Başarıyla Eklediniz";
            return RedirectToAction(nameof(Ekle));
        }

        public IActionResult SinavGetbyID(int ID)
        {
            var sonuc = service.Sinav.GetAll(x => x.Id == ID && x.SilindiMi == false);
            return View(sonuc);
        }

        [HttpPost]
        public IActionResult SoftDelete(int id)
        {
            service.Sinav.SoftDelete(id);
            service.SaveChanges();
            return RedirectToAction(nameof(Listele));
        }

        public IActionResult Guncelle(int sinavId)
        {
            var sonuc = service.Sinav.GetAll(x => x.Id == sinavId).Data;
            return View(sonuc);
        }

        [HttpPost]
        public IActionResult Guncelle(Sinav sinav)
        {
            //ekleme işlemi ypaulacak.
            sinav.GuncellemeTarihi = DateTime.Now;
            service.Sinav.Update(sinav);
            service.SaveChanges();
            return RedirectToAction(nameof(Listele));
        }

        public IActionResult SinavTarihleriGetir()
        {
            var date = DateTime.Now.AddDays(-7);
            var liste = service.Sinav.GetAll(x => x.SinavTarihi >= date && x.SilindiMi == false && x.OturumBittiMi == true).Data;
            return View(liste);
        }
    }
}