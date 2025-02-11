using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_Khaoula.Entities
{
    public class User
    {
        public Guid User_Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
        private DateTime? _disabledAt;

        public User(Guid user_Id, string first_Name, string last_Name, string email, string password, DateTime createdAt)
        {
            User_Id = user_Id;
            First_Name = first_Name;
            Last_Name = last_Name;
            Email = email;
            Password = password;
            CreatedAt = createdAt;
        }
        public User(Guid user_Id, string first_Name, string last_Name, string email, string password)
        {
            User_Id = user_Id;
            First_Name = first_Name;
            Last_Name = last_Name;
            Email = email;
            Password = password;
        }

        public bool IsDisabledAt
        {
            get {return _disabledAt is not null; }
        }

        

    }
}
