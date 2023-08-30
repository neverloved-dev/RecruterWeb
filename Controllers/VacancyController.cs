using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecruterWebApp.Services;
using RecruterWebApp.Models;

namespace RecruterWebApp.Controllers
{
    [Controller]
    [Route("/api/vacancies/controller")]
    public class VacancyController : Controller
    {
        private readonly VacancyService _vacancyService;
        public VacancyController(VacancyService vacancyService)
        {
            _vacancyService = vacancyService;
        }
        // GET: VacancyController
        [HttpGet]
        public async Task<List<Vacancy>> Index()
        {
            return await _vacancyService.GetAllAsync();
        }

        // GET: VacancyController/Details/5
        [HttpGet("{id}")]
        public async Task<Vacancy?> Details(string id)
        {
            return await _vacancyService.GetVacancyAsync(id);
        }

        // POST: VacancyController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
       public async Task Create(Vacancy newVacancy)
        {
            await _vacancyService.CreateVacancyAsync(newVacancy);
        }

        // PUT: VacancyController/Edit/5
        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task Edit(string id, Vacancy vacancy)
        {
            await _vacancyService.UpdateVacancyDataAsync(id,vacancy);
        }

        // DELETE: VacancyController/Delete/5
        [HttpDelete]
        [ValidateAntiForgeryToken]
        public async Task Delete(string id)
        {
            await _vacancyService.DeleteVacancyAsync(id);
        }
    }
}
