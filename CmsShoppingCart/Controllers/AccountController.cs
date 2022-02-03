﻿using CmsShoppingCart.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsShoppingCart.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> userManeger;

        public AccountController(UserManager<AppUser> userManeger)
        {
            this.userManeger = userManeger;
        }

        //GET /account/register
        [AllowAnonymous]
        public IActionResult Register() => View();

        //POST /account/register
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(User user)
        {
            if (ModelState.IsValid) 
            {
                AppUser appUser = new AppUser
                {
                    UserName = user.UserName,
                    Email = user.Email
                };

                IdentityResult result = await userManeger.CreateAsync(appUser, user.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Login"); 
                }
                else 
                {
                    foreach (IdentityError error in result.Errors) 
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }

            }

            return View(user);
        }
    }
}
