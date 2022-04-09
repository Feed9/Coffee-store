using System.ComponentModel.DataAnnotations;

namespace Coffee_store.Models
{
    public class UserLoginModel
    {
        [Required]
        [StringLength(256),MinLength(5)]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        [StringLength(256), MinLength(5)]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Display(Name ="Remember me")]
        public bool RememberMe { get; set; }
        public string? LoginInValid { get; set; }
    }
}
