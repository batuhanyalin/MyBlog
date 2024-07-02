using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;

namespace MyBlog.PresentationLayer.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Route("Admin/[controller]")]
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }
        [Authorize(Roles = "Admin,Editor")]
        [Route("Index")]
        [HttpGet]
        public IActionResult Index()
        {
            var values = _contactService.TGetListAll();
            return View(values);
        }
        [Authorize(Roles = "Admin")]
        [Route("DeleteContact/{id:int}")]
        public IActionResult DeleteContact(int id)
        {
            _contactService.TDelete(id);
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Admin,Editor")]
        [Route("ChangeIsReadContact/{id:int}")]
        public IActionResult ChangeIsReadContact(int id)
        {
            _contactService.TChangeIsReadContact(id);
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "Admin,Editor")]
        [Route("DetailContact/{id:int}")]
        public IActionResult DetailContact(int id)
        {
            var values=_contactService.TGetById(id);
            return View(values);
        }

    }
}
