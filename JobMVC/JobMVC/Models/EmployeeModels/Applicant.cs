using JobMVC.Models.EmployerModels;
using JobMVC.Models.Identity;

namespace JobMVC.Models;

public class Applicant
{
    public Applicant()
    {
        this.AppUsers = new HashSet<AppUser>();
    }
    public int Id { get; set; }
    public virtual ICollection<AppUser> AppUsers { get; set; }
    public Vacancy Vacancy { get; set; }
}