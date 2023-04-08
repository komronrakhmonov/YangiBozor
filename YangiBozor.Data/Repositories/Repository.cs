using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using YangiBozor.Data.DbContexts;
using YangiBozor.Data.IRepositories;
using YangiBozor.Domain.Comons;

namespace YangiBozor.Data.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Auditable
{
    private readonly YangiBozorDbContext dbContext;
    public readonly DbSet<TEntity> dbSet;

    public Repository(YangiBozorDbContext dbContext)
    {
        this.dbContext = dbContext;
        this.dbSet = dbContext.Set<TEntity>();  
    }

    public async Task<TEntity> DeleteAsync(Expression<Func<TEntity, bool>> predicate)
    {
        var entity = await dbSet.FirstOrDefaultAsync(predicate);
        if (entity == null) 
            return null
    }

    public Task<TEntity> InsertAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> SaveAsync()
    {
        throw new NotImplementedException();
    }

    public IQueryable<TEntity> SelectAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> SelectAsync(Expression<Func<TEntity, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public Task<TEntity> UpdateAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }
}
