using PaginationExample.Data;
using PaginationExample.Models;
using PaginationExample.Services.Interfaces;

namespace PaginationExample.Services.Implementations
{
    public class JobService : BaseService<Job>, IJobService
    {
        private readonly DataContext _context;

        public JobService(DataContext context) : base(context)
        {
            _context = context;
        }
    }
}
