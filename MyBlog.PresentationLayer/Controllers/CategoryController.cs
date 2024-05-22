using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;

namespace MyBlog.PresentationLayer.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService; // Business katmanındaki metotlara erişmek için dependency injection uygulayarak field çağırılıyor. Interface çağırıldığında bağımlılık kalmıyor. Yoksa CategoryManager classı da çağrılabilirdi.
        public CategoryController(ICategoryService categoryService) //constructor yapıcı metot oluşturuluyor.
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var values = _categoryService.TGetListAll();
            return View(values);
        }
        [HttpGet]
        public IActionResult CategoryCreate()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CategoryCreate(Category category)
        {
            _categoryService.TInsert(category);
            return RedirectToAction("Index");
        }
        public IActionResult CategoryDelete(int id)
        {
            _categoryService.TDelete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult CategoryUpdate(int id)
        {
            var values = _categoryService.TGetById(id);
            return View();
        }
        [HttpPost]
        public IActionResult CategoryUpdate(Category category)
        {
            _categoryService.TUpdate(category);
            return RedirectToAction("Index");   
        }
    }
}
