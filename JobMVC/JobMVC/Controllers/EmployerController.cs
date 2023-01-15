using Microsoft.AspNetCore.Mvc;

namespace JobMVC.Controllers
{
    public class EmployerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddVacancy()
        {
            return View();
        }
    }
}
