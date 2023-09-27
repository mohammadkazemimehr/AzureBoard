using System.Linq.Expressions;

namespace Azure.ToDo.Repository.Interface
{
    public interface IRepository<TEntity> where TEntity : class
    {
        ValueTask<TEntity> GetByIdAsync(Guid id);
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> GetFirstWithIncludeAsync(string includeProperties, Expression<Func<TEntity, bool>> filter = null);
    }
}
