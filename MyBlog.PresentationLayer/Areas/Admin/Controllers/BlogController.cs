using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;

namespace MyBlog.PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Blog")]
    public class BlogController : Controller
    {
        private readonly IArticleService _articleService;

        public BlogController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            var values = _articleService.TGetListAll();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateBlog()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateBlog(Article p)
        {
            _articleService.TInsert(p);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteBlog(int id)
        {
            _articleService.TDelete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateBlog(int id)
        {
            var values = _articleService.TGetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateBlog(Article p)
        {
            _articleService.TUpdate(p);
            return RedirectToAction("Index");
        }
    }
}
