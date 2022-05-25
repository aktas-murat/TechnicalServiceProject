using System.ComponentModel.DataAnnotations;

namespace TechnicalService.Web.ViewModels
{
    public class RegisterViewModel
    {
        private string _phone;

        //[Display(Name = "Kullanıcı Adı")]
        //[Required(ErrorMessage = "Kullanıcı adı gereklidir.")]
        //public string UserName { get; set; }

        [Display(Name = "Ad")]
        [Required(ErrorMessage = "Ad gereklidir.")]
        [StringLength(50)]
        public string Name { get; set; }

        [Display(Name = "Soyad")]
        [Required(ErrorMessage = "Soyad gereklidir.")]
        [StringLength(50)]
        public string Surname { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "E-Posta gereklidir.")]
        public string Email { get; set; }

        //[Required(ErrorMessage = "Telefon numarası alanı gereklidir")]
        //[Display(Name = "Telefon Numarası")]
        //[Phone(ErrorMessage = "Lütfen geçerli bir telefon numarası giriniz.")]
        //public string Phone
        //{
        //    get
        //    {
        //        return _phone;
        //    }
        //    set
        //    {
        //        if (value.Length != 11)
        //            throw new ValidationException("Telefon numarası 10 karakterli olmalı");

        //        if (value.Substring(0, 1) != "0")
        //            throw new ValidationException("Telefon numarası 0 ile başlamalıdır");

        //        foreach (var item in value)
        //        {
        //            if (!char.IsDigit(item))
        //            {
        //                throw new ValidationException("Telefon numarasında sadece rakam bulunmalıdır");
        //            }
        //        };
        //    }
        //}

        [Required(ErrorMessage = "Telefon numarası alanı gereklidir")]
        [Display(Name = "Telefon Numarası")]
        [Phone(ErrorMessage ="Lütfen geçerli bir numara giriniz.")]
        public string Phone { get; set; }

        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Şifre gereklidir.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Şifreniz minimum 6 karakterli olmalıdır!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Şifre Tekrarı")]
        [Required(ErrorMessage = "Şifre tekrarı gereklidir.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Şifreler uyuşmuyor!")]
        public string ConfirmPassword { get; set; }
    }
}