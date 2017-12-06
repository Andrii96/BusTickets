using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using BusTickets.Domain.Entities;
using BusTickets.Web.Models;

namespace BusTickets.Web.Controllers
{
    public class AccountController : Controller
    {
        #region fields
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        #endregion

        #region constructor
        public AccountController(SignInManager<User> signInManager,UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        #endregion

        #region Actions

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User { FirstName = model.FirstName, LastName = model.LastName, Email = model.Email,UserName=model.Email };

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                }
            }
            return View("");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password,model.RememberMe,false);

                if (result.Succeeded)
                {

                    return RedirectToAction("Route", "Routes");
                   
                }
                else
                {
                    ModelState.AddModelError("", "Wrong login or password.");
                }
            }

            return View();
        }
        #endregion
    }
}