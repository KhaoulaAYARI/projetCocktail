using BLL_Khaoula.Entities;
using BLL_Khaoula.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Khaoula.Services
{
    public class CocktailService
    {
        private DAL_Khaoula.Srvices.CocktailService _service;
        public CocktailService()
        {
            _service =new DAL_Khaoula.Srvices.CocktailService();
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
