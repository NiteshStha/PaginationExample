using Microsoft.EntityFrameworkCore;
using PaginationExample.Data;
using PaginationExample.Models;
using System.Linq.Expressions;
using X.PagedList;

namespace PaginationExample.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly DataContext _context;

        public EmployeeService(DataContext context)
        {
            _context = context;
        }

        public async Task<int> CountAsync(Expression<Func<Employee, bool>>? expression = null)
        {
            if (expression == null)
                return await _context.Employees.CountAsync();
            else
                return await _context.Employees.CountAsync(expression);
        }

        public async Task<IPagedList<Employee>> GetPagedAsync(int pageNo, int pageSize)
        {
            return await _context.Employees.ToPagedListAsync(pageNo, pageSize);
        }
    }
}
