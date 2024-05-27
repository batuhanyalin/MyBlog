using Microsoft.AspNetCore.Mvc;

namespace MyBlog.PresentationLayer.Areas.Writer.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult MyBlogList() //Giriş yapan yazara ait blogları tutacak olan
        {
            return View();
        }
    }
}
