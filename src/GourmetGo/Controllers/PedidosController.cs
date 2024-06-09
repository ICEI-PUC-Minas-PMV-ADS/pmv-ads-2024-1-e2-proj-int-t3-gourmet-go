using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GourmetGo.Models;
using Microsoft.AspNetCore.Authorization;

namespace GourmetGo.Controllers
{
    
    public class PedidosController : Controller
    {

        private readonly AppDbContext _context;

        public PedidosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Pedidos
        [Authorize]
        public async Task<IActionResult> Index()
{
    var pedidos = await _context.Pedidos
        .Include(p => p.Usuario)
        .Include(p => p.PedidoProdutos)
        .ThenInclude(pp => pp.Produto)
        .ToListAsync();

    return View(pedidos);
}

        // GET: Pedidos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos
                .Include(p => p.Usuario)
                .Include(p => p.PedidoProdutos).ThenInclude(pp => pp.Produto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // GET: Pedidos/Create
        public IActionResult Create()
        {
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Nome");
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "Id", "Nome");
            return View();
        }

        // POST: Pedidos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UsuarioId,Observações,Tipo,Endereço,Pagamento,Status")] Pedido pedido, int[] ProdutoIds, int[] Quantidades)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pedido);
                await _context.SaveChangesAsync();

                for (int i = 0; i < ProdutoIds.Length; i++)
                {
                    var pedidoProduto = new PedidoProduto
                    {
                        PedidoId = pedido.Id,
                        ProdutoId = ProdutoIds[i],
                        Quantidade = Quantidades[i]
                    };
                    _context.PedidoProdutos.Add(pedidoProduto);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Nome", pedido.UsuarioId);
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "Id", "Nome");
            return View(pedido);
        }

        // GET: Pedidos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos
                .Include(p => p.PedidoProdutos)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (pedido == null)
            {
                return NotFound();
            }

            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Nome", pedido.UsuarioId);
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "Id", "Nome");
            return View(pedido);
        }

        // POST: Pedidos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UsuarioId,Observações,Tipo,Endereço,Pagamento,Status")] Pedido pedido, int[] ProdutoIds, int[] Quantidades)
        {
            if (id != pedido.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pedido);
                    await _context.SaveChangesAsync();

                    var existingPedidoProdutos = _context.PedidoProdutos.Where(pp => pp.PedidoId == id);
                    _context.PedidoProdutos.RemoveRange(existingPedidoProdutos);

                    for (int i = 0; i < ProdutoIds.Length; i++)
                    {
                        var pedidoProduto = new PedidoProduto
                        {
                            PedidoId = pedido.Id,
                            ProdutoId = ProdutoIds[i],
                            Quantidade = Quantidades[i]
                        };
                        _context.PedidoProdutos.Add(pedidoProduto);
                    }

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PedidoExists(pedido.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Nome", pedido.UsuarioId);
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "Id", "Nome");
            return View(pedido);
        }

        // GET: Pedidos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos
                .Include(p => p.Usuario)
                .Include(p => p.PedidoProdutos).ThenInclude(pp => pp.Produto)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        // POST: Pedidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido != null)
            {
                var pedidoProdutos = _context.PedidoProdutos.Where(pp => pp.PedidoId == id);
                _context.PedidoProdutos.RemoveRange(pedidoProdutos);

                _context.Pedidos.Remove(pedido);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool PedidoExists(int id)
        {
            return _context.Pedidos.Any(e => e.Id == id);
        }
    }
}
