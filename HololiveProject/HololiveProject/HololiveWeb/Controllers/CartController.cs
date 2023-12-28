using HololiveWeb.Models;
using Microsoft.AspNetCore.Mvc;
using HololiveWeb.Helpers;
using Microsoft.AspNetCore.Authorization;
using HololiveWeb.API.Models;

namespace HololiveWeb.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext1 _dbcontext;

        public CartController(ApplicationDbContext1 dbcontext)
        {
            _dbcontext = dbcontext;
        }

        const string CART_KEY = "MYCARD";
        public List<Cart> Cart => HttpContext.Session.Get<List<Cart>>(CART_KEY) ?? new List<Cart>();

        public IActionResult Index()
        {
            return View(Cart);
        }

        public IActionResult AddToCart(int id, int Quality)
        {
            var gioHang = HttpContext.Session.Get<List<Cart>>(CART_KEY) ?? new List<Cart>();
            var item = gioHang.SingleOrDefault(p => p.Id == id);
            if (item == null)
            {
                var hangHoa = _dbcontext.Products.SingleOrDefault(p => p.Id == id);

                if (hangHoa == null)
                {
                    return RedirectToAction("Index", "Cart");
                }
                item = new Cart
                {
                    Id = hangHoa.Id,
                    Name = hangHoa.Name,
                    Price = hangHoa.Price,
                    img1 = hangHoa.img1 ?? string.Empty,
                    Catetory = hangHoa.Catetory,
                    img2 = hangHoa.img2 ?? string.Empty,
                    img3 = hangHoa.img3 ?? string.Empty,
                    Preview1 = hangHoa.Preview1,
                    Preview2 = hangHoa.Preview2,
                    Preview3 = hangHoa.Preview3,
                    Preview4 = hangHoa.Preview4,
                    Preview5 = hangHoa.Preview5
                };
                gioHang.Add(item);
            }
            else
            {
                // Thực hiện các hành động khi sản phẩm đã tồn tại trong giỏ hàng
            }

            HttpContext.Session.Set(CART_KEY, gioHang);

            return RedirectToAction("Index");
        }

        public IActionResult RemoveCart(int id)
        {
            var gioHang = Cart;
            var item = gioHang.SingleOrDefault(p => p.Id == id);
            if (item != null)
            {
                gioHang.Remove(item);
                HttpContext.Session.Set(CART_KEY, gioHang);
            }
            return RedirectToAction("Index");
        }

        [Authorize]
        [HttpGet]
        public IActionResult Checkout()
        {
            if (Cart.Count == 0)
            {
                return Redirect("/");
            }

            return View(Cart);
        }
		[HttpPost]
		public IActionResult ClearCart()
		{
			HttpContext.Session.Remove(CART_KEY);
			return Ok();
		}
    }
}