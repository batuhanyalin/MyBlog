using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;

namespace MyBlog.PresentationLayer.ViewComponents.DefaultViewComponents
{
    public class _DefaultRightBarFeaturePostsComponentPartial : ViewComponent
    {
        private readonly IArticleService _articleService;

        public _DefaultRightBarFeaturePostsComponentPartial(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _articleService.TGetFeaturePost();
            return View(values);
        }
    }
}
