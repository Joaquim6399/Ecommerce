using Microsoft.AspNetCore.Mvc;

namespace EcommerceWeb.Areas.Customer.Controllers
{
    public class ShoppingCartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
