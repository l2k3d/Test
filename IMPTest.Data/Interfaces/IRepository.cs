using System.Linq.Expressions;

namespace IMPTest.Data.Interfaces;

public interface IRepository<TEntity>
{
    Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression);
    Task<TEntity?> GetByIdAsync(int id);
    Task<int> CreateAsync(TEntity entity);
    Task<int> UpdateAsync(TEntity entity);
    Task<int> DeleteAsync(TEntity entity);
}
