﻿using CmsShoppingCart.Infrastucture;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CmsShoppingCart.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly CmsShoppingCartContext _context;

        public ProductsController(CmsShoppingCartContext context)
        {
            _context = context;
        }

        //Get: /admin/Products/
        public async Task<IActionResult> Index()
        {
            return View(await _context.Products.OrderByDescending(x => x.Id).Include(x => x.Category).ToListAsync());
        }

        //GET admin/products/create/
        public IActionResult Create() 
        {
            ViewBag.CategoryId = new SelectList(_context.Categories.OrderBy(x => x.Sorting),"Id","Name");

            return View();
        }
    }
}