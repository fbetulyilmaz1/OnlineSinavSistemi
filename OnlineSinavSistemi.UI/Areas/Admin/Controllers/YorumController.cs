using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineSinavSistemi.Bll.Abstract;

namespace OnlineSinavSistemi.UI.Areas.Admin.Controllers
{
    public class YorumController : AdminBaseController
    {
        IUnitOfWork service;
        public YorumController(IUnitOfWork _service)
        {
            service = _service;
        }

        [HttpGet]
        public IActionResult Listele()
        {
            var list = service.Yorum.GetAll(x => x.SilindiMi == false);
            return View(list);
        }

        [HttpPost]
        public IActionResult Silme(int yorumId)
        {
            service.Yorum.SoftDelete(yorumId);
            service.SaveChanges();
            return RedirectToAction(nameof(Listele));

        }
    }
}