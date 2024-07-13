using System.Linq.Expressions;

namespace Mavericks.Specifications
{
    public class BaseSpecification<T> : ISpecification<T> where T : class
    {
        public Expression<Func<T, bool>> Criteria { get; set; } = null!;
        public List<Expression<Func<T, object>>> Includes { get; set; } = new List<Expression<Func<T, object>>>();
        public Expression<Func<T, object>> OrderByAsc { get; set; } = null!;
        public Expression<Func<T, object>> OrderByDesc { get; set; } = null!;
        public int Skip { get; set; }
        public int Take { get; set; }
        public bool IsPaginationEnabled { get; set; }
        public BaseSpecification()
        {
            
        }
        public BaseSpecification(Expression<Func<T,bool>> _Criteria)
        {
            Criteria = _Criteria;   
        }
        public void AddOrderByAsc(Expression<Func<T, object>> OrderByExp)
        {
            OrderByAsc = OrderByExp;
        }
        public void AddOrderByDesc(Expression<Func<T, object>> OrderByExp)
        {
            OrderByDesc = OrderByExp;
        }
        public void ApplyPagination(int skip, int take)
        {
            IsPaginationEnabled = true;
            Skip = skip;
            Take = take;
        }
    }
}
