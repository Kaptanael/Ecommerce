using Ecommerce.Data.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ecommerce.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly EcommerceDbContext _context;

        public Repository(EcommerceDbContext context)
        {
            _context = context;
        }
        public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default(CancellationToken))
        {
            await _context.AddAsync(entity, cancellationToken);
            return entity;
        }
        public async Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default(CancellationToken))
        {
            await _context.AddRangeAsync(entities, cancellationToken);
            return entities;
        }
        public TEntity Update(TEntity entity)
        {
            _context.Update(entity);
            return entity;
        }

        public TEntity Delete(TEntity entity)
        {
            _context.Remove(entity);
            return entity;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var entities = await _context.Set<TEntity>().AsNoTracking().ToListAsync(cancellationToken);
            return entities;
        }

        public async Task<TEntity> GetByIdAsync(int id, CancellationToken cancellationToken = default(CancellationToken))
        {
            var entity = await _context.Set<TEntity>().FindAsync(new object[] { id }, cancellationToken);
            return entity;
        }
    }
}
