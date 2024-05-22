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

    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> Cardapio()
    {
        // Obter todos os produtos do banco de dados
        List<Produto> produtos = await _context.Produtos.ToListAsync();
        return View(produtos);
    }

    public IActionResult Pedidos()
    {
        return View();
    }

    public IActionResult Configuracoes()
    {
        return View();
    }
}
