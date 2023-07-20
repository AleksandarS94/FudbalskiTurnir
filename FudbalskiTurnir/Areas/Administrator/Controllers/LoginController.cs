using FudbalskiTurnir.Infrastruktura;
using FudbalskiTurnir.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace FudbalskiTurnir.Areas.Administrator.Controllers
{
    [Authorize]
    public class LoginController : Controller
    {
        private readonly Login context;
        private readonly SignInManager<AppUser> signInManager;
        private readonly UserManager<AppUser> userManager;
        public LoginController(Login context, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            this.context = context;
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        //GET /account/login
        [AllowAnonymous]
        public IActionResult Login()
        {
            if (!User.Identity.IsAuthenticated) { 
            var model = new User() { };
            return View(model);
            }
            return RedirectToAction("Index", "Home");

        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(User user)
        {
            if (ModelState.IsValid)
            {
                var result = context.getLoginUser(user);
                if (result != null)
                {
                    //AppUser appUser = new AppUser
                    //{
                    //    UserName = user.Email,
                    //    Email = user.Email
                    //};

                    //IdentityResult signIn = await userManager.CreateAsync(appUser, user.Password);
                    AppUser appUser = await userManager.FindByEmailAsync(result.Email);

                    Microsoft.AspNetCore.Identity.SignInResult signIn = await signInManager.PasswordSignInAsync(appUser, result.Password, false, false);
                    if (signIn.Succeeded)
                        return RedirectToAction("Index", "Home");
                }
                        
            }
            ModelState.AddModelError("", "Login failed, wrong credentials.");

            return View(user);
        }

        public async Task<IActionResult> SignOff()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction("Login", "Login");
        }
    }
}
