using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using NLog;
using OnlineSinavSistemi.Bll.Abstract;
using OnlineSinavSistemi.Model.Data;
using System;
using System.IO;
using ILogger = NLog.ILogger;

namespace OnlineSinavSistemi.UI.Areas.Admin.Controllers
{
    public class BransController : AdminBaseController
    {
        //IBransService service;
        //public BransController(IBransService _service)
        //{
        //    service = _service;
        //}

        IUnitOfWork service;
        ILogger nlogger;
        public BransController(IUnitOfWork _service)
        {
            service = _service;
            nlogger = LogManager.GetCurrentClassLogger();
        }

        [HttpGet]
        public IActionResult Ekle()
        {
            var list  = service.Brans.GetAll(x=> !x.SilindiMi).Data;
            //SelectList slct = new SelectList(list, "Id", "Ad");
            //ViewBag.BransList = slct;
            ViewBag.THBransList = list;
            nlogger.Info("Branş ekle sayfası açıldı.");
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Ekle(Brans model, IFormFile Foto)
        {
            //ekleme işlemi ypaulacak.
           
                if (Foto !=null)
                {
                string uzanti = Foto.FileName.Split(".")[1];
                //var filePath = "/Areas/Admin/Images/BransLogo/" + Guid.NewGuid().ToString() +"."+uzanti;
                string dosyaAdi = Guid.NewGuid().ToString() + "." + uzanti;
                var filePath = "Areas/Admin/Images/BransLogo/" + dosyaAdi;
                using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                         Foto.CopyToAsync(stream);
                    }

            model.LogoUrl = "/branslogos/"+dosyaAdi;

            }
            model.KayitTarihi = DateTime.Now;
            model.SilindiMi = false;
            service.Brans.Add(model);
          var result=  service.SaveChanges();
            TempData["Mesaj"] =result.BasariliMi ?  "Kayıt Eklendi." : result.Mesaj;
            nlogger.Info("branş ekleme gerçekleşti.");
            
            return RedirectToAction(nameof(Ekle));
        }

        public IActionResult Listele()
        {
                var listBrans = service.Brans.GetAll(x => x.SilindiMi == false).Data;
            if (listBrans.Count ==0)
                nlogger.Error("Boş olan branş tablosu listelenmeye çağırıldı.");
            return View(listBrans);
        }
    }
}