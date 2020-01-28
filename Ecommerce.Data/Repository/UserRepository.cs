using Ecommerce.Data.DataContext;
using Ecommerce.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ecommerce.Data.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly EcommerceDbContext _context;
        public UserRepository(EcommerceDbContext context) : base(context)
        {
            _context = context;
        }

        public EcommerceDbContext EcommerceDbContext
        {
            get { return Context as EcommerceDbContext; }
        }

        public async Task<object> GetAllUserName()
        {
            var users = await _context.Users
                .Select(u => new
                {
                    u.Id,
                    Name = u.FirstName + u.LastName,
                }).ToListAsync();

            return users;
        }

        //public async Task<AppUser> Login(string email, string password, CancellationToken cancellationToken = default(CancellationToken))
        //{
        //    var user = await _context.AppUsers.FirstOrDefaultAsync(u => u.Email == email, cancellationToken);

        //    if (user == null)
        //    {
        //        return null;
        //    }

        //    if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
        //    {
        //        return null;
        //    }

        //    return user;
        //}

        //public async Task<AppUser> Register(AppUser user, string password, CancellationToken cancellationToken = default(CancellationToken))
        //{
        //    byte[] passwordHash, passwordSalt;

        //    CreatePasswordHash(password, out passwordHash, out passwordSalt);

        //    user.PasswordHash = passwordHash;
        //    user.PasswordSalt = passwordSalt;

        //    await _context.AppUsers.AddAsync(user);            

        //    return user;
        //}        

        public async Task<User> GetUserByEmail(string email, CancellationToken cancellationToken = default(CancellationToken))
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower(), cancellationToken);

            return user;
        }

        //private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        //{
        //    using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
        //    {
        //        var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

        //        for (int i = 0; i < computedHash.Length; i++)
        //        {
        //            if (computedHash[i] != passwordHash[i])
        //            {
        //                return false;
        //            }
        //        }
        //    }

        //    return true;
        //}

        //private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        //{
        //    using (var hmac = new System.Security.Cryptography.HMACSHA512())
        //    {
        //        passwordSalt = hmac.Key;
        //        passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        //    }
        //}
    }
}
