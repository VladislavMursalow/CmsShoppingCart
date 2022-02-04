﻿using CmsShoppingCart.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsShoppingCart.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly UserManager<AppUser> userManeger;

        public UsersController(UserManager<AppUser> userManeger)
        {
            this.userManeger = userManeger;
          
        }

        public IActionResult Index()
        {
            return View(userManeger.Users);
        }
    }
}