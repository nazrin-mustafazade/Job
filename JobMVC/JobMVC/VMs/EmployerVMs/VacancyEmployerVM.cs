using JobMVC.Models.EmployerModels;
using JobMVC.Models.Identity;

namespace JobMVC.VMs.EmployerVMs
{
    public class VacancyEmployerVM
    {
        public List<Vacancy> Vacancies { get; set; }
        public AppUser Employer { get; set; }
    }
}
