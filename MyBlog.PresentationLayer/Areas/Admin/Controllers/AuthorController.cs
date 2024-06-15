using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;

namespace MyBlog.PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]")] // Yönlendirmeyi controllera yapıyorum.
    public class AuthorController : Controller
    {
        private readonly IAppUserService _userService;

        public AuthorController(IAppUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            var values = _userService.TGetListAll();
            return View(values);
        }
        [Route("UpdateBlog/{id:int}")]
        [HttpGet]
        public IActionResult UpdateAuthor(int id)
        {
            var values = _userService.TGetById(id);
            return View(values);
        }
        //[Route("UpdateBlog/{id:int}")]
        //[HttpPost]
        //public IActionResult UpdateAuthor(int id)
        //{

        //    return View();
        //}
    }
}
