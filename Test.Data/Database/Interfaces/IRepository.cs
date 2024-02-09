using Test.Data.Database.Entities;
using System.Linq.Expressions;

namespace Test.Data.Database.Interfaces;

public interface IRepository<TEntity> where TEntity : Entity<TEntity>
{
    Task<int> CreateAsync(TEntity entity);
    Task<int> DeleteAsync(TEntity entity);
    Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, params Expression<Func<TEntity, object>>[] includeProperties);
    Task<TEntity?> GetByIdAsync(int id);
    Task<int> UpdateAsync(TEntity entity);
}