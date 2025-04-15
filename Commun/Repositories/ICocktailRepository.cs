using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commun.Repositories
{
    public interface ICocktailRepository<TCocktail>
    {
        public IEnumerable<TCocktail> Get();
        public TCocktail GetById(Guid Cocktail_id);
        public void Delete(Guid Cocktail_id);
        public Guid Insert(TCocktail cocktail);
        public void Update(Guid Cocktail_id, TCocktail cocktail);

    }
}
