using Ecommerce.Data.DataContext;
using Ecommerce.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ecommerce.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EcommerceDbContext _context;
        public UnitOfWork(EcommerceDbContext context)
        {
            _context = context;
        }

        private IUserRepository _users;
        public IUserRepository AppUsers
        {
            get
            {
                if (_users == null)
                {
                    _users = new UserRepository(_context);
                }
                return _users;
            }
        }        

        public int Save()
        {
            int result;
            try
            {
                result = _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }

            return result;
        }

        public async Task<int> SaveAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            int result;
            try
            {
                result = await _context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }

            return result;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
