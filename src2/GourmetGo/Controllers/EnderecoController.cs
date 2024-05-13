using GourmetGo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GourmetGo.Controllers
{
    public class EnderecoController : Controller
    {

        private readonly AppDbContext _context;
        public EnderecoController(AppDbContext context)
        {
            _context = context;
        }

        [Route("endereços")]
        public async Task<IActionResult> Index()
        {
            var dados = await _context.Enderecos.ToListAsync();

            return View(dados);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Endereco endereco)
        {

            if (ModelState.IsValid)
            {
                _context.Enderecos.Add(endereco);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }


            return View(endereco);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Enderecos.FindAsync(id);

            if (dados == null)
                return NotFound();

            return View(dados);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Endereco endereco)
        {
            if (id != endereco.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                _context.Enderecos.Update(endereco);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Enderecos.FindAsync(id);

            if (dados == null)
                return NotFound();

            return View(dados);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Enderecos.FindAsync(id);

            if (dados == null)
                return NotFound();

            return View(dados);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {

            if (id == null)
                return NotFound();

            var dados = await _context.Enderecos.FindAsync(id);

            if (dados == null)
                return NotFound();

            _context.Enderecos.Remove(dados);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }


    }
}
