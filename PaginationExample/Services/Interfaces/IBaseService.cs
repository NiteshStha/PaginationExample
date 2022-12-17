using System.Linq.Expressions;
using X.PagedList;

namespace PaginationExample.Services.Interfaces
{
    public interface IBaseService<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> expression);
        Task<IPagedList<T>> GetPagedListAsync(int pageNo, int pageSize);
        Task<IPagedList<T>> GetPagedListAsync(int pageNo, int pageSize, Expression<Func<T, bool>> expression);
        Task<T?> GetByIdAsync(int id);
        Task<T?> GetByIdAsync(Expression<Func<T, bool>> expression);
        Task CreateAsync(T entity);
        Task CreateRangeAsync(IEnumerable<T> entities);
        void Update(T entity);
        void UpdateRange(IEnumerable<T> entities);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);
        Task<int> CountAsync(Expression<Func<T, bool>>? expression);
    }
}
