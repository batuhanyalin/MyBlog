using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;

namespace MyBlog.PresentationLayer.Controllers
{
    [AllowAnonymous]
    public class AuthorController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IAppUserService _userService;

        public AuthorController(UserManager<AppUser> userManager, IAppUserService userService)
        {
            _userManager = userManager;
            _userService = userService;
        }

        public IActionResult Index()
        {
            var values = _userService.TGetAuthorWithCommentArticleByIsApproved();
            return View(values);
        }
        public IActionResult AuthorInfo(int id)
        {
            var values = _userManager.Users.Where(x=>x.Id == id).ToList();
            return View(values);
        }
    }
}
