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
        protected readonly EcommerceDbContext Context;
        internal DbSet<T> dbSet;

        public Repository(EcommerceDbContext context)
        {
            Context = context;
            dbSet = context.Set<T>();
        }
        public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default(CancellationToken))
        {
            await dbSet.AddAsync(entity, cancellationToken);
            return entity;
        }
        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default(CancellationToken))
        {
            await dbSet.AddRangeAsync(entities, cancellationToken);
            return entities;
        }
        public T Update(T entity)
        {
            dbSet.Update(entity);
            return entity;
        }
        public void Delete(int id)
        {
            T entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);            
        }
        public void Delete(T entity)
        {
            dbSet.Remove(entity);            
        }

        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var entities = await dbSet.AsNoTracking().ToListAsync(cancellationToken);
            return entities;
        }

        public async Task<T> GetByIdAsync(int id, CancellationToken cancellationToken = default(CancellationToken))
        {
            var entity = await dbSet.FindAsync(new object[] { id }, cancellationToken);
            return entity;
        }
    }
}
