using FudbalskiTurnir.Infrastruktura;
using FudbalskiTurnir.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FudbalskiTurnir.Areas.Administrator.Controllers
{
    public class LoginController : Controller
    {
        private readonly Login context;
        public LoginController(Login context)
        {
            this.context = context;
        }

        //GET /account/login

        [AllowAnonymous]
        public IActionResult Login()
        {

            var model = new User() { };
            return View(model);

        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(User user)
        {
            if (ModelState.IsValid)
            {
                // AppUser appUser = await userManager.FindByEmailAsync(login.Email);

                var result = context.getLoginUser(user);
                    if (result != null)
                        return RedirectToAction("Login","Login");
            }
            ModelState.AddModelError("", "Login failed, wrong credentials.");

            return View(user);
        }
    }
}
