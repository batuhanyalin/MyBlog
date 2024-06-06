using Microsoft.AspNetCore.Mvc;

namespace MyBlog.PresentationLayer.Areas.Admin.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
