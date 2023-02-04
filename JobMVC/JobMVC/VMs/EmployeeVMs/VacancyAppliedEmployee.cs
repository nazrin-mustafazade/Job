using JobMVC.Models.EmployerModels;
using JobMVC.Models.Identity;

namespace JobMVC.VMs.EmployeeVMs;

public class VacancyAppliedEmployee
{
    public AppUser Employee { get; set; }
    public List<Vacancy> Vacancies { get; set; }
    
}