using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GourmetGo.Models;

namespace GourmetGo.Controllers
{
    public class GestaoDePedidosController : Controller
    {
        private readonly AppDbContext _context;

        public GestaoDePedidosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: GestaoDePedidos
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Pedidos.Include(p => p.Produto).Include(p => p.Usuario);
            return View(await appDbContext.ToListAsync());
        }

        // GET: GestaoDePedidos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos
                .Include(p => p.Produto)
                .Include(p => p.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }


        // GET: GestaoDePedidos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _context.Pedidos.FindAsync(id);
            if (pedido == null)
            {
                return NotFound();
            }
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "Id", "Descricao", pedido.ProdutoId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Cpf", pedido.UsuarioId);
            return View(pedido);
        }

        // POST: GestaoDePedidos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UsuarioId,ProdutoId,Observações,Tipo,Endereço,Pagamento,Status")] Pedido pedido)
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
            ViewData["ProdutoId"] = new SelectList(_context.Produtos, "Id", "Descricao", pedido.ProdutoId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Cpf", pedido.UsuarioId);
            return View(pedido);
        }

        private bool PedidoExists(int id)
        {
            return _context.Pedidos.Any(e => e.Id == id);
        }
    }
}
