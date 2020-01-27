using Ecommerce.Data.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ecommerce.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly EcommerceDbContext _context;

        public Repository(EcommerceDbContext context)
        {
            _context = context;
        }
        public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default(CancellationToken))
        {
            await _context.AddAsync(entity, cancellationToken);
            return entity;
        }
        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default(CancellationToken))
        {
            await _context.AddRangeAsync(entities, cancellationToken);
            return entities;
        }
        public T Update(T entity)
        {
            _context.Update(entity);
            return entity;
        }
        public void Delete(int id)
        {
            T entityToDelete =  _context.Set<T>().Find(id);
            Delete(entityToDelete);            
        }
        public void Delete(T entity)
        {
            _context.Remove(entity);            
        }

        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var entities = await _context.Set<T>().AsNoTracking().ToListAsync(cancellationToken);
            return entities;
        }

        public async Task<T> GetByIdAsync(int id, CancellationToken cancellationToken = default(CancellationToken))
        {
            var entity = await _context.Set<T>().FindAsync(new object[] { id }, cancellationToken);
            return entity;
        }
    }
}
