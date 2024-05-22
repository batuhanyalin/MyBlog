using Microsoft.AspNetCore.Mvc;

namespace MyBlog.PresentationLayer.ViewComponents.DefaultViewComponents
{
    public class _DefaultRightBarFollowSocialMediaComponentPartial : ViewComponent
    {
      public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
