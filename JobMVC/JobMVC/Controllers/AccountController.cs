using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JobMVC.Controllers
{
    public class AccountController : Controller
    {
        [HttpPost]
        public IActionResult RegisterEmployee(int id)
        {
            return View();
        }
        [HttpGet]
        public IActionResult RegisterEmployer()
        {
            return View();
        }
        [HttpGet]
        public IActionResult RegisterEmployee()
        {
            var Countries = Enum.GetNames(typeof(Country));
            return View(Countries);
        }

        [HttpPost]
        public IActionResult RegisterAdmin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterEmployer(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(int id)
        {
            return View();
        }

        [HttpGet]
        public IActionResult LoginEmployee()
        {
            return View();
        }

        [HttpGet]
        public IActionResult LoginEmployer()
        {
            return View();
        }

    }
}

