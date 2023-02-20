namespace JobMVC.VMs.EmployerVMs;

public class VacancyVM
{
    public string JobTitle { get; set; }
    public string? Category { get; set; }
    public string JobDescription { get; set; }
    public decimal MinimumSalary { get; set; }
    public decimal MaximumSalary { get; set; }
    public string JobRequirements { get; set; }
    
}