using JobMVC.Models.Identity;

namespace JobMVC.Models.EmployerModels;

public class RejectedEmployees
{
    public int Id { get; set; }
    public List<AppUser> Employees { get; set; }

    public int VacancyId { get; set; }
    public Vacancy Vacancy { get; set; }
}