using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using JobMVC.Models.Identity;

namespace JobMVC.Models;

public class Cv
{
    public int Id { get; set; }
    public string Fullname { get; set; }
    public string? JobTitle { get; set; }
    public string About { get; set; }
    public decimal MinimumSalary { get; set; }
    public decimal MaximumSalary { get; set; }
    public string Education { get; set; }
    public string Skills { get; set; }
    public string Experiences { get; set; }
    public string Languages { get; set; }

    public string? Contact { get; set; }

    //one to one relation 

    public string AppUserId { get; set; }
    public AppUser AppUser { get; set; }
    
}