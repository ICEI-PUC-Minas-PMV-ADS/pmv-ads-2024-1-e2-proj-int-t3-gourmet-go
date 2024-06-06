using GourmetGo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace GourmetGo.Controllers
{
    //[Authorize]
    public class ProdutosController : Controller
    {
        private readonly AppDbContext _context;

        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var dados = await _context.Produtos.ToListAsync();
            return View(dados);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Produto produto, [FromForm] Microsoft.AspNetCore.Http.IFormFile imagem)
        {
            if (ModelState.IsValid)
            {
                // Verifica se foi enviado um arquivo de imagem
                if (imagem != null && imagem.Length > 0)
                {
                    using (var memoryStream = new System.IO.MemoryStream())
                    {
                        await imagem.CopyToAsync(memoryStream);
                        produto.Imagem = memoryStream.ToArray();
                    }
                }

                _context.Produtos.Add(produto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(produto);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Produtos.FindAsync(id);

            if (dados == null)
                return NotFound();

            return View(dados);
        }

[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Descricao,Preco,Categoria,Imagem")] Produto produto, [FromForm] IFormFile novaImagem)
{
  
    if (id != produto.Id)
    {
        return NotFound();
    }

    if (ModelState.IsValid)
    {
        try
        {
            // Verifica se uma nova imagem foi fornecida
            if (novaImagem != null && novaImagem.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await novaImagem.CopyToAsync(memoryStream);
                    produto.Imagem = memoryStream.ToArray();
                }
            }

            // Atualiza o estado da entidade
            _context.Update(produto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ProdutoExists(produto.Id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
    }
    return View(produto);
}

    private bool ProdutoExists(int id)
    {
      throw new NotImplementedException();
    }

    public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Produtos.FindAsync(id);

            if (dados == null)
                return NotFound();

            return View(dados);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Produtos.FindAsync(id);

            if (dados == null)
                return NotFound();

            return View(dados);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Produtos.FindAsync(id);

            if (dados == null)
                return NotFound();

            _context.Produtos.Remove(dados);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
