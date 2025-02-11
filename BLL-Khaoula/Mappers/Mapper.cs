using BLL_Khaoula.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using D = DAL_Khaoula.Entities;

namespace BLL_Khaoula.Mappers
{
    internal static class Mapper
    {
        public static User ToBLL(this D.User user)
        {
            if (user is null)
            {
                throw new ArgumentNullException("user");
            }
                return new BLL_Khaoula.Entities.User (
                    user.User_Id, 
                    user.First_Name, 
                    user.Last_Name, 
                    user.Email, 
                    user.Password
                   
                    );
            
        }

        public static D.User ToDAL(this User user) 
        {
            return new D.User()
            {
                User_Id = user.User_Id,
                First_Name = user.First_Name,
                Last_Name = user.Last_Name,
                Email = user.Email,
                Password = user.Password,
                CreatedAt = user.CreatedAt,
                DisabledAt = (user.IsDisabledAt) ? new DateTime() : null

            };
        }
    }
}
