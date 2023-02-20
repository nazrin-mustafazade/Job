using JobMVC.DataAccessLayer;
using JobMVC.Models;
using JobMVC.Models.EmployerModels;
using JobMVC.Models.Identity;
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
                Category="salam",
                MinimumSalary = vacancyVm.MinimumSalary,
                MaximumSalary = vacancyVm.MaximumSalary,
                AppUser = userSession,
                AppUserId = userSession.Id,
                InterviewedEmployees = new InterviewedEmployees()
                {
                    Employees = new List<AppUser>()
                },
                RejectedEmployees = new RejectedEmployees()
                {
                    Employees = new List<AppUser>()
                }
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
            Vacancy deletedVacancy = await _dbContext.Vacancies.FirstOrDefaultAsync(v=> v.VacancyId == id);
            if (deletedVacancy is null) return RedirectToAction(nameof(Vacancies));
            _dbContext.Vacancies.Remove(deletedVacancy);
            return RedirectToAction(nameof(Vacancies));

        }

        public async Task<IActionResult> Settings()
        {
            AppUser userSession = await _userManager.FindByNameAsync(User.Identity.Name);
            return View(userSession);
        }


        public async Task<IActionResult> Vacancies()
        {
            VacancyEmployerVM vacancyEmployerVM = new VacancyEmployerVM();
            AppUser usersession = await _userManager.FindByNameAsync(User.Identity.Name);
            List<Vacancy> vacancies = await _dbContext.Vacancies.Include(v => v.AppUser).Where(v=> v.AppUser.Id==usersession.Id).ToListAsync();
            vacancyEmployerVM.Employer = usersession;
            vacancyEmployerVM.Vacancies = vacancies;
            return View(vacancyEmployerVM);
        }


        public IActionResult CVs()
        {
            List<Cv> cvs = _dbContext.Cvs.Include(c => c.AppUser).ToList();
            return View(cvs);
        }

        public async Task<IActionResult> DetailsCV(string id)
        {
            AppUser user = await _userManager.FindByIdAsync(id);
           
            Cv cv =  await _dbContext.Cvs.Include(c=>c.AppUser).FirstOrDefaultAsync(c => c.AppUser.Id == user.Id);
            // Cv? cv = await _dbContext.Cvs.Include(c=>c.AppUser).FirstOrDefaultAsync(cv => cv.AppUser.Id == user.Id);
            // if (cv is null) return RedirectToAction(nameof(Vacancies));
            if (cv is null) return RedirectToAction(nameof(Vacancies));
           return View(cv);
        }
        [HttpGet]
        public IActionResult Applied(int id)
        {
            var vacancy = _dbContext.Vacancies.Include(v => v.Applicant).ThenInclude(a => a.AppUsers)
                .Include(v=> v.InterviewedEmployees).ThenInclude(ie=> ie.Employees)
                .Include(v=> v.AcceptedEmployee)
                .Include(v=>v.RejectedEmployees).ThenInclude(re=>re.Employees)
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
            Vacancy? vacancy =  _dbContext.Vacancies.Include(v => v.AcceptedEmployee)
                .FirstOrDefault(v => v.VacancyId == vacancyid);
            if (vacancy == null) return RedirectToAction(nameof(Vacancies));
            if (!(vacancy.AcceptedEmployee is null)) return BadRequest();
            vacancy.AcceptedEmployee=user;
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Vacancies));
        }

        [HttpGet]
        public async Task<IActionResult> InterviewEmployee(string id, int vacancyid)
        {
            AppUser user = await _userManager.FindByIdAsync(id);
            Vacancy vacancy = _dbContext.Vacancies.Include(v => v.AcceptedEmployee)
                .Include(v=>v.InterviewedEmployees).ThenInclude(ie=>ie.Employees)
                .FirstOrDefault(v => v.VacancyId == vacancyid);
            if (vacancy.InterviewedEmployees is null)
            {
                vacancy.InterviewedEmployees = new InterviewedEmployees()
                {
                    Employees = new List<AppUser>()
                };
            }
            if (vacancy.InterviewedEmployees.Employees.Contains(user)) return BadRequest();
            vacancy.InterviewedEmployees.Employees.Add(user);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Vacancies));
        }
        
        [HttpGet]
        public async Task<IActionResult> RejectEmployee(string id, int vacancyid)
        {
            AppUser user = await  _userManager.FindByIdAsync(id);
            Vacancy? vacancy =  _dbContext.Vacancies.Include(v => v.AcceptedEmployee)
                .Include(v=>v.InterviewedEmployees).ThenInclude(ie=> ie.Employees)
                .Include(v=> v.RejectedEmployees).ThenInclude(re=> re.Employees)
                .FirstOrDefault(v => v.VacancyId == vacancyid);
            if (vacancy == null) return RedirectToAction(nameof(Vacancies));
            if (vacancy.InterviewedEmployees is null)
            {
                vacancy.InterviewedEmployees = new InterviewedEmployees()
                {
                    Employees = new List<AppUser>()
                };
            }

            if (vacancy.RejectedEmployees is null)
            {
                vacancy.RejectedEmployees = new RejectedEmployees()
                {
                    Employees = new List<AppUser>()
                };
            }
            vacancy.InterviewedEmployees.Employees.Remove(user);
            vacancy.RejectedEmployees.Employees.Add(user);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Vacancies));
        }
    }
}
