using Mavericks.Specifications;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Mavericks.Repositories
{
    internal static class SpecificationsEvalutor<TEntity> where TEntity : class
    {
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> query, ISpecification<TEntity> spec)
        {
            if(spec.Criteria is not null)
                query=query.Where(spec.Criteria);
            if(spec.OrderByAsc is not null)
                query=query.OrderBy(spec.OrderByAsc);
            if(spec.OrderByDesc is not null)
                query=query.OrderByDescending(spec.OrderByDesc);

            if(spec.IsPaginationEnabled)
                query=query.Skip(spec.Skip).Take(spec.Take);

            query=spec.Includes.Aggregate(query,(current,IncludeExpr)=>current.Include(IncludeExpr));

            return query;
        }
    }
}
