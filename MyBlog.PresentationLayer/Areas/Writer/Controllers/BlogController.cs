using Microsoft.AspNetCore.Mvc;

namespace MyBlog.PresentationLayer.Areas.Writer.Controllers
{
    [Area("Writer")] //Area tanıtılıyor.
    public class BlogController : Controller
    {
        public IActionResult MyBlogList() //Giriş yapan yazara ait blogları tutacak olan
        {
            return View();
        }
    }
}
