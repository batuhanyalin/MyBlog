using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlog.EntityLayer.Concrete;
using MyBlog.PresentationLayer.Areas.Writer.Models;

namespace MyBlog.PresentationLayer.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/Profile")] //Burada yönlendirme yapıyoruz. Area adı/Controller adı
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
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
            model.Surname = values.Surname;
            model.Username = values.UserName;
            return View(model);
        }
        [HttpPost]
        [Route("EditProfile")]
        public async Task<IActionResult> EditProfile(UserEditViewModel p)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            if (p.Image != null)
            {
                var resource = Directory.GetCurrentDirectory(); //başlangıçtaki proje yolunu al.
                var extension = Path.GetExtension(p.Image.FileName); //Dosyadan gelen adın extension ını al.
                var imageName = Guid.NewGuid() + extension; //Burada Guid türetilerek aynı isimde dosya eklenip üst üste yazılma durumu önleniyor.
                var saveLocation = resource + "/wwwroot/images/" + imageName; //Dosya yolu belirleniyor.
                var stream = new FileStream(saveLocation, FileMode.Create); //Dosya okuma ve yazma izinleri için kullanılan bir sınıftır (2. overloadına gidiliyor)
                await p.Image.CopyToAsync(stream);
                user.ImageUrl = imageName;
            }
            user.Name = p.Name;
            user.Surname = p.Surname;
            user.PhoneNumber = p.PhoneNumber;
            user.City = p.City;
            user.Email = p.Email;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, p.Password); //password şifrelenerek alınıyor.
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                RedirectToAction("MyBlogList", "Blog", new { Area = "Writer" });
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View();
        }
    }
}
