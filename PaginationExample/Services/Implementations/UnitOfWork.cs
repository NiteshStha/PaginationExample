using PaginationExample.Data;
using PaginationExample.Services.Interfaces;

namespace PaginationExample.Services.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        public IEmployeeService Employees { get; }
        public IJobService Jobs { get; }

        public UnitOfWork(DataContext context)
        {
            _context = context;
            Employees = new EmployeeService(_context);
            Jobs = new JobService(_context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
