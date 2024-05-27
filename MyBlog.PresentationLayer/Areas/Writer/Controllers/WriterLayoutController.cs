using Microsoft.AspNetCore.Mvc;

namespace MyBlog.PresentationLayer.Areas.Writer.Controllers
{
    [Area("Writer")] //Areanın tanıtılması gerekiyor.
    public class WriterLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
