using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;

namespace MyBlog.PresentationLayer.Areas.Admin.ViewComponents.AdminBlogViewComponents
{
    public class _AdminBlogUpdateTagComponentPartial:ViewComponent
    {
        private readonly IArticleTagService _articleTagService;

        public _AdminBlogUpdateTagComponentPartial(IArticleTagService articleTagService)
        {
            _articleTagService = articleTagService;
        }

        public IViewComponentResult Invoke()
        {

            return View();
        }
    }
}
