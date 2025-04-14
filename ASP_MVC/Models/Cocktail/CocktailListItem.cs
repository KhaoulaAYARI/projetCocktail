using Humanizer;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ASP_MVC.Models.Cocktail
{
    public class CocktailListItem
    {
        [ScaffoldColumn(false)]
        public Guid Cocktail_id { get; set; }

        [DisplayName("Nom de Cocktail: ")]
        public string Name { get; set; }

        [DisplayName("Description de Cocktail: ")]

        public string? Description { get; set; }
    }
}
