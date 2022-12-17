using Microsoft.AspNetCore.Mvc;
using PaginationExample.Models;
using PaginationExample.Services.Interfaces;

namespace PaginationExample.Controllers
{
    public class JobsController : Controller
    {
        private readonly int _pageSize = GlobalVariables.PageSize;
        private const string jobsAPI = "https://639983e316b0fdad773f3fbc.mockapi.io/api/jobs";
        private readonly IUnitOfWork _uow;

        public JobsController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<IActionResult> Index(int pageNo = 1)
        {
            var jobs = await _uow.Jobs.GetPagedListAsync(pageNo, _pageSize);
            return View(jobs);
        }

        public async Task<IActionResult> SeedDataFromAPI()
        {
            using HttpClient http = new HttpClient();

            var jobs = await http.GetFromJsonAsync<List<Job>>(jobsAPI);

            if (jobs != null)
            {
                foreach (var job in jobs)
                {
                    job.Id = 0;
                }

                await _uow.Jobs.CreateRangeAsync(jobs);
                await _uow.SaveAsync();
            }

            return RedirectToAction("Index", "Jobs");
        }
    }
}
