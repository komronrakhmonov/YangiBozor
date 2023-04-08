using System.Linq.Expressions;
using YangiBozor.Domain.Comons;

namespace YangiBozor.Data.IRepositories;

public interface IRepository<TEntity> where TEntity : Auditable
{
    Task<TEntity> InsertAsync (TEntity entity);
    Task<TEntity> UpdateAsync (TEntity entity);
    Task<bool> DeleteAsync (Expression<Func<TEntity, bool>> predicate);
    Task<TEntity> SelectAsync(Expression<Func<TEntity, bool>> predicate);
    IQueryable<TEntity> SelectAllAsync();
    Task<bool> SaveAsync();
}
