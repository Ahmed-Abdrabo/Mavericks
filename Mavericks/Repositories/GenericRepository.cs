
using Mavericks.Data;
using Mavericks.Specifications;
using Microsoft.EntityFrameworkCore;

namespace Mavericks.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity)
               => await _context.AddAsync(entity);


        public void Delete(T entity)
              => _context.Remove(entity);


        public async Task<IReadOnlyList<T>> GetAllAsync()
               =>await _context.Set<T>().ToListAsync();

        public async Task<IReadOnlyList<T>> GetAllWithSpecAsync(ISpecification<T> spec)
              =>await ApplySpecifications(spec).ToListAsync();

        private IQueryable<T> ApplySpecifications(ISpecification<T> spec)
              =>SpecificationsEvalutor<T>.GetQuery(_context.Set<T>(),spec);

        public async Task<T?> GetByIdAsync(int id)
              =>await _context.FindAsync<T>(id);

        public async Task<int> GetCountAync(ISpecification<T> spec)
              => await ApplySpecifications(spec).CountAsync();

        public async Task<T?> GetWithSpecAsync(ISpecification<T> spec)
             =>await ApplySpecifications(spec).FirstOrDefaultAsync();

        public void Update(T entity)
               => _context.Update(entity);

    }
}
