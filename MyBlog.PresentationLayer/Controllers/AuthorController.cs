using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBlog.EntityLayer.Concrete;

namespace MyBlog.PresentationLayer.Controllers
{
    public class AuthorController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public AuthorController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var values = _userManager.Users.Include(x=>x.Comments).Include(x=>x.Articles).ToList();
            return View(values);
        }
        public IActionResult AuthorInfo(int id)
        {
            var values = _userManager.Users.Where(x=>x.Id == id).ToList();
            return View(values);
        }
    }
}
