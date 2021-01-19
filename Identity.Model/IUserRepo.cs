using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Model
{
    public interface IUserRepo
    {
        Task<Dictionary<string,Guid>> ValiDateUser(User user);

        Task<bool> AddUser(User user);
    }
}
