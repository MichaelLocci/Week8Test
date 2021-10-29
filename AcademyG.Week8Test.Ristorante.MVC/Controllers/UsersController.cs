using AcademyG.Week8Test.Ristorante.Core.Interfaces;
using AcademyG.Week8Test.Ristorante.Core.Models;
using AcademyG.Week8Test.Ristorante.MVC.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AcademyG.Week8Test.Ristorante.MVC.Controllers
{
    [AllowAnonymous]
    public class UsersController : Controller
    {
        private readonly IMainBusinessLayer mainBL;
        public UsersController(IMainBusinessLayer mainBusinessLayer)
        {
            mainBL = mainBusinessLayer;
        }
        public IActionResult Login(string returnURL)
        {
            return View(new UserLoginViewModel { ReturnURL = returnURL });
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginViewModel ulvm)
        {
            if (ulvm == null)
                return View("ExceptionError", new ResultBL(false, "Invalid user"));

            var user = mainBL.GetUserByEmail(ulvm.Email);
            if (user != null && ModelState.IsValid)
            {
                //verifica password
                if (user.Password.Equals(ulvm.Password))
                {
                    //utente autenticato
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Email, user.Email),
                        new Claim(ClaimTypes.Role, user.Role.ToString())
                    };

                    var authProperties = new AuthenticationProperties
                    {
                        ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30),
                        RedirectUri = ulvm.ReturnURL
                    };

                    //claim utilizzo
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties
                        );

                    return Redirect("/");
                }
                else
                {
                    ModelState.AddModelError(nameof(ulvm.Password), "Invalid Password");
                    return View(ulvm);
                }
            }
            else
            {
                ModelState.AddModelError(nameof(ulvm.Email), "Invalid Email");
                return View(ulvm);
            }
            return View(ulvm);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }

        public IActionResult Forbidden()
        {
            return View();
        }
    }
}
