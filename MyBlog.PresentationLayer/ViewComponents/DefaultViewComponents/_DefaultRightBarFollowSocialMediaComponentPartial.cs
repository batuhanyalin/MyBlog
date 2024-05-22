using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;

namespace MyBlog.PresentationLayer.ViewComponents.DefaultViewComponents
{
    public class _DefaultRightBarFollowSocialMediaComponentPartial : ViewComponent
    {
        private readonly ISocialMediaService _socialMediaService;

        public _DefaultRightBarFollowSocialMediaComponentPartial(ISocialMediaService socialMediaService)
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
