using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobMVC.Models.Enums;
using JobMVC.Models.Identity;
using JobMVC.VMs.IdentityVMs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using NuGet.Protocol.Plugins;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JobMVC.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }
        
        [HttpGet]
        public IActionResult RegisterEmployer()
        {
            return View();
        }
        [HttpGet]
        public IActionResult RegisterEmployee()
        {
            return View();
        }

        [HttpGet]
        public async Task CreateRoles()
        {
            foreach (var role in Enum.GetNames(typeof(Roles)))
            {
                if (!await _roleManager.RoleExistsAsync(role))
                {
                   await _roleManager.CreateAsync(new IdentityRole() { Name = role });
                }
            }
        }
        [HttpPost]
        public async Task<IActionResult> RegisterEmployee(RegisterVM registerVm)
        {
            
            if (!ModelState.IsValid) return BadRequest();

            var file = registerVm.ImageProfile;
            string newFileName = "";
            if (file.FileName.Length > 50)
            {
                newFileName = file.FileName.Substring(40);
            }
            else
            {
                newFileName = file.FileName;
            }
            
            using (var writer = new FileStream(@"wwwroot/images/"+ newFileName, FileMode.Create))
            {
                file.CopyTo(writer);
            }
            AppUser createdUser = new AppUser()
            {
                FirstName = registerVm.Firstname,
                LastName = registerVm.Lastname,
                PhoneNumber = registerVm.PhoneNumber,
                Address = registerVm.Address,
                State = registerVm.State,
                Email = registerVm.Email,
                UserName = registerVm.Email,
                City = registerVm.City,
                Country = registerVm.Country,
                ImageUrl = newFileName

            };
            IdentityResult createUserResult = await _userManager.CreateAsync(createdUser, registerVm.Password);
            await _userManager.AddToRoleAsync(createdUser, Roles.Employee.ToString());
            if (!createUserResult.Succeeded)
            {
                return View();
            }

            return RedirectToAction(nameof(LoginEmployee));

        }
        //
        // [HttpPost]
        // public IActionResult RegisterAdmin()
        // {
        //     return View();
        // }

        [HttpPost]
        public async Task<IActionResult> RegisterEmployer(RegisterEmployerVM registerEmployerVm)
        {
            if (!ModelState.IsValid) return View();
            var file = registerEmployerVm.ProfileImage;
            string newFileName = "";
            if (file.FileName.Length > 50)
            {
                newFileName = file.FileName.Substring(40) + ".jpg";
            }
            else
            {
                newFileName =  Guid.NewGuid().ToString() + ".jpg";
            }
            
            using (var writer = new FileStream(@"wwwroot/images/"+ newFileName, FileMode.Create))
            {
                file.CopyTo(writer);
            }
            AppUser createdEmployer = new AppUser()
            {
                Company = registerEmployerVm.CompanyName,
                Email = registerEmployerVm.Email,
                UserName = registerEmployerVm.Email,
                EmployerSize = registerEmployerVm.EmployerSize,
                EstablishDate = registerEmployerVm.EstablishDate.ToUniversalTime(),
                Category = registerEmployerVm.Category,
                Country = registerEmployerVm.Country,
                PhoneNumber = registerEmployerVm.PhoneNumber,
                Address = registerEmployerVm.Address,
                City = registerEmployerVm.City,
                State = registerEmployerVm.State,
                ImageUrl = newFileName
            };
            IdentityResult employerCreate = await _userManager.CreateAsync(createdEmployer, registerEmployerVm.Password);
            await _userManager.AddToRoleAsync(createdEmployer, Roles.Employer.ToString());
            if (!employerCreate.Succeeded)
            {
                return View();
            }
            return RedirectToAction(nameof(LoginEmployer));
        }

        // [HttpPost]
        // public IActionResult Login(int id)
        // {
        //     // return View();
        // }

        [HttpGet]
        public IActionResult LoginEmployee()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LoginEmployee(LoginVM loginEmployeeVm, string? ReturnUrl)
        {
            if (!ModelState.IsValid) return View();
            AppUser userLogin = await _userManager.FindByEmailAsync(loginEmployeeVm.Email);
            if (userLogin is null)
            {
                ModelState.AddModelError("", "Login error");
                return View();
            }

            var signInResult =
               await _signInManager.PasswordSignInAsync(userLogin, loginEmployeeVm.Password, false, false);
            if (!signInResult.Succeeded)
            {
                ModelState.AddModelError("", "Login error");
                return View();
            }
            return RedirectToAction("Vacancies", "Employee");
        }

        [HttpGet]
        public IActionResult LoginEmployer()
        {
            return View();
        }

        
        [HttpPost]
        public async Task<IActionResult> LoginEmployer(LoginVM loginEmployerVm)
        {
            if (!ModelState.IsValid) return View();
            AppUser userLogin = await _userManager.FindByEmailAsync(loginEmployerVm.Email);
            if (userLogin is null)
            {
                ModelState.AddModelError("", "Login error");
                return View();
            }

            var signInResult =
                await _signInManager.PasswordSignInAsync(userLogin, loginEmployerVm.Password, true, false);
            if (!signInResult.Succeeded)
            {
                ModelState.AddModelError("", "Login error");
                return View();
            }
            return RedirectToAction("Vacancies", "Employer");
        }
        
        [HttpGet]
        public async Task<IActionResult> Signout()
        {  
            await _signInManager.SignOutAsync(); 
            return RedirectToAction("Index", "Home");
        }
                
                
    }
}

