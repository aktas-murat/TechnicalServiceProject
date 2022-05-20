using System.ComponentModel.DataAnnotations;

namespace TechnicalServiceProject.ViewModels
{
    public class LoginViewModel
    {
        [Display(Name = "Email Adresi")]
        [Required(ErrorMessage = "Email adresi gereklidir.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre gereklidir.")]
        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Beni Hatırla")]
        public bool RememberMe { get; set; }
    }
}
