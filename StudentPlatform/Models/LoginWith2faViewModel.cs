using System.ComponentModel.DataAnnotations;

namespace StudentPlatform.Models
{
    public class LoginWith2faViewModel
    {
        [Required(ErrorMessage = "Введите код")]
        [StringLength(7, ErrorMessage = "Код должен быть от {2} до {1} символов", MinimumLength = 6)]
        [DataType(DataType.Text)]
        [Display(Name = "Код подтверждения")]
        public string TwoFactorCode { get; set; } = string.Empty;
    }
}

