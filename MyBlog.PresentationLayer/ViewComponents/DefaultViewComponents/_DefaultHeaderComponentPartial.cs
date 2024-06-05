using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;

namespace MyBlog.PresentationLayer.ViewComponents.DefaultViewComponents
{
    public class _DefaultHeaderComponentPartial:ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public _DefaultHeaderComponentPartial(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _categoryService.TGetCategory();
            return View(values);
        }
    }
}
