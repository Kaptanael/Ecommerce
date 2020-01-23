using Ecommerce.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ecommerce.Data.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        //Task<AppUser> Register(AppUser user, string password, CancellationToken cancellationToken = default(CancellationToken));

        //Task<AppUser> Login(string username, string password, CancellationToken cancellationToken = default(CancellationToken));

        Task<User> GetUserByEmail(string email, CancellationToken cancellationToken = default(CancellationToken));
    }
}
