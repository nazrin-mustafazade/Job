using System.ComponentModel.DataAnnotations.Schema;
using JobMVC.Models.Identity;


namespace JobMVC.Models.EmployerModels;

public class Vacancy
{
    public Vacancy()
    {
        
    }
    public int VacancyId { get; set; }
    public string JobTitle { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public decimal MinimumSalary { get; set; }
    public decimal MaximumSalary { get; set; }
    public string JobDesciption { get; set; } = string.Empty;
    public string JobRequirements { get; set; } = string.Empty;
    [ForeignKey("AppUser")]
    public string AppUserId { get; set; }
    public AppUser AppUser { get; set; }
    
    public int ApplicantId { get; set; }
    public Applicant Applicant { get; set; }
    public string? AcceptedEmployeeId { get; set; } 
    public AppUser? AcceptedEmployee { get; set; }
    public InterviewedEmployees InterviewedEmployees { get; set; }
    // public virtual ICollection<Applicant> Applicants { get; set; }
}