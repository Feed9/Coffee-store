using System.ComponentModel.DataAnnotations;

namespace Coffee_store.Models
{
    public class UserLoginModel
    {
        [Required]
        [StringLength(256),MinLength(5)]
        [EmailAddress]
        [Display(Name ="Почта")]
        public string? Email { get; set; }
        [Required]
        [StringLength(256), MinLength(5)]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string? Password { get; set; }
        [Display(Name ="Запомнить меня")]
        public bool RememberMe { get; set; }
        public string? LoginInValid { get; set; }
    }
}
