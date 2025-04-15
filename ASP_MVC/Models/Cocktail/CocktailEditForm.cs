using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ASP_MVC.Models.Cocktail
{
    public class CocktailEditForm
    {

        [DisplayName("Nom de Cocktail")]
        [Required(ErrorMessage = "Le champ nom est obligatoire")]
        [MaxLength(64, ErrorMessage = "le champ doit contenir au max 64 caracteres")]
        [MinLength(2, ErrorMessage = "le champ doit contenir au min 2 caracteres")]
        public string Name { get; set; }


        [DisplayName("Description")]
        [MaxLength(64, ErrorMessage = "le champ doit contenir au max 512 caracteres")]
        [MinLength(2, ErrorMessage = "le champ doit contenir au min 2 caracteres")]
        [DataType(DataType.MultilineText)]
        public string? Description { get; set; }


        [DisplayName("Instructions")]
        [Required(ErrorMessage = "Le champ Instructions est obligatoire")]
        [MaxLength(64, ErrorMessage = "le champ doit contenir au max 512 caracteres")]
        [MinLength(2, ErrorMessage = "le champ doit contenir au min 2 caracteres")]
        [DataType(DataType.MultilineText)]
        public string Instructions { get; set; }


        
    }
}
