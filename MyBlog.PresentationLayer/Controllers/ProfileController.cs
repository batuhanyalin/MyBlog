using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlog.EntityLayer.Concrete;

namespace MyBlog.PresentationLayer.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            //Indentity 4 farklı seçeneğe göre find işlemi yapabiliyor.
            var userinfo = await _userManager.FindByNameAsync(User.Identity.Name); //Sisteme giriş yapan kuıllanıcını tutuyor. 
            //User.Identity.Name ibaresi Program.cs de tanımanan UseAuthentication metodunda otantike olan kullanıcının kullanıcı adını tutar, buradan ona erişebiliyoruz.
            ViewBag.id = userinfo.Id;
            ViewBag.name = userinfo.Name;
            ViewBag.surname = userinfo.Surname;
            ViewBag.username = userinfo.UserName;
            return View();
        }
    }
}
