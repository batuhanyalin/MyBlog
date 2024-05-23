using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlog.EntityLayer.Concrete;
using MyBlog.PresentationLayer.Models;

namespace MyBlog.PresentationLayer.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(RegisterViewModel model) //asenkron metot kullanılırken async Task<> ifadesi kullanılır.
//Burada Models klasörü içine oluşturulan RegisterViewModel sınıfı çağırılıyor. Burada kullanıcıdan sadece istenen değerler alınacak. Bunlar da RegisterViewModel içerisinde belirtilmiş halde bulunuyor.
        {
            AppUser appUser = new AppUser() //Burada EntityLayerda oluşturulan AppUser sınıfından bir nesne türetiliyor.
            //Buradaki amaç RegisterViewModel içerisindeki propertyler ile AppUser içerisindeki propertyler eşleştirilecek.
            {
                Name = model.Name,
                Email = model.Email,
                Surname = model.Surname,
                UserName = model.Username
            };
            //Parola direkt olarak verilmediği için ayrı veriliyor.
            //await keywordü, asenkron bir metodu işin içine yani mevcuttaki bir göreve dahil edebilmek için kullanılır.
            //Bu şekilde gönderim yapıldığında parola hashlenerek gönderilecek.
            var result =await _userManager.CreateAsync(appUser,model.Password); 
            if (result.Succeeded)
            {
                return RedirectToAction("Index","Login");
            }
            else 
            {
                foreach (var item in result.Errors) //resulttan gelen errorların okunacağı bir hata döngüsü
                {
                    //modelstate controllardaki hataları view tarafına yansıtmak için kullanılıyor.
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View();
        }
    }
}
