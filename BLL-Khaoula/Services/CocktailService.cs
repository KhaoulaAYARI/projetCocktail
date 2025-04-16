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
        private ICocktailRepository<DAL_Khaoula.Entities.Cocktail> _cocktailService;
        private IUserRepository<DAL_Khaoula.Entities.User> _userService;
        public CocktailService(ICocktailRepository<DAL_Khaoula.Entities.Cocktail> cocktailService, IUserRepository<DAL_Khaoula.Entities.User> userService)
        {
            _cocktailService = cocktailService;
            _userService = userService;
        }
        public IEnumerable<Cocktail> Get()
        {
            IEnumerable<Cocktail> Cocktails= _cocktailService.Get().Select(b=>b.ToBLL());
            foreach(Cocktail cocktail in Cocktails)
            {
                if (cocktail.CreatedBy is not null)
                {
                    cocktail.Creator = _userService.GetById((Guid)cocktail.CreatedBy).ToBLL();
                }
            }
            return Cocktails;
        }
        public Cocktail GetById(Guid Cocktail_id)
        {
            Cocktail cocktail= _cocktailService.GetById(Cocktail_id).ToBLL();
            if (cocktail.CreatedBy is not null) 
            {
                cocktail.Creator = _userService.GetById((Guid)cocktail.CreatedBy).ToBLL();
            }
            return cocktail;
        }
        public void Delete(Guid Cocktail_id) 
        {
            _cocktailService.Delete(Cocktail_id);
        }
        public Guid Insert(Cocktail cocktail) 
        {
            return _cocktailService.Insert(cocktail.ToDal());
        }
        public void Update(Guid Cocktail_id ,Cocktail cocktail ) 
        {
            _cocktailService.Update(Cocktail_id, cocktail.ToDal());
        }

        public IEnumerable<Cocktail> GetFromUser(Guid user_id)
        {
            return _cocktailService.GetFromUser(user_id).Select(dal=>dal.ToBLL());
        }
    }
}
