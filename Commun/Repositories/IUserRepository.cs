using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commun.Repositories
{
    public interface IUserRepository<TUser>
    {
        IEnumerable<TUser> Get();
        TUser GetById(Guid id);
        Guid Insert(TUser user);
        void Update(Guid id, TUser user);
        void Delete(Guid id);
        Guid CheckPassword(string email, string password);


    }
}
