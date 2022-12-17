using PaginationExample.Data;
using PaginationExample.Models;
using PaginationExample.Services.Interfaces;

namespace PaginationExample.Services.Implementations
{
    public class EmployeeService : BaseService<Employee>, IEmployeeService
    {
        private readonly DataContext _context;

        public EmployeeService(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
