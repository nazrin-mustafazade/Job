using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JobMVC.Controllers
{
    public class AdminController : Controller
    {
        // GET: /<controller>/
        public IActionResult Employer()
        {
            return View();
        }

        public IActionResult Employee()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}

