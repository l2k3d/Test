using Test.Data.Database.Entities;
using Test.Data.Database.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using Test.Data.Database.Extensions;

namespace Test.Data.Database.Repositories;

public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity<TEntity>
{
    private readonly DatabaseContext _context;
    protected readonly DbSet<TEntity> _dbSet;

    protected Repository(DatabaseContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _dbSet = _context.Set<TEntity>() ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<int> CreateAsync(TEntity entity)
    {
        Add(entity);
        return await SaveChangesAsync();
    }

    public async Task<int> DeleteAsync(TEntity entity)
    {
        Remove(entity);
        return await SaveChangesAsync();
    }

    public async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter, Func<IQueryable<TEntity>,
        IOrderedQueryable<TEntity>>? orderBy, params Expression<Func<TEntity, object>>[] includeProperties)
    {
        var query = BuildQuery(filter, includeProperties);

        query = ApplyOrderBy(query, orderBy);

        return await query.ToListAsync();
    }

    public async Task<TEntity?> GetByIdAsync(int id, params Expression<Func<TEntity, object>>[] includeProperties)
    {
        var query = BuildQuery(includeProperties: includeProperties);
        return await query.FirstOrDefaultAsync(entity => entity.Id == id);
    }

    public async Task<int> UpdateAsync(TEntity entity)
    {
        Update(entity);
        return await SaveChangesAsync();
    }

    protected virtual void Add(TEntity entity)
         => _dbSet.Add(entity);

    protected virtual void Remove(TEntity entity)
     => _dbSet.Remove(entity);

    protected virtual void Update(TEntity entity)
        => _dbSet.Update(entity);

    protected virtual IQueryable<TEntity> BuildQuery(Expression<Func<TEntity, bool>>? filter = default, params Expression<Func<TEntity, object>>[] includeProperties)
    {
        IQueryable<TEntity> query = _dbSet;

        if (filter != null)
            query = query.Where(filter);

        foreach (var includeProperty in includeProperties)
            query = query.Include(includeProperty);

        return query;
    }

    protected virtual IQueryable<TEntity> ApplyOrderBy(
        IQueryable<TEntity> query,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy)
    {
        return orderBy != null ? orderBy(query) : query;
    }

    private async Task<int> SaveChangesAsync()
    {
        try
        {
            return await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            throw new Exception("Concurrency violation occurred while saving changes.");
        }
        catch (DbUpdateException)
        {
            throw new Exception("Error occurred while saving changes.");
        }
    }
}