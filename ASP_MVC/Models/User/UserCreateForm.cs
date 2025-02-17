using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ASP_MVC.Models.User
{
    public class UserCreateForm
    {
        [DisplayName("Prénom")]
        [Required(ErrorMessage ="Le champ est obligatoire!")]
        [MaxLength(64, ErrorMessage ="au max 64 caractere")]
        [MinLength(2,ErrorMessage = "au max 2 caractere")]
        public string First_Name { get; set; }


        [DisplayName("Nom")]
        [Required(ErrorMessage = "Le champ est obligatoire!")]
        [MaxLength(64, ErrorMessage = "au max 64 caractere")]
        [MinLength(2, ErrorMessage = "au max 2 caractere")]
        public string Last_Name { get; set; }


        [DisplayName("Email")]
        [Required(ErrorMessage = "Le champ est obligatoire!")]
        [EmailAddress]
        public string Email { get; set; }

        [DisplayName("Mot de passe")]
        [Required(ErrorMessage = "Le champ est obligatoire!")]
        [MaxLength(32, ErrorMessage = "au max 64 caractere")]
        [MinLength(8, ErrorMessage = "au max 8 caractere")]
        //[RegularExpression(@"")]
        public string Password { get; set; }

        [DisplayName("Veuillez confirmer le Mot de passe")]
        [Required(ErrorMessage = "Le champ est obligatoire!")]
        [Compare(nameof(Password),ErrorMessage ="la confirmation ne correspond pas au mot de passe")]
        public string ConfirmPassword { get; set; }

        [DisplayName("Cochez cette case")]
        [Required(ErrorMessage = "Vous devez lire et eccepter les termes d'utilisation!")]

        public bool Consent { get; set; }


    }
}
