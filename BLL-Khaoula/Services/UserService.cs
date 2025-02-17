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
        private IUserRepository<D.User> _service;
        public UserService(IUserRepository<D.User> userService)
        {
            _service= userService;
        }

        public IEnumerable<User> Get()
        {
            return _service.Get().Select(dal=>dal.ToBLL());
        }
        public User GetById(Guid id) 
        {
            return _service.GetById(id).ToBLL();
        }
        public Guid Insert(User user)
        {
           return _service.Insert(user.ToDAL());
        }
        public void Update (Guid id, User user)
        {
            _service.Update(id, user.ToDAL());
        }
        public void Delete(Guid id)
        {
            _service.Delete(id);
        }
        public Guid CheckPassword( string email,string password) 
        { 
            return _service.CheckPassword(email, password);
        }
    }
}
