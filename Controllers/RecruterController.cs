using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecruterWebApp.Services;
using RecruterWebApp.Models;

namespace RecruterWebApp.Controllers
{
    [Controller]
    [Route("/api/controller")]
    public class RecruterController : Controller
    {
        private readonly RecruterService _recruterService;
        public RecruterController(RecruterService recruterService)
        {
           _recruterService = recruterService;
        }
        // GET: RecruterController
        [HttpGet]
        public async Task<List<Recruter>> Index()
        {
            return await _recruterService.GetAllAsync();
        }

        // GET: RecruterController/Details/5
        public async Task<Recruter?> Details(string id)
        {
            return await _recruterService.GetRecruterAsync(id);
        }

        // POST: RecruterController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task Create(Recruter newRecruter)
        {
            await _recruterService.CreateRecruterAsync(newRecruter);
        }

        // PUT: RecruterController/Edit/5
        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task Edit(string id, Recruter recruter)
        {
            await _recruterService.UpdateRecruterDataAsync(id, recruter);
        }

        // DELETE: RecruterController/Delete/5
        [HttpDelete]
        [ValidateAntiForgeryToken]
        public async Task Delete(string id)
        {
            await _recruterService.DeleteRecruterAsync(id);
        }
    }
}
