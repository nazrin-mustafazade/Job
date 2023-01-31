using Microsoft.AspNetCore.Mvc;

namespace JobMVC.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MyCV()
        {
            return View();
        }
        public IActionResult AddCV()
        {
            return View();
        }
        public IActionResult Applied()
        {
            return View();
        }

        public IActionResult Vacancies()
        {
            return View();
        }


        public IActionResult CVs()
        {
            return View();
        }

        public IActionResult DetailsCV()
        {
            return View();
        }

        public IActionResult Settings()
        {
            return View();
        }

        public IActionResult DetailsVacancy()
        {
            return View();
        }
    }
}
