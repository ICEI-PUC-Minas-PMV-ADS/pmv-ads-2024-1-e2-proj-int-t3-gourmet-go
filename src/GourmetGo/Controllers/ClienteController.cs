using Microsoft.AspNetCore.Mvc;
using GourmetGo.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;

public class ClienteController : Controller
{
    private readonly AppDbContext _context;

    public ClienteController(AppDbContext context)
    {
        _context = context;
    }

    [Authorize]
    public async Task<IActionResult> Cardapio(int id)
    {
        var cliente = await _context.Usuarios.FindAsync(id);
        if (cliente == null)
        {
            return NotFound();
        }

        ViewBag.ClienteNome = cliente.Nome;
        ViewBag.ClienteId = cliente.Id;
        List<Produto> produtos = await _context.Produtos.ToListAsync();
        return View(produtos);
    }

    [Authorize]
    public async Task<IActionResult> Pedidos(int id)
    {
        var cliente = await _context.Usuarios.FindAsync(id);
        if (cliente == null)
        {
            return NotFound();
        }

        ViewBag.ClienteNome = cliente.Nome;
        ViewBag.ClienteId = cliente.Id;

        // Obtendo os pedidos do cliente
        var pedidosDoCliente = await _context.Pedidos
            .Include(p => p.PedidoProdutos)
            .ThenInclude(pp => pp.Produto)
            .Where(p => p.UsuarioId == id)
            .ToListAsync();

        return View(pedidosDoCliente);
    }

    public async Task<IActionResult> Configuracoes(int id)
    {
        var cliente = await _context.Usuarios.FindAsync(id);
        if (cliente == null)
        {
            return NotFound();
        }

        ViewBag.ClienteNome = cliente.Nome;
        ViewBag.ClienteId = cliente.Id;
        return View(cliente);
    }

    /* [Authorize] */
    public async Task<IActionResult> Index(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var cliente = await _context.Usuarios
            .FirstOrDefaultAsync(m => m.Id == id);
        if (cliente == null)
        {
            return NotFound();
        }

        return View(cliente);
    }
}
