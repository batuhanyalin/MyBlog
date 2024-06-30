using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;
using MyBlog.PresentationLayer.Areas.Writer.Models;

namespace MyBlog.PresentationLayer.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/Profile")] //Burada yönlendirme yapıyoruz. Area adı/Controller adı
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IAppUserService _userService;

        public ProfileController(UserManager<AppUser> userManager, IAppUserService userService)
        {
            _userManager = userManager;
            _userService = userService;
        }

        [HttpGet]
        [Route("EditProfile")] //Burada area sayfalarında yönlendirme yapıyoruz. Area adı/Controller adı/View adı
        public async Task<IActionResult> EditProfile()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel model = new UserEditViewModel();
            model.Name = values.Name;
            model.Email = values.Email;
            model.PhoneNumber = values.PhoneNumber;
            model.ImageUrl = values.ImageUrl;
            model.City = values.City;
            model.About = values.About;
            model.Surname = values.Surname;
            model.Username = values.UserName;
            ViewBag.commentscount = _userService.TGetCommentsCountByAuthor(values.Id);
            ViewBag.articlecount = _userService.TGetArticleCountByAuthor(values.Id);
            return View(model);
        }
        [HttpPost]
        [Route("EditProfile")]
        public async Task<IActionResult> EditProfile(UserEditViewModel p, IFormFile Image)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            if (Image != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(p.Image.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = resource + "/wwwroot/images/" + imageName;

                using (var stream = new FileStream(saveLocation, FileMode.Create))
                {
                    await Image.CopyToAsync(stream);
                }
                user.ImageUrl = $"/images/{imageName}";
            }
            else if (user.ImageUrl == null)
            {
                user.ImageUrl = $"/images/no-image.jpg";
            }

            user.Name = p.Name;
            user.Surname = p.Surname;
            user.PhoneNumber = p.PhoneNumber;
            user.City = p.City;
            user.Email = p.Email;
            user.About = p.About;

            if (p.Password != null)
            {
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, p.Password);
            }

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Dashboard", new { Area = "Writer" });
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }

            p.ImageUrl = user.ImageUrl; // Güncel ImageUrl değerini ViewModel'e atayın
            ViewBag.commentscount = _userService.TGetCommentsCountByAuthor(user.Id);
            ViewBag.articlecount = _userService.TGetArticleCountByAuthor(user.Id);
            return View(p);
        }

    }
}
