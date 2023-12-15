using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Hololive.Web.Models;
using Hololive.Web.Data;
using Microsoft.EntityFrameworkCore;

namespace Hololive.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _dbContext;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    public async Task<IActionResult> Index()
    {
        var productList = await _dbContext.Products.ToListAsync();
        var eventList = await _dbContext.Events.ToListAsync();

        var combinedData = new CombinedData
        {
            Products = productList,
            Events = eventList
        };

        return View(combinedData);
    }
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
