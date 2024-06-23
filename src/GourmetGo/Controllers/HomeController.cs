using GourmetGo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GourmetGo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult GestaoGeral()
        {
            return View();
        }
        public IActionResult EsqueciSenha()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult SendPasswordResetLink(string username, string email)
        {
            TempData["Message"] = "Link de redefinição de senha enviado por email.";
            return RedirectToAction("Login", "Usuarios");
        }

        //fim esqueci senha

    }
}
