using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.DataAccessLayer.EntityFramework;
using MyBlog.EntityLayer.Concrete;
using MyBlog.PresentationLayer.Models;

namespace MyBlog.PresentationLayer.Controllers
{
    public class BlogController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;

        public BlogController(IArticleService articleService, ICategoryService categoryService)
        {
            _articleService = articleService;
            _categoryService = categoryService;
        }

        public IActionResult BlogDetail(int id)
        {
            var values = _articleService.TGetById(id);
            ViewBag.createdDateDay = values.CreatedDate.ToString("dd");
            ViewBag.createdDateMonth = values.CreatedDate.ToString("MMM");
            ViewBag.title = values.Title;
            ViewBag.detail = values.Detail;
            ViewBag.CoverImageUrl = values.CoverImageUrl;
            ViewBag.articleId = id; //Burada gelen blog idsini viewbage aktarıp, _CommentListByBlogComponentPartial viewcomponentine idyi taşıyarak, ilgili bloğa ait verilerin gelmesini sağlıyoruz.
            ViewBag.commentscount = _articleService.TCommentsCountByArticle(id);
            ViewBag.GetReadingTime = _articleService.TGetReadingTime(id);
            var values2 = _articleService.TGetCategoryNameByArticleId(id);
            ViewBag.categoryname = values2.Category.CategoryName;
            ViewBag.username = values2.AppUser.UserName;
            return View(values);
        }
        public IActionResult BlogList(int id)
        {
            var values = _articleService.TGetArticlesByWriter(id);
            var y = values.Find(x => x.AppUser.Id == id);
            if (y==null)
            {
                ModelState.AddModelError("", "Bu yazarın henüz bloğu bulunmamaktadır.");
                return RedirectToAction("Index", "Default");
            }
            ViewBag.userId = id;
            ViewBag.name = y.AppUser.Name;
            ViewBag.surname = y.AppUser.Surname;
            foreach (var x in values)
            {
                x.ReadingTime = _articleService.TGetReadingTime(x.ArticleId);
            }
            return View(values);
        }
        public IActionResult BlogListForCategory(int id)
        {
            var values = _articleService.TGetArticlesByCategoryId(id);
            ViewBag.categoryname = _categoryService.TGetById(id).CategoryName;

            foreach (var x in values)
            {
                x.ReadingTime = _articleService.TGetReadingTime(x.ArticleId);
            }
            return View(values);
        }
    }
}
