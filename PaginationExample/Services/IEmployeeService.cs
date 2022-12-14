using PaginationExample.Models;
using System.Linq.Expressions;
using X.PagedList;

namespace PaginationExample.Services
{
    public interface IEmployeeService
    {
        Task<IPagedList<Employee>> GetPagedAsync(int pageNo, int pageSize);
        Task<int> CountAsync(Expression<Func<Employee, bool>>? expression = null);
    }
}
