using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineSinavSistemi.Bll.Abstract;
using OnlineSinavSistemi.UI.Filters;
using OnlineSinavSistemi.UI.Models;
using OnlineSinavUI.Models;

namespace OnlineSinavUI.Controllers
{
    public class HomeController : Controller
    {
        IUnitOfWork service;
        public HomeController(IUnitOfWork _service)
        {
            service = _service;
        }
       
        [LoginFilter]
        public IActionResult Index()
        {
           
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
