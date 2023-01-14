using System.ComponentModel.DataAnnotations;

public class RegisterVM {
    [Required]
    [StringLength(maximumLength:25)]
    [DataType(DataType.EmailAddress)]
    [EmailAddress(ErrorMessage = "Invalid Email Address Format!")]
    public string Email { get; set; }
    
    [Required]
    [StringLength(maximumLength:20)]
    public string Firstname { get; set; }

    [Required]
    [StringLength(maximumLength:30)]
    public string Lastname { get; set; }
    
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    [Required]
    [DataType(DataType.Password)]
    [Compare(nameof(Password))]
    public string ConfirmPassword { get; set; }
    public bool Terms { get; set; }
}