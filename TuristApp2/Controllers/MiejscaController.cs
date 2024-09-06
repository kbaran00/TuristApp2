using Microsoft.AspNetCore.Mvc;
using TuristApp2.Data;
using TuristApp2.Interfaces;
using TuristApp2.Models;
using TuristApp2.Repository;

namespace TuristApp2.Controllers
{
    public class MiejscaController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMiejscaRepository _miejscaRepository;
        public MiejscaController(ApplicationDbContext context, IMiejscaRepository miejscaRepository)
        {
            _miejscaRepository = miejscaRepository;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Miejsca> miejsca = await _miejscaRepository.GetAll();
            return View(miejsca);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Miejsca miejsca)
        {
            if (!ModelState.IsValid)
            {
                return View(miejsca);
            }
            _miejscaRepository.Add(miejsca);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var miejscaDetail = await _miejscaRepository.GetByIdAsync(id);
            if (miejscaDetail == null) return View("Error");
            return View(miejscaDetail);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeletePosty(int id)
        {
            var miejscaDetail = await _miejscaRepository.GetByIdAsync(id);
            if (miejscaDetail == null) return View("Error");

            _miejscaRepository.Delete(miejscaDetail);
            return RedirectToAction("Index");

        }

    }
}
