using HololiveWeb.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using HololiveWeb.Models;
using Microsoft.EntityFrameworkCore;
namespace HololiveWeb.Controllers
{
    public class SearchController : Controller
    {
        private readonly ApplicationDbContext1 _dbContext;

        public SearchController(ApplicationDbContext1 dbContext)
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
