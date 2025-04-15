using Humanizer;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASP_MVC.Models.Cocktail
{
    public class CocktailDetails
    {
        [ScaffoldColumn(false)]
        public Guid Cocktail_id { get; set; }


        [DisplayName("Nom de Cocktail")]
        public string Name { get; set; }


        [DisplayName("Description")]
        [DataType(DataType.MultilineText)]
        public string? Description { get; set; }


        [DisplayName("Instructions")]
        [DataType(DataType.MultilineText)]
        public string Instructions { get; set; }


        [DisplayName("Date de Creation")]
        [DataType(DataType.Date)]
        public DateOnly CreatedAt { get; set; }


        [DisplayName("Createur de Cocktail")]
        public Guid? CreatedBy { get; set; }
    }
}
