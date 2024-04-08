using Ecommerce.DataAccess.Data;
using Ecommerce.Models;
using Ecommerce.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;

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
            var roles = _db.Roles.ToList();
            var UserRoles = _db.UserRoles.ToList();

            List<ApplicationUser> usersFromDb = _db.ApplicationUsers.ToList();
            
            foreach(var user in usersFromDb)
            {
                var roleId = UserRoles.FirstOrDefault(u => u.UserId == user.Id).RoleId;
                user.Role = roles.FirstOrDefault(u => u.Id == roleId).Name;

            }
            return Json(new { data = usersFromDb});
        }

        [HttpPost]
        public IActionResult LockUnlock([FromBody]string id)
        {
            var objFromDb = _db.Users.FirstOrDefault(u => u.Id == id);

            if(objFromDb == null)
            {
                return Json(new { success = false, message = "Error while Locking/Unlocking" });
            }

            if(objFromDb.LockoutEnd != null && objFromDb.LockoutEnd > DateTime.Now)
            {
                //Unlock user
                objFromDb.LockoutEnd = DateTime.Now;
            } else
            {
                //Lock user
                objFromDb.LockoutEnd = DateTime.Now.AddYears(1000);
            }

            _db.SaveChanges();
            return Json(new { success = true, message = "Operation successful" });
        }

        #endregion
    }
}
