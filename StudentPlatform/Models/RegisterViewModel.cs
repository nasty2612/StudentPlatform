using System.ComponentModel.DataAnnotations;

namespace StudentPlatform.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Введите Email")]
        [EmailAddress(ErrorMessage = "Некорректный адрес")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Повторите пароль")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        public string? ConfirmPassword { get; set; }
    }
}

