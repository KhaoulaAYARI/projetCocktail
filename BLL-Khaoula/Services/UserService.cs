using BLL_Khaoula.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL_Khaoula.Mappers;
using D=DAL_Khaoula.Entities;
using Commun.Repositories;

namespace BLL_Khaoula.Services
{
    public class UserService: IUserRepository<User>
    {
        private IUserRepository<D.User> _userService;
        private ICocktailRepository<D.Cocktail> _cocktailService;
        public UserService(IUserRepository<D.User> userService, ICocktailRepository<D.Cocktail> cocktailService )
        {
            _userService = userService;
            _cocktailService = cocktailService;
        }

        public IEnumerable<User> Get()
        {
            return _userService.Get().Select(dal=>dal.ToBLL());
        }
        public User GetById(Guid id) 
        {
            User user= _userService.GetById(id).ToBLL();
            user.Cocktails=_cocktailService.GetFromUser(id).Select(dal=>dal.ToBLL());
            return user;
        }
        public Guid Insert(User user)
        {
           return _userService.Insert(user.ToDAL());
        }
        public void Update (Guid id, User user)
        {
            _userService.Update(id, user.ToDAL());
        }
        public void Delete(Guid id)
        {
            _userService.Delete(id);
        }
        public Guid CheckPassword( string email,string password) 
        { 
            return _userService.CheckPassword(email, password);
        }
    }
}
