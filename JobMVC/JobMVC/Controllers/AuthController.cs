using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JobMVC.Controllers
{
    public class AuthController : Controller
    {
        [HttpPost]
        public IActionResult RegisterEmployee()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterAdmin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterEmployer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoginEmployee()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoginAdmin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult LoginEmployer()
        {
            return View();
        }


    }
}

