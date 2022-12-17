namespace PaginationExample.Services.Interfaces
{
    public interface IUnitOfWork
    {
        IEmployeeService Employees { get; }
        IJobService Jobs { get; }

        Task SaveAsync();
        void Save();
    }
}
