using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.DataAccessLayer.Context;
using MyBlog.DataAccessLayer.Repositories;
using MyBlog.EntityLayer.Concrete;
using NuGet.Protocol.Core.Types;

namespace MyBlog.PresentationLayer.Areas.Writer.Controllers
{
    [Area("Writer")] //Area tanıtılıyor.
    public class BlogController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;

        public BlogController(UserManager<AppUser> userManager, IArticleService articleService, ICategoryService categoryService)
        {
            _userManager = userManager;
            _articleService = articleService;
            _categoryService = categoryService;
        }
        public async Task<IActionResult> MyBlogList() //Giriş yapan yazara ait blogları tutacak olan
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _articleService.TGetArticlesWithCategory(user.Id);
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
            List<SelectListItem> category = (from x in _categoryService.TGetListAll()
                                             select new SelectListItem
                                             {
                                                 Text = x.CategoryName,
                                                 Value = x.CategoryId.ToString()
                                             }).ToList();
            ViewBag.category = category;
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

            List<SelectListItem> values = (from x in _categoryService.TGetListAll()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();
            ViewBag.categories = values;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateBlog(Article model)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            model.CreatedDate = DateTime.Now;
            model.AppUserId = user.Id;
            _articleService.TInsert(model);
            return RedirectToAction("MyBlogList");
        }
    }
}
