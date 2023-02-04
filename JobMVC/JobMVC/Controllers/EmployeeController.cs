using JobMVC.DataAccessLayer;
using JobMVC.Models;
using JobMVC.Models.EmployerModels;
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
                AppUser = userSession,
                AppUserId = userSession.Id
        
            };
            userSession.Cv = cv;
            await _dbContext.Cvs.AddAsync(cv);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(DetailsCv));
        }
        public async Task<IActionResult> Applied()
        {
            AppUser userSession = await _userManager.FindByNameAsync(User.Identity.Name);
            List<Vacancy> vacancies = _dbContext.Vacancies.Include(v=> v.AcceptedEmployees).ThenInclude(ae=>ae.Employees).Include(v=>v.AppUser).Include(v => v.Applicant).ThenInclude(a => a.AppUsers)
                .Where(v => v.Applicant.AppUsers.Contains(userSession)).ToList();
            VacancyAppliedEmployee vm = new VacancyAppliedEmployee()
            {
                Vacancies = vacancies,
                Employee = userSession
            };
            return View(vm);
        }

        public async Task<IActionResult> Vacancies()
        {
            AppUser userSession = await _userManager.FindByNameAsync(User.Identity.Name);
            List<Vacancy> vacancies =
                 _dbContext.Vacancies.Include(v=>v.AppUser).Include(v => v.Applicant).ThenInclude(a => a.AppUsers).ToList();
            VacanciesEmployeeVM vm = new VacanciesEmployeeVM()
            {
                User = userSession,
                Vacancies = vacancies
            };
            return View(vm);
        }

        [HttpGet]
        public IActionResult CVs()
        {
            List<Cv> cvs = _dbContext.Cvs.Include(c => c.AppUser).ToList();
            return View(cvs);
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> DetailsCv(string id)
        {
            AppUser user = await _userManager.FindByIdAsync(id);
            Cv? cv = await _dbContext.Cvs.FirstOrDefaultAsync(cv => cv.AppUserId == user.Id);
            if (cv is null) return RedirectToAction(nameof(AddCv));
            return View(cv);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCv()
        {
            AppUser userSession = await _userManager.FindByNameAsync(User.Identity.Name);
            Cv? cv = await _dbContext.Cvs.FirstOrDefaultAsync(cv => cv.AppUserId == userSession.Id);
            if (cv is null) RedirectToAction(nameof(AddCv));
            return View(cv);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCv(CvVM cvVm)
        {
            AppUser userSession = await _userManager.FindByNameAsync(User.Identity.Name);
            Cv? oldCv = await _dbContext.Cvs.FirstOrDefaultAsync(cv => cv.AppUserId == userSession.Id);
            oldCv.About = cvVm.About;
            oldCv.MinimumSalary = cvVm.MinimumSalary;
            oldCv.MaximumSalary = cvVm.MaximumSalary;
            oldCv.Education = cvVm.Education;
            oldCv.Skills = cvVm.Skills;
            oldCv.Languages = cvVm.Languages;
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(DetailsCv));

        }

        [HttpGet]
        public async Task<IActionResult> ApplyToVacancy(int id)
        {
            AppUser userSession = await _userManager.FindByNameAsync(User.Identity.Name);
            Vacancy? vacancy = _dbContext.Vacancies.Include(v => v.Applicant).ThenInclude(a => a.AppUsers).FirstOrDefault(v=>v.VacancyId == id);
            vacancy.Applicant.AppUsers.Add(userSession);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Applied));
        }

        public IActionResult Settings()
        {
            return View();
        }
        [HttpGet]
        public IActionResult DetailsVacancy(int id)
        {
            Vacancy vacancy = _dbContext.Vacancies.Include(v=>v.AppUser).FirstOrDefault(v => v.VacancyId == id);
            return View(vacancy);
        }
    }
}
