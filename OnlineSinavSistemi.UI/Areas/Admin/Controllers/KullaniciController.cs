using Microsoft.AspNetCore.Mvc;
using OnlineSinavSistemi.Bll.Abstract;
using OnlineSinavSistemi.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineSinavSistemi.UI.Areas.Admin.Controllers
{
    public class KullaniciController : AdminBaseController
    {
        IUnitOfWork kullaniciService;
        public KullaniciController(IUnitOfWork _kullaniciService)
        {
            kullaniciService = _kullaniciService;
        }

        [HttpGet]
        public IActionResult Listele()
        {
            var liste = kullaniciService.Kullanici.GetAll(x => x.SilindiMi == false).Data;
            return View(liste);
        }
        [HttpGet]
        public IActionResult Ekle()
        {

            return View();
        }
        [HttpPost]
        public IActionResult Ekle(Kullanici model)
        {
            model.KayitTarihi = DateTime.Now;
            model.SilindiMi = false;
            //TempData["mesaj"] = kullaniciService.Kullanici.Add(model);
            kullaniciService.Kullanici.Add(model);
            kullaniciService.SaveChanges();
            return RedirectToAction(nameof(Ekle));
        }
        [HttpGet]
        public IActionResult Sil(int id)
        {
            //TempData["mesaj"] = kullaniciService.Kullanici.SoftDelete(model.Id);
            kullaniciService.Kullanici.SoftDelete(id);
            kullaniciService.SaveChanges();
            return RedirectToAction(nameof(Listele));
        }
        [HttpGet]
        public IActionResult Guncelle(int kullaniciId)
        {
           var sonuc = kullaniciService.Kullanici.Get(x => x.Id == kullaniciId).Data;
            //ICollection<Kullanici> sonuc = kullaniciService.Kullanici.GetAll(x => x.Id == kullaniciId).Data;
           return View(sonuc);
            //return RedirectToAction(nameof(Guncelle));
        }
        [HttpPost]
        public IActionResult Guncelle(Kullanici model)
        {
            model.KayitTarihi = DateTime.Now;

            //TempData["mesaj"] = kullaniciService.Kullanici.Update(model);
            kullaniciService.Kullanici.Update(model);
            kullaniciService.SaveChanges();
            return RedirectToAction(nameof(Listele));
        }
        [HttpGet]
        public IActionResult Detay(int kullaniciId)
        {
            var sonuc = kullaniciService.Kullanici.GetAll(x => x.Id == kullaniciId && x.SilindiMi == false);
            return View(sonuc);
        }
    }
}
