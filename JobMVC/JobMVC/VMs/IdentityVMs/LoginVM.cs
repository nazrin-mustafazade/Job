using System.ComponentModel.DataAnnotations;

namespace JobMVC.VMs.IdentityVMs;

public class LoginVM
{
    [DataType(DataType.EmailAddress)]
    [Required]
    public string Email { get; set; }
    [DataType(DataType.Password)]
    [Required]
    public string Password { get; set; }
    
    
}