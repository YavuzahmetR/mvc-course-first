using System.ComponentModel.DataAnnotations;

namespace Demo_ProductUI.Models
{
    public class UserLoginViewModel
    {
        [Required(ErrorMessage = "Lütfen Kullanucu Adını Giriniz")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Lütfen Şifre Giriniz")]
        public string Password { get; set; }
    }
}
