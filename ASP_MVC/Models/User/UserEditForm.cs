using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ASP_MVC.Models.User
{
    public class UserEditForm
    {
        [DisplayName("Prénom")]
        [Required(ErrorMessage = "Le champ est obligatoire!")]
        [MaxLength(64, ErrorMessage = "au max 64 caractere")]
        [MinLength(2, ErrorMessage = "au max 2 caractere")]
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
    }
}
