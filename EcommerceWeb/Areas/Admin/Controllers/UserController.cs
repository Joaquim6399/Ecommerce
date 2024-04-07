using Ecommerce.DataAccess.Data;
using Ecommerce.Models;
using Ecommerce.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;

        public UserController(ApplicationDbContext db)
        {
            _db = db; 
        }
        public IActionResult Index()
        {
            return View();
        }

        #region API CALLS 


        [HttpGet]
        public IActionResult getAll()
        {
            List<ApplicationUser> usersFromDb = _db.ApplicationUsers.ToList();

            return Json(new { data = usersFromDb});
        }

        #endregion
    }
}
