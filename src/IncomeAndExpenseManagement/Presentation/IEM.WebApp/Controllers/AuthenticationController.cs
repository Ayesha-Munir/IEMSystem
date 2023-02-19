using IEM.DependencyInjection.OptionModels;
using IEM.WebApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace IEM.WebApp.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly AccountOption _adminAccount;
        public AuthenticationController(IOptions<AccountOption> _adminAccountOptions)
        {
            _adminAccount = _adminAccountOptions.Value;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!(model.Email == _adminAccount.Email && model.Password == _adminAccount.Password))
            {
                return RedirectToAction(nameof(Login));
            }

            try
            {
                // List of Claims
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email, model.Email)
                };

                // Claims Identity
                var claimsIdentity = new ClaimsIdentity(claims,
                    CookieAuthenticationDefaults.AuthenticationScheme);

                // Claims Principal Object to pass in LogIn Method
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                await HttpContext.SignInAsync(claimsPrincipal);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception exp)
            {
                return View(model);
            }
        }
        public async Task<IActionResult> Logout()
        {
            await this.HttpContext.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }
    }
}
