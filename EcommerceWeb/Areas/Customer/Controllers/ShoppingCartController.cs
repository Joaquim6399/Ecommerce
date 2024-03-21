using Microsoft.AspNetCore.Mvc;

namespace EcommerceWeb.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class ShoppingCartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
