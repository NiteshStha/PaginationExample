using Microsoft.EntityFrameworkCore;
using PaginationExample.Data.Configurations;
using PaginationExample.Models;

namespace PaginationExample.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new EmployeeConfiguration());
        }
    }
}
