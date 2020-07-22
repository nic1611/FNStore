using FN.Store.UI.ViewModels.Conta.Login;
using FNStore.Domain.Contracts.Repositories;
using FNStore.Domain.Entities;
using FNStore.Domain.Helpers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FN.Store.UI.Controllers
{
    public class ContaController : Controller
    {
        private readonly IUsuarioRepository repUsuario;

        public ContaController(IUsuarioRepository repUsuario)
        {
            this.repUsuario = repUsuario;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            var model = new LoginVM() { ReturnURL = returnUrl };
            return View(model);
        }

        [HttpPost]
        public IActionResult Login(LoginVM login)
        {

            if (ModelState.IsValid)
            {
                //var usuario = ctx.Usuarios.FirstOrDefault(u => u.Email.ToLower() == login.Email.ToLower());
                var usuario = repUsuario.Get(login.Email);

                if (usuario == null)
                {
                    ModelState.AddModelError("Email", "o e-mail não localizado");
                }
                else
                {
                    if (usuario.Senha != login.Senha.Encrypt())
                    {
                        ModelState.AddModelError("Senha", "Senha inválida");
                    }
                }
                if (ModelState.IsValid)
                {
                    Login(usuario, login.PermanecerLogado);
                    if (!string.IsNullOrEmpty(login.ReturnURL))
                    {
                        return Redirect(login.ReturnURL);
                    }
                    return RedirectToAction("Index", "Home");
                }
            }

            return View(login);
        }

        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        private async void Login(Usuario usuario, bool persist)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, usuario.Nome),
                new Claim(ClaimTypes.Role, "Usuario_Comum")
            };

            var identidadeDeUsuario = new ClaimsIdentity(claims, "Login");
            ClaimsPrincipal claimPrincipal = new ClaimsPrincipal(identidadeDeUsuario);

            var propriedadesDeAutenticacao = new AuthenticationProperties
            {
                AllowRefresh = true,
                ExpiresUtc = DateTime.Now.ToLocalTime().AddHours(2),
                IsPersistent = persist
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimPrincipal, propriedadesDeAutenticacao);
        }

        protected override void Dispose(bool disposing)
        {
            repUsuario.Dispose();
        }
    }
}
