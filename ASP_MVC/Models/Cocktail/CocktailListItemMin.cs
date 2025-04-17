using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ASP_MVC.Models.Cocktail
{
    public class CocktailListItemMin
    {
        [ScaffoldColumn(false)]
        public Guid Cocktail_id { get; set; }

        [DisplayName("Nom de Cocktail: ")]
        public string Name { get; set; }
    }
}
