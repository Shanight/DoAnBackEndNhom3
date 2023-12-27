using HololiveWeb.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using HololiveWeb.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace HololiveWeb.Controllers
{
    public class SearchController : Controller
    {
        private readonly ApplicationDbContext1 _dbContext;

        public SearchController(ApplicationDbContext1 dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index(string keyword, List<string> selectedCategories)
        {
            var query = _dbContext.Products.AsQueryable();

            // Check and apply search keyword
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(p => p.Name.Contains(keyword));
            }

            // Check and apply selected categories
            if (selectedCategories != null && selectedCategories.Any())
            {
                query = query.Where(p => selectedCategories.Contains(p.Catetory));
            }
            

            var productList = await query.ToListAsync();
            return View(productList);
        }

    }
}