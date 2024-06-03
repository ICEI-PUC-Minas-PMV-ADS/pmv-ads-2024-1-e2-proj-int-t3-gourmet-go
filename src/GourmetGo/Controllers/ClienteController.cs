using Microsoft.AspNetCore.Mvc;
using GourmetGo.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;

public class ClienteController : Controller
{
    private readonly AppDbContext _context;

    public ClienteController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Cardapio(int id)
    {
        var cliente = await _context.Usuarios.FindAsync(id);
        if (cliente == null)
        {
            return NotFound();
        }

        ViewBag.ClienteNome = cliente.Nome;
        List<Produto> produtos = await _context.Produtos.ToListAsync();
        return View(produtos);
    }

    public async Task<IActionResult> Pedidos(int id)
    {
        var cliente = await _context.Usuarios.FindAsync(id);
        if (cliente == null)
        {
            return NotFound();
        }

        ViewBag.ClienteNome = cliente.Nome;
        
        // Obtendo os pedidos do cliente
        var pedidosDoCliente = await _context.Pedidos
    .Include(p => p.Produto) // Incluindo os produtos relacionados
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
        return View(cliente);
    }

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
