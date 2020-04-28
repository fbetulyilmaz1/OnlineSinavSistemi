using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineSinavSistemi.Bll.Abstract;
using OnlineSinavSistemi.UI.Models;

namespace OnlineSinavUI.Controllers
{
    public class KursController : Controller
    {
        IUnitOfWork service;
        public KursController(IUnitOfWork _service)
        {
            service = _service;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult KursDuzenle()
        {
            return View();
        }
        public IActionResult Siniflarim()
        {
            return View();
        }

        public IActionResult Ogrencilerim()
        {
            return View();
        }

        public IActionResult SinavOlustur()
        {
            return View();
        }
    }
}