using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineSinavSistemi.Bll.Abstract;
using OnlineSinavSistemi.Model.Data;

namespace OnlineSinavSistemi.UI.Areas.Admin.Controllers
{
    public class KursDersController : AdminBaseController
    {
        IUnitOfWork service;
        public KursDersController(IUnitOfWork _service)
        {
            service = _service;
        }
        [HttpGet]
        public IActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Ekle(KursDers model)
        {
            model.KayitTarihi = DateTime.Now;
            model.SilindiMi = false;
            service.KursDers.Add(model);
            service.SaveChanges();
            return RedirectToAction(nameof(Ekle));
        }
        [HttpGet]
        public IActionResult Guncelle(int kursDersId)
        {
            var sonuc = service.KursDers.GetAll(x => x.Id == kursDersId && x.SilindiMi == false);
            return View(sonuc);
        }

        [HttpPost]
        public IActionResult Guncelle(KursDers model)
        {
            model.GuncellemeTarihi = DateTime.Now;
            service.KursDers.Update(model);
            service.SaveChanges();
            return RedirectToAction(nameof(Listele));
        }

        [HttpPost]
        public IActionResult Sil(int id)
        {

            service.KursDers.SoftDelete(id);
            service.SaveChanges();
            return RedirectToAction(nameof(Listele));
        }

      

        public IActionResult Listele()
        {
            ICollection<KursDers> liste = service.KursDers.GetAll(x => x.SilindiMi == false).Data;
            return View(liste);
        }

    }


}