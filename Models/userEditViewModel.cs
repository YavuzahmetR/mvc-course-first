using System.ComponentModel.DataAnnotations;

namespace Demo_ProductUI.Models
{
    public class userEditViewModel
    {
        [Required(ErrorMessage = "Lütfen Adınızı Giriniz")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lütfen Soyad Giriniz")]
        public string SurName { get; set; }

        [Required(ErrorMessage = "Lütfen Cinsiyet Giriniz")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Lütfen Mail Giriniz")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Lütfen Şifre Giriniz")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Lütfen Şifre Giriniz")]
        [Compare("Password", ErrorMessage = "Şifre Aynı Değil!")]
        public string ConfirmPassword { get; set; }
    }
}
