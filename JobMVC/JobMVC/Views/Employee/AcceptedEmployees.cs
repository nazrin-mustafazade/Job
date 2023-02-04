using JobMVC.Models.EmployerModels;
using JobMVC.Models.Identity;

namespace JobMVC.Views.Employee;

public class AcceptedEmployees
{
    public int Id { get; set; }
    public List<AppUser> Employees { get; set; }
    
    public int VacancyId { get; set; }
    public Vacancy Vacancy { get; set; }
    
}