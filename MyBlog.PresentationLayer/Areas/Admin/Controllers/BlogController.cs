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
        private readonly IAppUserService _appUserService;


        public BlogController(IArticleService articleService, ICategoryService categoryService, IAppUserService appUserService)
        {
            _articleService = articleService;
            _categoryService = categoryService;
            _appUserService = appUserService;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            var values = _articleService.TGetArticlesWithCategory();
            return View(values);
        }
        [Route("CreateBlog")]
        [HttpGet]
        public IActionResult CreateBlog()
        {
            return View();
        }
        [Route("CreateBlog")]
        [HttpPost]
        public IActionResult CreateBlog(Article p)
        {
            _articleService.TInsert(p);
            return RedirectToAction("Index");
        }
        [Route("DeleteBlog")]
        public IActionResult DeleteBlog(int id)
        {
            _articleService.TDelete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("UpdateBlog")]
        public IActionResult UpdateBlog(int id)
        {

            var values = _articleService.TGetById(id);
            var author = _appUserService.TGetListAll();
            var categories = _categoryService.TGetListAll();
            //Kategoriler listeleniyor
            List<SelectListItem> cat = (from x in categories.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.CategoryName,
                                            Value = x.CategoryId.ToString()
                                        }).ToList();
            ViewBag.categories = cat;
            //Yazarlar listeleniyor
            List<SelectListItem> auth = (from y in author.ToList()
                                         select new SelectListItem
                                         {
                                             Text = $"{y.Name} {y.Surname}",  // Name ve Surname birleştiriliyor
                                             Value = y.Id.ToString()
                                         }).ToList();

            ViewBag.authors = auth;
            return View(values);
        }
        [Route("UpdateBlog")]
        [HttpPost]
        public IActionResult UpdateBlog(Article p)
        {
            _articleService.TUpdate(p);
            return RedirectToAction("Index");
        }
    }
}
