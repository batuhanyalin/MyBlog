using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyBlog.PresentationLayer.Areas.Admin.Controllers
{
    public class SettingsController : Controller
    {
        [Authorize(Roles =("Admin"))]
        public IActionResult Index()
        {
            return View();
        }
    }
}
