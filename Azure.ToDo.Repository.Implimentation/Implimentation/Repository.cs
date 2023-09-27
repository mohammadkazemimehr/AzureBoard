using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Azure.ToDo.Repository.Implimation
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DataContext Context;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(DataContext context)
        {
            this.Context = context;
            _dbSet = Context.Set<TEntity>();
        }
        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Context.Set<TEntity>().Where(predicate).ToListAsync();
        }

        public ValueTask<TEntity> GetByIdAsync(Guid id)
        {
            return Context.Set<TEntity>().FindAsync(id);
        }

        public Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }

        public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().AnyAsync(predicate);
        }

        public virtual async Task<TEntity> GetFirstWithIncludeAsync(string includeProperties,
            Expression<Func<TEntity, bool>> filter = null)
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split
                    (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }
            return await query.FirstOrDefaultAsync();
        }
    }
}
