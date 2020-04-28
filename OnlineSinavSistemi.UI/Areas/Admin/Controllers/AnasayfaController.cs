using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineSinavSistemi.UI.Areas.Admin.Controllers;

namespace OnlineSinavUI.Areas.Admin.Controllers
{
    public class AnasayfaController : AdminBaseController
    {
      
        public IActionResult Index()
        {
            return View();
        }
    }
}