using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace OnlineSinavUI.Controllers
{
    public class DerslerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Derslerim()
        {
            return View();
        }
        public IActionResult DersListesi()
        {
            return View();
        }

        public IActionResult DersSayfasi()
        {
            return View();
        }
    }
}