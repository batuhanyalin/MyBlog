using Microsoft.AspNetCore.Mvc;

namespace MyBlog.PresentationLayer.ViewComponents.DefaultViewComponents
{
    public class _DefaultCategoriesComponentPartial:ViewComponent
    {public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
