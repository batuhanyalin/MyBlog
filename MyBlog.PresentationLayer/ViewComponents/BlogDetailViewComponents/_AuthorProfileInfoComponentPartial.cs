using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.DataAccessLayer.Context;

namespace MyBlog.PresentationLayer.ViewComponents.BlogDetailViewComponents
{
    public class _AuthorProfileInfoComponentPartial : ViewComponent
    {

  private readonly IAppUserService _appUserService;

        public _AuthorProfileInfoComponentPartial(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }

        public IViewComponentResult Invoke(int id)
        {
            var values = _appUserService.TGetListAuthorById(id);
            return View(values);
        }
    }
}
