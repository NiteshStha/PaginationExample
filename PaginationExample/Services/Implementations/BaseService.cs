using Microsoft.EntityFrameworkCore;
using PaginationExample.Data;
using PaginationExample.Services.Interfaces;
using System.Linq.Expressions;
using X.PagedList;

namespace PaginationExample.Services.Implementations
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        private readonly DataContext _context;

        public BaseService(DataContext context)
        {
            _context = context;
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>>? expression)
        {
            if (expression == null)
                return await _context.Set<T>().CountAsync();
            else
                return await _context.Set<T>().CountAsync(expression);
        }

        public async Task CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public async Task CreateRangeAsync(IEnumerable<T> entities)
        {
            await _context.Set<T>().AddRangeAsync(entities);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            _context.Set<T>().RemoveRange(entities);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().Where(expression).AsNoTracking().ToListAsync();
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T?> GetByIdAsync(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().SingleOrDefaultAsync(expression);
        }

        public async Task<IPagedList<T>> GetPagedListAsync(int pageNo, int pageSize)
        {
            return await _context.Set<T>().ToPagedListAsync(pageNo, pageSize);
        }

        public async Task<IPagedList<T>> GetPagedListAsync(int pageNo, int pageSize, Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().Where(expression).ToPagedListAsync(pageNo, pageSize);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public void UpdateRange(IEnumerable<T> entities)
        {
            _context.Set<T>().UpdateRange(entities);
        }
    }
}
