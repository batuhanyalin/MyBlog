using Microsoft.AspNetCore.Mvc;

namespace MyBlog.PresentationLayer.ViewComponents.DefaultViewComponents
{
    public class _DefaultRightBarAboutMeComponentPartial : ViewComponent
    {
      public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
