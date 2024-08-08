using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASP_DBSlide.Models.User
{
    public class UserLoginForm
    {
        [Required(ErrorMessage ="Est obligatoire.")]
        [DisplayName("Email : ")]
        [MinLength(5, ErrorMessage ="Veuillez indiquer un email de minimum 5 caractères")]
        [MaxLength(320, ErrorMessage = "Un email ne peut excéder 320 caractères")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Est obligatoire.")]
        [DisplayName("Mot de passe : ")]
        [MinLength(8, ErrorMessage = "Le mot de passe doit avoir un minimum de 8 caractères")]
        [MaxLength(64, ErrorMessage = "Le mot de passe ne doit pas excéder 64 caractères")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
