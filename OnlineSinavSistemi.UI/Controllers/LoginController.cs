using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using OnlineSinavSistemi.UI.Filters;

namespace OnlineSinavUI.Controllers
{
    public class LoginController : Controller
    {
        [MyExceptionFilter]
        public IActionResult Index()
        {
            throw new Exception();
        }
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Lock()
        {
            return View();
        }
    }
}