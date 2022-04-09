using System.ComponentModel.DataAnnotations;

namespace Coffee_store.Models
{
    public class UserRegistrationModel
    {
        [Required]
        [StringLength(256), MinLength(5)]
        [EmailAddress]
        [Display(Name = "Login")]
        public string Email { get; set; }
        [Required]
        [StringLength(256), MinLength(5)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
        [Required]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = null!;
        [Required]
        [StringLength(256), MinLength(5)]
        [Display(Name = "First Name")]
        public string? FirstName { get; set; }
        [Required]
        [StringLength(256), MinLength(5)]
        [Display(Name = "Last Name")]
        public string? LastName { get; set; }
        [StringLength(500), MinLength(5)]
        public string? Address { get; set; }
        [StringLength(15), MinLength(5)]
        [Display(Name = "Phone number")]
        [RegularExpression(@"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$")]
        public string? PhoneNumber { get; set; }
        public bool AcceptUserAgreement { get; set; }
        public string? RegistrationInValid { get; set; } 
    }
}
