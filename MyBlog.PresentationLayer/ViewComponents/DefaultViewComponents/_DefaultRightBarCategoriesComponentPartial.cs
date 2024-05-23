using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.DataAccessLayer.Abstract;
using MyBlog.DataAccessLayer.EntityFramework;

namespace MyBlog.PresentationLayer.ViewComponents.DefaultViewComponents
{
    public class _DefaultRightBarCategoriesComponentPartial : ViewComponent
    {
       private readonly ICategoryService _categoryService;


        public _DefaultRightBarCategoriesComponentPartial(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            var value=_categoryService.TGetListAll();
            ViewBag.categoryCount = 0;
            return View(value);
        }
    }
}
