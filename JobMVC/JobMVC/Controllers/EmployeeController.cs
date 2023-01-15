using Microsoft.AspNetCore.Mvc;

namespace JobMVC.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddCV()
        {
            return View();
        }
    }
}
