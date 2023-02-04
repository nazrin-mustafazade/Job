using JobMVC.Models.EmployerModels;
using JobMVC.Models.Identity;

namespace JobMVC.VMs.EmployerVMs;

public class VacancyEmployeeVM
{
    public Vacancy Vacancy { get; set; }
    public List<AppUser> Users { get; set; }
}