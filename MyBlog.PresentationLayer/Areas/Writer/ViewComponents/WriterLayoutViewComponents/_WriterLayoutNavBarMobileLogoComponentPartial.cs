using Microsoft.AspNetCore.Mvc;

namespace MyBlog.PresentationLayer.Areas.Writer.ViewComponents.WriterLayoutViewComponents
{
    public class _WriterLayoutNavBarMobileLogoComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
