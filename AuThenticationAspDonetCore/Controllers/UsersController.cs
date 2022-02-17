using AuThenticationAspDonetCore.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AuThenticationAspDonetCore.Controllers
{
    [Authorize(Roles = "Admin,Staff")]
    public class UsersController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityUser> _roleManager;
        private readonly ApplicationDbContext _db;

        public UsersController(UserManager<IdentityUser> userManager, RoleManager<IdentityUser> roleManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _db = db;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}