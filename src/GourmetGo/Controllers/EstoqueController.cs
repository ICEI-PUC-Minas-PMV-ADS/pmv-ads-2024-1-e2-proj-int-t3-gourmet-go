using GourmetGo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace GourmetGo.Controllers
{
    public class EstoqueController : Controller
    {

        private readonly AppDbContext _context;
        public EstoqueController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var dados = await _context.Estoque.ToListAsync();

            return View(dados);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Estoque estoque)
        {
            if (ModelState.IsValid)
            {
                string precoFormatado = estoque.Preço.ToString("0.00", CultureInfo.InvariantCulture);
                estoque.Preço = Convert.ToDecimal(precoFormatado, CultureInfo.InvariantCulture);
                _context.Estoque.Add(estoque);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(estoque);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Estoque.FindAsync(id);

            if (dados == null)
                return NotFound();

            return View(dados);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Estoque estoque)
        {
            if (id != estoque.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                _context.Estoque.Update(estoque);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Estoque.FindAsync(id);

            if (dados == null)
                return NotFound();

            return View(dados);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Estoque.FindAsync(id);

            if (dados == null)
                return NotFound();

            return View(dados);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {

            if (id == null)
                return NotFound();

            var dados = await _context.Estoque.FindAsync(id);

            if (dados == null)
                return NotFound();

            _context.Estoque.Remove(dados);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }


    }
}