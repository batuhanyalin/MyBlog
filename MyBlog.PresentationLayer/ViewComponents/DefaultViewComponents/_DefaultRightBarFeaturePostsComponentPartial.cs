using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;

namespace MyBlog.PresentationLayer.ViewComponents.DefaultViewComponents
{
    public class _DefaultRightBarFeaturePostsComponentPartial : ViewComponent
    {
        private readonly IFeaturePostService _featurePostService;

        public _DefaultRightBarFeaturePostsComponentPartial(IFeaturePostService featurePostService)
        {
            _featurePostService = featurePostService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _featurePostService.TGetListAll();
            return View(values);
        }
    }
}
