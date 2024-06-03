using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.DataAccessLayer.Context;

namespace MyBlog.PresentationLayer.ViewComponents.BlogDetailViewComponents
{
    public class _AuthorProfileInfoComponentPartial : ViewComponent
    {

       private readonly IAuthorService _authorService;

        public _AuthorProfileInfoComponentPartial(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        public IViewComponentResult Invoke()
        {

            return View();
        }
    }
}
