using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlog.EntityLayer.Concrete;
using MyBlog.PresentationLayer.Models;

namespace MyBlog.PresentationLayer.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel model)
        {
            AppUser appUser = new AppUser()
            {
                UserName = model.Username,
            };
            var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);
            if (result.Succeeded)
            {
                var p = await _userManager.FindByNameAsync(model.Username);

                if (p.AppRoleId == 1)
                {
                    return RedirectToAction("Index", "Dashboard", new { area = "Writer" });
                }

                else if (p.AppRoleId == 3 || p.AppRoleId == 2)
                {
                    return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
                }
            }
            else
            {
                ModelState.AddModelError("", "Kullanıcı veya parola yanlış");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }
        [HttpGet]
        public IActionResult error403()
        {
            return View();
        }
    }
}
