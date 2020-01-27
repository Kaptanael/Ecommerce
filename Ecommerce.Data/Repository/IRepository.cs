using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ecommerce.Data.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<T> AddAsync(T entity, CancellationToken cancellationToken = default(CancellationToken));

        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default(CancellationToken));

        T Update(T entity);

        void Delete(int id);

        void Delete(T entity);

        Task<T> GetByIdAsync(int id, CancellationToken cancellationToken = default(CancellationToken));

        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
