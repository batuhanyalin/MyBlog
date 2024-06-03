using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.DataAccessLayer.Context;

namespace MyBlog.PresentationLayer.ViewComponents.BlogDetailViewComponents
{
    public class _AuthorProfileInfoComponentPartial : ViewComponent
    {

       private readonly IArticleService _articleService;

        public _AuthorProfileInfoComponentPartial(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public IViewComponentResult Invoke(int id)
        {
            var values=_articleService.TGetAppUserInfoByArticleId(id);
            return View(values);
        }
    }
}
