using BLL_Khaoula.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL_Khaoula.Mappers;
using D=DAL_Khaoula.Entities;

namespace BLL_Khaoula.Services
{
    public class UserService
    {
        private DAL_Khaoula.Srvices.UserService _service;
        public UserService()
        {
            _service=new DAL_Khaoula.Srvices.UserService();
        }

        public IEnumerable<User> Get()
        {
            return _service.Get().Select(dal=>dal.ToBLL());
        }
        public User Get(Guid id) 
        {
            return _service.GetById(id).ToBLL();
        }
        public D.User Insert(User user)
        {
           return _service.Insert(user.ToDAL());
        }
        public void Delete(Guid id)
        {
            _service.Delete(id);
        }
    }
}
