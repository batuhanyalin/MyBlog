using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;

namespace MyBlog.PresentationLayer.Areas.Admin.ViewComponents.AdminLayoutViewComponents
{
    public class _AdminLayoutTableListComponentPartial : ViewComponent
    {
        private readonly IArticleService _articleService;

        public _AdminLayoutTableListComponentPartial(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _articleService.TGetArticlesWithCategory();
            return View(values);
        }
    }
}
