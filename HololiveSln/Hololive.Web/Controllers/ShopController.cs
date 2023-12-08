using Microsoft.AspNetCore.Mvc;

public class ShopController : Controller
{
    public IActionResult Index()
    {
        // Xử lý logic và trả về view của trang shop
        return View();
    }
}