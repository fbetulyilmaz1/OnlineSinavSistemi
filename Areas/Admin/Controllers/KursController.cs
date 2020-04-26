using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineSinavSistemi.Bll.Abstract;
using OnlineSinavSistemi.Model.Data;

namespace OnlineSinavSistemi.UI.Areas.Admin.Controllers
{
    public class KursController : AdminBaseController
    {
        IUnitOfWork service;
        public KursController(IUnitOfWork _service)
        {
            service = _service;
        }
        public IActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Ekle(Kurs model,int id)
        {
            model.SinavId = id;
            model.KayitTarihi = DateTime.Now;

            service.Kurs.Add(model);
            service.SaveChanges();
            return RedirectToAction(nameof(Ekle));
        }

        public IActionResult Guncelle(int kursId)
        {
            var sonuc = service.Kurs.GetAll(x => x.Id == kursId);
            return View(sonuc);
        }

        [HttpPost]
        public IActionResult Guncelle(Kurs kurs)
        {
            kurs.GuncellemeTarihi = DateTime.Now;
            service.Kurs.Update(kurs);
            service.SaveChanges();
            return RedirectToAction(nameof(Listele));
        }

        public IActionResult Sil(int kursId)
        {
            service.Kurs.SoftDelete(kursId);
            service.SaveChanges();
            return RedirectToAction(nameof(Listele));
        }

        public IActionResult CourseByDate(DateTime basTarih, DateTime bitTarih)
        {
            var liste = service.Kurs.GetAll(x => x.BaslamaTarihi == basTarih && x.BitisTarihi == bitTarih).Data;
            return View(liste);
        }

        public IActionResult Listele()
        {
            var list = service.Kurs.GetAll(x => x.SilindiMi == false).Data;
            return View(list);
        }
    }
}