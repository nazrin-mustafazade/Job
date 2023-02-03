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
    public string PhoneNumber { get; set; }
    
    [Required]
    public string Country { get; set; }
    
    [Required]
    public string Address { get; set; }
    
    [Required]
    public string City { get; set; }
    
    [Required]
    public string Zip { get; set; }
    
    [Required]
    public string State { get; set; }
    

    public bool isEmployer { get; set; } = false;

}