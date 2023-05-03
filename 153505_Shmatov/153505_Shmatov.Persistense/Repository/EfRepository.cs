using _153505_Shmatov.Domain.Abstractions;
using _153505_Shmatov.Domain.Entities;
using _153505_Shmatov.Persistense.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace _153505_Shmatov.Persistense.Repository
{
    public class EfRepository<T> : IRepository<T> where T : Entity
    {
        protected readonly AppDbContext? _context;
        protected readonly DbSet<T>? _entities;

        public EfRepository(AppDbContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            await _entities!.AddAsync(entity, cancellationToken);
            
        }

        public async Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
        {
             _entities!.Remove(entity);
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default)
        {
          return await _entities.FirstOrDefaultAsync(filter, cancellationToken);
        }

        public async Task<T> GetByIdAsync(int id, CancellationToken cancellationToken = default, params Expression<Func<T, object>>[]? includesProperties)
        {
            IQueryable<T>? query = _entities!.AsQueryable();

            if (includesProperties != null && includesProperties.Any())
            {
                foreach (Expression<Func<T, object>>? included in includesProperties)
                {
                    query = query.Include(included);
                }
            }

            return await query.FirstOrDefaultAsync(el => el.Id == id, cancellationToken);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            return await _entities!.AsQueryable().ToListAsync(cancellationToken);
        }

        public async Task<IReadOnlyList<T>> ListAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default, params Expression<Func<T, object>>[]? includesProperties)
        {
            IQueryable<T>? query = _entities!.AsQueryable();
           
            if (includesProperties!.Any())
            {
                foreach (Expression<Func<T, object>>? included in includesProperties!)
                {
                    query = query.Include(included);
                }
            }

            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await query.ToListAsync();

        }

        public async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            _context.Update(entity);
            _context.SaveChanges();
            _context.Entry(entity).State = EntityState.Detached;
            /* _context!.Entry(entity).State = EntityState.Modified;

              ;*/

            // return Task.CompletedTask;
        }
    }
}
