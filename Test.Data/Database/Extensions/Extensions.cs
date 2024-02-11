using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace Test.Data.Database.Extensions;

public static class IncludeExtensions
{
    public static IQueryable<TEntity> IncludeMultiple<TEntity>(
        this IQueryable<TEntity> query,
        params Expression<Func<TEntity, object>>[] includes)
        where TEntity : class
    {
        if (includes != null)
        {
            foreach (var include in includes)
            {
                query = query.Include(include);
            }
        }
        return query;
    }
}