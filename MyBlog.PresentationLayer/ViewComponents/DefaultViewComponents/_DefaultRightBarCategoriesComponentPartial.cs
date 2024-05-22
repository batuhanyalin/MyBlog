using Microsoft.AspNetCore.Mvc;

namespace MyBlog.PresentationLayer.ViewComponents.DefaultViewComponents
{
    public class _DefaultRightBarCategoriesComponentPartial : ViewComponent
    {
      public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
