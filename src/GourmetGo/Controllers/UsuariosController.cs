using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GourmetGo.Models;
using Microsoft.CodeAnalysis;
using System.Security.Claims;
using Microsoft.Identity.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GourmetGo.Controllers
{

    public class UsuariosController : Controller
    {
        private readonly AppDbContext _context;

        // Construtor para injetar o contexto do banco de dados
        public UsuariosController(AppDbContext context)
        {
            _context = context;
        }

        // Método para exibir a página de login
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        // Método POST para realizar o login do usuário
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(Usuario usuario)
        {
            // Busca o usuário no banco de dados pelo email
            var dados = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == usuario.Email);

            // Verifica se o usuário existe
            if (dados == null)
            {
                ViewBag.Message = "Usuário e/ou senha inválidos!";
                return View();
            }

            // Verifica se a senha fornecida é válida
            bool senhaOk = BCrypt.Net.BCrypt.Verify(usuario.Senha, dados.Senha);

            if (senhaOk)
            {
                // Cria as claims para o usuário autenticado
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, dados.Nome),
                    new Claim(ClaimTypes.NameIdentifier, dados.Email.ToString()),
                    new Claim(ClaimTypes.Role, dados.Tipo.ToString())
                };

                // Cria uma identidade com as claims
                var usuarioIdentifier = new ClaimsIdentity(claims, "login");
                ClaimsPrincipal principal = new ClaimsPrincipal(usuarioIdentifier);

                // Define propriedades de autenticação
                var props = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    ExpiresUtc = DateTime.UtcNow.AddHours(8),
                    IsPersistent = true,
                };

                // Realiza o login do usuário
                await HttpContext.SignInAsync(principal, props);

                // Define a mensagem de login efetuado
                TempData["SuccessMessage"] = "Login efetuado com sucesso!";

                // Redireciona para a página inicial
                if (dados.Tipo.ToString() == "Admin")
                {
                    return RedirectToAction("Index", "Home");
                }
                else if (dados.Tipo.ToString() == "Cliente")
                {
                    return RedirectToAction("Index", "Cliente", new { id = dados.Id });
                }
                else if (dados.Tipo.ToString() == "Garcom")
                {
                    return RedirectToAction("GestaoGeral", "Home");
                }
                else if (dados.Tipo.ToString() == "Cozinheiro")
                {
                    return RedirectToAction("GestaoGeral", "Home");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }

            }
            else
            {
                ViewBag.Message = "Usuário e/ou senha inválidos!";
            }

            return View();
        }

        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login", "Usuarios");
        }

        // Método GET para listar todos os usuários
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Usuarios.ToListAsync());
        }

        // Método para exibir a página de cadastro de usuário
        public IActionResult Cadastro()
        {
            return View();
        }

        // Método GET para exibir detalhes de um usuário específico
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Busca o usuário no banco de dados pelo ID
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // Método GET para exibir a página de criação de usuário
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // Método POST para criar um novo usuário
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Cpf,Telefone,Email,Senha,Endereco,Tipo")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                // Hasheia a senha antes de salvar no banco de dados
                usuario.Senha = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction("Login", "Usuarios");
            }
            return View(usuario);
        }

        // Método GET para exibir a página de edição de um usuário específico
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Busca o usuário no banco de dados pelo ID
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        // Método POST para editar um usuário específico
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Cpf,Telefone,Email,Senha,Endereco,Tipo")] Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return NotFound();
            }


            if (ModelState.IsValid)
            {
                try
                {
                    usuario.Senha = BCrypt.Net.BCrypt.HashPassword(usuario.Senha);
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Login", "Usuarios"); ;
            }
            return View(usuario);
        }

        // Método GET para exibir a página de confirmação de exclusão de um usuário
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Busca o usuário no banco de dados pelo ID
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // Método POST para confirmar a exclusão de um usuário
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // Método para verificar se um usuário existe no banco de dados
        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.Id == id);
        }

        // Métodos para recuperação de senha
        [HttpGet]
        public IActionResult EsqueciSenha()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendPasswordResetLink(string username, string email)
        {
            // Exibe uma mensagem informando que o link de redefinição foi enviado
            TempData["Message"] = "Link de redefinição de senha enviado para seu E-mail.";
            return RedirectToAction("Login", "Usuarios");
        }
        //fim esqueci senha
    }
}
