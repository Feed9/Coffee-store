using System.ComponentModel.DataAnnotations;

namespace Coffee_store.Models
{
    public class UserRegistrationModel
    {
        [Required]
        [StringLength(256), MinLength(5)]
        [EmailAddress]
        [Display(Name = "Почта")]
        public string Email { get; set; }
        [Required]
        [StringLength(256), MinLength(5)]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; } = null!;
        [Required]
        [Compare("Password")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтверждение пароля")]
        public string ConfirmPassword { get; set; } = null!;
        [Required]
        [StringLength(256), MinLength(5)]
        [Display(Name = "Имя")]
        public string? FirstName { get; set; }
        [Required]
        [StringLength(256), MinLength(5)]
        [Display(Name = "Фамилия")]
        public string? LastName { get; set; }

        [StringLength(15), MinLength(5)]
        [Display(Name = "Номер телефона")]
        [RegularExpression(@"^(\+7|7|8)?[\s\-]?\(?[489][0-9]{2}\)?[\s\-]?[0-9]{3}[\s\-]?[0-9]{2}[\s\-]?[0-9]{2}$",
            ErrorMessage = "Некорректный формат номера")]
        public string? PhoneNumber { get; set; }
        public bool AcceptUserAgreement { get; set; }
        public string? RegistrationInValid { get; set; }
    }
}
