using System.ComponentModel.DataAnnotations;

namespace TechnicalServiceProject.ViewModels
{
    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage = "Yeni şifre gereklidir!")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Şifreniz minimum 6 karakterli olmalıdır!")]
        [Display(Name = "Yeni Şifre")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Şifre gereklidir.")]
        [DataType(DataType.Password)]
        [Display(Name = "Yeni Şifre Tekrarı")]
        [Compare(nameof(NewPassword), ErrorMessage = "Şifreler uyuşmuyor!")]
        public string ConfirmNewPassword { get; set; }
        public string Code { get; set; }
        public string UserId { get; set; }
    }
}
