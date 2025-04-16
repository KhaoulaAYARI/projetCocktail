using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ASP_MVC.Models.Cocktail
{
    public class CocktailDelete
    {
        [DisplayName("Nom de Cocktail")]
        public string Name { get; set; }


        [DisplayName("Description")]
        public string? Description { get; set; }

    }
}
