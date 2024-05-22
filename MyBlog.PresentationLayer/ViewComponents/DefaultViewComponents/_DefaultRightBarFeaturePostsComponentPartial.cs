using Microsoft.AspNetCore.Mvc;

namespace MyBlog.PresentationLayer.ViewComponents.DefaultViewComponents
{
    public class _DefaultRightBarFeaturePostsComponentPartial : ViewComponent
    {
      public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
