using JobMVC.Models.EmployerModels;
using JobMVC.Models.Identity;

namespace JobMVC.VMs.EmployeeVMs;

public class VacanciesEmployeeVM
{
    public List<Vacancy> Vacancies { get; set; }
    public AppUser User { get; set; }
    
}