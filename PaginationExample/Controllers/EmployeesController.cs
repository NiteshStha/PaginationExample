using Microsoft.AspNetCore.Mvc;
using PaginationExample.Data;
using PaginationExample.Models;
using PaginationExample.Services;
using X.PagedList;

namespace PaginationExample.Controllers
{
    public class EmployeesController : Controller
    {
        private const int pageSize = 10;
        private const string employeesAPI = "https://639983e316b0fdad773f3fbc.mockapi.io/api/employees";
        private readonly DataContext _context;
        private readonly IEmployeeService _service;

        public EmployeesController(DataContext context, IEmployeeService service)
        {
            _context = context;
            _service = service;
        }

        public async Task<IActionResult> Index(int pageNo = 1)
        {
            var employees = await _service.GetPagedAsync(pageNo, pageSize);

            return View(employees);
        }

        public async Task<IActionResult> SeedDataFromAPIAsync()
        {
            using HttpClient http = new HttpClient();

            var employees = await http.GetFromJsonAsync<List<Employee>>(employeesAPI);

            if (employees != null)
            {
                foreach (var employee in employees)
                {
                    employee.Id = 0;
                }

                await _context.Employees.AddRangeAsync(employees);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index", "Employees");
        }
    }
}
