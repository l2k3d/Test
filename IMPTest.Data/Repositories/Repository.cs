using IMPTest.Common.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace IMPTest.Data.Repositories
{
    public abstract class Repository<TEntity>(DatabaseContext context) where TEntity : BaseEntity<TEntity>
    {
        private readonly DatabaseContext _context = context;

        public async Task<int> CreateAsync(TEntity entity)
        {
            var table = _context.Set<TEntity>();
            await table.AddAsync(entity);
            return await _context.SaveChangesAsync(true);
        }

        public async Task<int> DeleteAsync(TEntity entity)
        {
            var table = _context.Set<TEntity>();
            table.Remove(entity);
            return await _context.SaveChangesAsync(true);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression)
        {
            var table = _context.Set<TEntity>() as IQueryable<TEntity>;

            if (expression != null)
            {
                table = table.Where(expression);
            }

            return await table.ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(int id)
        {
            var table = _context.Set<TEntity>();
            return await table.FindAsync(id);
        }

        public async Task<int> UpdateAsync(TEntity entity)
        {
            var table = _context.Set<TEntity>();
            table.Update(entity);

            return await _context.SaveChangesAsync(true);
        }

    }
}
