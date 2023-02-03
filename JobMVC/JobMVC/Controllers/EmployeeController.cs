using JobMVC.DataAccessLayer;
using JobMVC.Models;
using JobMVC.Models.Enums;
using JobMVC.Models.Identity;
using JobMVC.VMs.EmployeeVMs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobMVC.Controllers
{
    
    public class EmployeeController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly UserManager<AppUser> _userManager;

        public EmployeeController(AppDbContext dbContext, UserManager<AppUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        
        public async Task<IActionResult> MyCV()
        {
            AppUser userSession = await _userManager.FindByNameAsync(User.Identity?.Name);
            Cv cv =  new Cv();
            return View(cv);
        }
        
        [Authorize]
        [HttpGet]
        public IActionResult AddCv()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddCv(CvVM cvVm)
        {
            
            AppUser userSession = await _userManager.FindByNameAsync(User.Identity.Name);
            
            Cv cv = new Cv()
            {
                About = cvVm.About,
                MinimumSalary = cvVm.MinimumSalary,
                MaximumSalary = cvVm.MaximumSalary,
                Education = cvVm.Education,
                Skills = cvVm.Skills,
                Experiences = cvVm.Experiences,
                Languages = cvVm.Languages,
                Fullname = userSession.FirstName + " " + userSession.LastName,
                Email = userSession.Email,
                
        
            };
            userSession.Cv = cv;
            await _dbContext.Cvs.AddAsync(cv);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(DetailsCv));
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
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> DetailsCv()
        {
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            Cv cv = new Cv();
            if (cv is null) return RedirectToAction(nameof(AddCv));
            return View(cv);
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
