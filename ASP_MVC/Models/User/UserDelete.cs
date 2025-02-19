using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASP_MVC.Models.User
{
    public class UserDelete
    {
        [DisplayName("Prenom :")]
        public string First_Name { get; set; }

        [DisplayName("Nom :")]
        public string Last_Name { get; set; }

        [DisplayName("Email :")]
        [DataType(DataType.Password)]
        public string Email { get; set; }
    }
}
