using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HololiveWeb.API.Models;
using HololiveWeb.Models;

using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace HololiveWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext1 _dbContext;
        public ProductsController(ApplicationDbContext1 dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var productList = await _dbContext.Products.ToListAsync();
            return View(productList);
        }
    }
}