using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ASP_MVC.Models.Auth
{
    public class AuthLoginForm
    {
        [DisplayName("Email")]
        [Required(ErrorMessage = "Le champ est obligatoire!")]
        [EmailAddress]
        public string Email { get; set; }

        [DisplayName("Mot de passe")]
        [Required(ErrorMessage = "Le champ est obligatoire!")]
        [MaxLength(32, ErrorMessage = "au max 64 caractere")]
        [MinLength(8, ErrorMessage = "au max 8 caractere")]
        [DataType(DataType.Password)]
        //[RegularExpression(@"")]
        public string Password { get; set; }

    }
}
