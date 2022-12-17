using Microsoft.AspNetCore.Mvc;
using PaginationExample.Models;
using PaginationExample.Services.Interfaces;

namespace PaginationExample.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly int _pageSize = GlobalVariables.PageSize;
        private const string employeesAPI = "https://639983e316b0fdad773f3fbc.mockapi.io/api/employees";
        private readonly IUnitOfWork _uow;

        public EmployeesController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<IActionResult> Index(int pageNo = 1)
        {
            var employees = await _uow.Employees.GetPagedListAsync(pageNo, _pageSize);

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

                await _uow.Employees.CreateRangeAsync(employees);
                await _uow.SaveAsync();
            }

            return RedirectToAction("Index", "Employees");
        }
    }
}
