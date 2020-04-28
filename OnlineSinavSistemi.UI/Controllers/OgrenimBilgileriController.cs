using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace OnlineSinavUI.Controllers
{
    public class OgrenimBilgileriController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SinavSonuclariveNotlari()
        {
            return View();
        }

        public IActionResult Sertifikalarim()
        {
            return View();
        }
        public IActionResult SertifikaDetay()
        {
            return View();
        }
    }
}