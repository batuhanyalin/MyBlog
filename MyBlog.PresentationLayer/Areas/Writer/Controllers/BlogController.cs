using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;

namespace MyBlog.PresentationLayer.Areas.Writer.Controllers
{
    [Area("Writer")] //Area tanıtılıyor.
    public class BlogController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IArticleService _articleService;
        public BlogController(UserManager<AppUser> userManager, IArticleService articleService)
        {
            _userManager = userManager;
            _articleService = articleService;
        }
        public async Task<IActionResult> MyBlogList() //Giriş yapan yazara ait blogları tutacak olan
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _articleService.TGetArticlesByWriter(user.Id);
            return View(values);

        }
        public IActionResult DeleteBlog(int id)
        {
            _articleService.TDelete(id);
            return RedirectToAction("MyBlogList");
        }
        [HttpGet]
        public IActionResult UpdateBlog(int id)
        {
            var values = _articleService.TGetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateBlog(Article model)
        {
            _articleService.TUpdate(model);
            return RedirectToAction("MyBlogList");
        }
        [HttpGet]
        public IActionResult CreateBlog()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateBlog(Article model)
        {
            _articleService.TInsert(model);
            return RedirectToAction("MyBlogList");
        }
    }
}
