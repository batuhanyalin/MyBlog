using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;

namespace MyBlog.PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Blog")]
    public class BlogController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;
        private readonly UserManager<AppUser> _userManager;

        public BlogController(IArticleService articleService, ICategoryService categoryService, UserManager<AppUser> userManager)
        {
            _articleService = articleService;
            _categoryService = categoryService;
            _userManager = userManager;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            var values = _articleService.TGetArticlesWithCategory();
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
            var categories = _categoryService.TGetListAll();
            List<SelectListItem> cat = (from x in categories.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.CategoryName,
                                            Value = x.CategoryId.ToString()
                                        }).ToList();
            ViewBag.categories = cat;
            List<SelectListItem> auth = (from y in author.ToList()
                                         select new SelectListItem
                                         { Text = y.
                                         
                                         }
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
