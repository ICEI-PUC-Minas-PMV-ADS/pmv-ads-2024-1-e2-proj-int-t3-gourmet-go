using Microsoft.AspNetCore.Mvc;

public class ClienteController : Controller{
        public IActionResult Index()
    {
        return View();
    }
      public IActionResult Cardapio()
  {
      // Lógica para obter os itens do cardápio do banco de dados
      return View();
  }
      public IActionResult Pedidos()
  {
      // Lógica para obter os itens do cardápio do banco de dados
      return View();
  }
      public IActionResult Configuracoes()
  {
      // Lógica para obter os itens do cardápio do banco de dados
      return View();
  }
}