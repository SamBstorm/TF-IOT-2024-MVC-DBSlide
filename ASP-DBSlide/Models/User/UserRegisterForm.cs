using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ASP_DBSlide.Models.User
{
    public class UserRegisterForm
    {
        [Required(ErrorMessage = "Est obligatoire.")]
        [DisplayName("Email : ")]
        [MinLength(5, ErrorMessage = "Veuillez indiquer un email de minimum 5 caractères")]
        [MaxLength(320, ErrorMessage = "Un email ne peut excéder 320 caractères")]
        [EmailAddress]
        public string Email {  get; set; }
        [Required(ErrorMessage = "Est obligatoire.")]
        [DisplayName("Mot de passe : ")]
        [MinLength(8, ErrorMessage = "Le mot de passe doit avoir un minimum de 8 caractères")]
        [MaxLength(64, ErrorMessage = "Le mot de passe ne doit pas excéder 64 caractères")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Est obligatoire.")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Est obligatoire.")]
        [DisplayName("Prénom : ")]
        [MinLength(2, ErrorMessage = "Veuillez indiquer un prénom de minimum 2 caractères")]
        [MaxLength(50, ErrorMessage = "Un prénom ne peut excéder 320 caractères")]
        public string First_Name { get; set; }
        [Required(ErrorMessage = "Est obligatoire.")]
        [DisplayName("Nom de famille : ")]
        [MinLength(2, ErrorMessage = "Veuillez indiquer un nom de famille de minimum 2 caractères")]
        [MaxLength(50, ErrorMessage = "Un nom de famille ne peut excéder 320 caractères")]
        public string Last_Name { get; set; }
    }
}
