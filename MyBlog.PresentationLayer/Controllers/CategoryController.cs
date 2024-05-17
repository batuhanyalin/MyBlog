using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;

namespace MyBlog.PresentationLayer.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService; // Business katmanındaki metotlara erişmek için dependency injection uygulayarak field çağırılıyor. Interface çağırıldığında bağımlılık kalmıyor. Yoksa CategoryManager classı da çağrılabilirdi.
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index() 
        {
            var values=_categoryService.TGetListAll();
            return View(values);
        }
    }
}
