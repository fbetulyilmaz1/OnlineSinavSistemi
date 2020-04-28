using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace OnlineSinavUI.Controllers
{
    public class SinavController : Controller
    {
       
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Sinav()
        {
            return View();
        }

        public IActionResult SinavGirisYeri()
        {
            return View();
        }
    }
}