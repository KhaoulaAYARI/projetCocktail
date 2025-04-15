using BLL_Khaoula.Entities;
using BLL_Khaoula.Mappers;
using Commun.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Khaoula.Services
{
    public class CocktailService:ICocktailRepository<Cocktail>
    {
        private ICocktailRepository<DAL_Khaoula.Entities.Cocktail> _service;
        public CocktailService(ICocktailRepository<DAL_Khaoula.Entities.Cocktail> cocktailService)
        {
            _service = cocktailService;
        }
        public IEnumerable<Cocktail> Get()
        {
            return _service.Get().Select(b=>b.ToBLL());
        }
        public Cocktail GetById(Guid Cocktail_id)
        {
            return _service.GetById(Cocktail_id).ToBLL();
        }
        public void Delete(Guid Cocktail_id) 
        {
            _service.Delete(Cocktail_id);
        }
        public Guid Insert(Cocktail cocktail) 
        {
            return _service.Insert(cocktail.ToDal());
        }
        public void Update(Guid Cocktail_id ,Cocktail cocktail ) 
        {
            _service.Update(Cocktail_id, cocktail.ToDal());
        }

    }
}
