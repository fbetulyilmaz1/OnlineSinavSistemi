using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using OnlineSinavSistemi.Bll.Abstract;
using OnlineSinavSistemi.Model.Data;

namespace OnlineSinavSistemi.UI.Areas.Admin.Controllers
{
    [EnableCors("AllowOrigin")]
    public class SoruController : AdminBaseController
    {
        IUnitOfWork service;
        public SoruController(IUnitOfWork _service)
        {
            service = _service;
        }
        public IActionResult Listele()
        {
            ICollection<Soru> liste = service.Soru.GetAll(x => x.SilindiMi == false).Data;
            return View(liste);
        }


        [HttpGet]
        public IActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Ekle(Soru model)
        {            
            model.KayitTarihi = DateTime.Now;
            model.SilindiMi = false;
            service.Soru.Add(model);
            service.SaveChanges();
            return RedirectToAction(nameof(Ekle));
        }


        [HttpPost]
        public IActionResult Sil(int id)
        {
            service.Soru.SoftDelete(id);
            service.SaveChanges();
            return RedirectToAction(nameof(Listele));
        }



        public IActionResult Guncelle(int SoruId)
        {
            var sonuc = service.Soru.GetAll(x => x.Id == SoruId && x.SilindiMi == false).Data;
            return View(sonuc);
        }

        [HttpPost]
        public IActionResult Guncelle(Soru model)
        {
            //ekleme işlemi ypaulacak.
            model.GuncellemeTarihi = DateTime.Now;
            service.Soru.Update(model);
            service.SaveChanges();
            return RedirectToAction(nameof(Listele));
        }

        [HttpGet]
        public IActionResult SoruGetByKursID(int bransId)
        {
            var sonuc = service.Soru.GetAll(x => x.BransId == bransId);
            return View(sonuc);
        }
      
    }
}