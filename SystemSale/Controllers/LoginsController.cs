using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using SystemSale.Data;
using SystemSale.Models;
using SystemSale.Services;

namespace SystemSale.Controllers
{
    public class LoginsController : Controller
    {
        private readonly SystemSaleContext _context;
        private readonly LoginService _loginService;
        

        public LoginsController(SystemSaleContext context, LoginService loginService)
        {
            _context = context;
            _loginService = loginService;
            
        }



        // GET: Logins
        //public async Task<IActionResult> TelaDeLogin()
        //{
        //    return View();
        //}
        public async Task<IActionResult> TelaDeLogin()
        {
            return View();
        }

        public IActionResult TelaInicial( string email, string senha)
        {
            var logins = _loginService.FindAll();

            var achouUsuario = logins.Any(x => x.Email == email && x.Senha == senha);


            if (achouUsuario)
            {
                return RedirectToAction("TelaInicial", "TelaInicial");
            }
            else
            {
                TempData["mensagemErro"] = "";
                return RedirectToAction("TelaDeLogin");
            }


        }

        // GET: Logins/Create
        public IActionResult NovoUsuario()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NovoUsuario([Bind("Id,Nome,SegundoNome,Email,Senha")] Login login, string confirmaSenha)
        {
            if (ModelState.IsValid)
            {
                if (confirmaSenha == login.Senha)
                {
                    _context.Add(login);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Login));
                }
                else if (confirmaSenha != login.Senha)
                {
                    TempData["mensagemErro"] = "";
                    return View(login);
                }
            }
            return View(login);
        }

    }
}
