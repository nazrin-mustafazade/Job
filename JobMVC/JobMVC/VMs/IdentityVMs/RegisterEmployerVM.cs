namespace JobMVC.VMs.IdentityVMs;

public class RegisterEmployerVM
{
    public string CompanyName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public int EmployerSize { get; set; }
    public DateTime EstablishDate { get; set; }
    public string Category { get; set; }
    public string Country { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string? State { get; set; }
    public IFormFile ProfileImage { get; set; }
    
}