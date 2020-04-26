using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineSinavSistemi.Bll.Abstract;
using OnlineSinavSistemi.Model.Data;

namespace OnlineSinavSistemi.UI.Areas.Admin.Controllers
{
    public class SikayetController : AdminBaseController
    {
        IUnitOfWork service;
        public SikayetController(IUnitOfWork _service)
        {
            service = _service;
        }
        public IActionResult Listele()
        {
            ICollection<Sikayet> liste = service.Sikayet.GetAll(x => x.SilindiMi == false).Data;
            return View(liste);
        }

        [HttpPost]
        public IActionResult Sil(int id)
        {
            service.Sikayet.SoftDelete(id);
            service.SaveChanges();
            return RedirectToAction(nameof(Listele));
        }
    }
}