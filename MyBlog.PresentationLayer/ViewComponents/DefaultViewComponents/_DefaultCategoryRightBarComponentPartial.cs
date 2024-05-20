using Microsoft.AspNetCore.Mvc;

namespace MyBlog.PresentationLayer.ViewComponents.DefaultViewComponents
{
    public class _DefaultCategoryRightBarComponentPartial:ViewComponent
    {
      public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
