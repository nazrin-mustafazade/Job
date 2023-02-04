using JobMVC.DataAccessLayer;
using JobMVC.Models;
using JobMVC.Models.EmployerModels;
using JobMVC.Models.Identity;
using JobMVC.VMs.EmployeeVMs;
using JobMVC.VMs.EmployerVMs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobMVC.Controllers
{
    public class EmployerController : Controller
    {
        
        private readonly AppDbContext _dbContext;
        private readonly UserManager<AppUser> _userManager;

        public EmployerController(AppDbContext dbContext, UserManager<AppUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult AddVacancy()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddVacancy(VacancyVM vacancyVm)
        {
            if (!ModelState.IsValid) return View();
            AppUser userSession = await _userManager.FindByNameAsync(User.Identity.Name);
            Applicant applicant = new Applicant()
            {
                AppUsers = new List<AppUser>()
            };
            Vacancy vacancy = new Vacancy()
            {
                JobTitle = vacancyVm.JobTitle,
                JobDesciption = vacancyVm.JobDescription,
                JobRequirements = vacancyVm.JobRequirements,
                MinimumSalary = vacancyVm.MinimumSalary,
                MaximumSalary = vacancyVm.MaximumSalary,
                AppUser = userSession,
                AppUserId = userSession.Id,
                
            };
            applicant.Vacancy = vacancy;
            vacancy.Applicant = applicant;
            await _dbContext.Vacancies.AddAsync(vacancy);
            await _dbContext.Applicants.AddAsync(applicant);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Vacancies));
        }

        [HttpGet]
        public async Task<IActionResult> DeleteVacancy(int id)
        {
            Vacancy deletedVacancy = await _dbContext.Vacancies.FindAsync(id);
            _dbContext.Vacancies.Remove(deletedVacancy);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Vacancies));

        }

        public async Task<IActionResult> Settings()
        {
            AppUser userSession = await _userManager.FindByNameAsync(User.Identity.Name);
            return View(userSession);
        }


        public async Task<IActionResult> Vacancies()
        {
            List<Vacancy> vacancies = await _dbContext.Vacancies.Include(v => v.AppUser).ToListAsync();
            
            return View(vacancies);
        }


        public IActionResult CVs()
        {
            List<Cv> cvs = _dbContext.Cvs.Include(c => c.AppUser).ToList();
            return View(cvs);
        }

        public async Task<IActionResult> DetailsCV(string id)
        {
            AppUser user = await _userManager.FindByIdAsync(id);
            Cv cv =  await _dbContext.Cvs.Include(cv=>cv.AppUser).FirstOrDefaultAsync(cv => cv.AppUser == user);
            // Cv? cv = await _dbContext.Cvs.Include(c=>c.AppUser).FirstOrDefaultAsync(cv => cv.AppUser.Id == user.Id);
            // if (cv is null) return RedirectToAction(nameof(Vacancies));
            return View(cv);
        }
        [HttpGet]
        public IActionResult Applied(int id)
        {
            var vacancy = _dbContext.Vacancies.Include(v => v.Applicant).ThenInclude(a => a.AppUsers)
                .FirstOrDefault(v => v.VacancyId == id);
            List<AppUser> users = vacancy.Applicant.AppUsers.ToList();
            VacancyEmployeeVM vacancyEmployeeVm = new VacancyEmployeeVM()
            {
                Vacancy = vacancy,
                Users = users
            };
            return View(vacancyEmployeeVm);
        }

        [HttpGet]
        public async Task<IActionResult> AcceptEmployee(string id, int vacancyid)
        {
            AppUser user = await  _userManager.FindByIdAsync(id);
            Vacancy vacancy = await _dbContext.Vacancies.FindAsync(vacancyid);
            vacancy.AcceptedEmployees.Add(user);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Applied));
        }
    }
}
