using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;

namespace MyBlog.PresentationLayer.Controllers
{
    public class BlogController : Controller
    {
        private readonly IArticleService _articleService;

        public BlogController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public IActionResult BlogDetail(int id)
        {
            var values = _articleService.TGetById(id);
            ViewBag.createdDateDay = values.CreatedDate.ToString("dd");
            ViewBag.createdDateMonth = values.CreatedDate.ToString("MMM");
            ViewBag.title = values.Title;
            ViewBag.detail = values.Detail;

            ViewBag.commentsById = id; //Burada gelen blog idsini viewbage aktarıp, _CommentListByBlogComponentPartial viewcomponentine idyi taşıyarak, ilgili bloğa ait verilerin gelmesini sağlıyoruz.

            ViewBag.commentscount=_articleService.

            var values2=_articleService.TGetArticleWithCategoryByArticleId(id);
            ViewBag.categoryName = values2.Category.CategoryName;         
            return View(values);
        }
    }
}
