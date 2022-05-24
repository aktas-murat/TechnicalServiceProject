using System.ComponentModel.DataAnnotations;

namespace TechnicalService.Web.ViewModels
{
    public class UserProfileViewModel
    {
        [Required(ErrorMessage = "Ad alanı gereklidir")]
        [Display(Name = "Ad")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soyad alanı gereklidir")]
        [Display(Name = "Soyad")]
        [StringLength(50)]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Email alanı gereklidir")]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Telefon numarası alanı gereklidir")]
        [Display(Name = "Telefon Numarası")]
        [Phone]
        public string Phone { get; set; }


        public DateTime RegisterDate { get; set; }
    }
}

