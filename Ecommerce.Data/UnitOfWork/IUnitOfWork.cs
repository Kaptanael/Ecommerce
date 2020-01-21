using Ecommerce.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ecommerce.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }        
        int Save();
        Task<int> SaveAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
