using Ecommerce.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Data.Repository
{
    public interface IUserRepository : IRepository<AppUser>
    {
        Task<AppUser> Register(AppUser user, string password);

        Task<AppUser> Login(string username, string password);

        Task<bool> UserExists(string email);
    }
}
