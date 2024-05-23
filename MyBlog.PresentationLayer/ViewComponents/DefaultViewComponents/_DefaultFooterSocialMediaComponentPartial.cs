using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;

namespace MyBlog.PresentationLayer.ViewComponents.DefaultViewComponents
{
    public class _DefaultFooterSocialMediaComponentPartial : ViewComponent
    {
        private readonly ISocialMediaService _socialMediaService;

        public _DefaultFooterSocialMediaComponentPartial(ISocialMediaService socialMediaService)
        {
            _socialMediaService = socialMediaService;
        }

        public IViewComponentResult Invoke()
        {
            var value = _socialMediaService.TGetListAll();
            return View(value);
        }
    }
}
