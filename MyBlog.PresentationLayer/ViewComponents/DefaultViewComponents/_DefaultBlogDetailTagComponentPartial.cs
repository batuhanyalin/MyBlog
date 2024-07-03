using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;

namespace MyBlog.PresentationLayer.ViewComponents.DefaultViewComponents
{
   
    public class _DefaultBlogDetailTagComponentPartial:ViewComponent
    {
        private readonly IArticleTagService _articleTagService;

        public _DefaultBlogDetailTagComponentPartial(IArticleTagService articleTagService)
        {
            _articleTagService = articleTagService;
        }

        public IViewComponentResult Invoke(int id)
        {
            var values = _articleTagService.TGetTagsByArticleId(id);
            return View(values);
        }
    }
}
