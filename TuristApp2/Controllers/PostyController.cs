using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TuristApp2.Data;
using TuristApp2.Interfaces;
using TuristApp2.Models;

namespace TuristApp2.Controllers
{
    public class PostyController : Controller
    {
        private readonly IPostyRepository _postyRepository;
        private readonly ApplicationDbContext _context;
        public PostyController(IPostyRepository postyRepository)
        {
            _postyRepository = postyRepository;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Posty> posty = await _postyRepository.GetAll();
            return View(posty);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Posty posty)
        {
            if (!ModelState.IsValid)
            {
                return View(posty);
            }
            _postyRepository.Add(posty);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var postyDetail = await _postyRepository.GetByIdAsync(id);
            if (postyDetail == null) return View("Error");
            return View(postyDetail);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeletePosty(int id)
        {
            var postyDetail = await _postyRepository.GetByIdAsync(id);
            if (postyDetail == null) return View("Error");

            _postyRepository.Delete(postyDetail);
            return RedirectToAction("Index");
        }

    }
}
