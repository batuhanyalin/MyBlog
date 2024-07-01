using Microsoft.AspNetCore.Mvc;

namespace MyBlog.PresentationLayer.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult error404(int code)
        {
            return View();
        }
    }
}
