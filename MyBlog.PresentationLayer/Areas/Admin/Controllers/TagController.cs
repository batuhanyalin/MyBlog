using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;

namespace MyBlog.PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]")]
    [Authorize(Roles = "Admin")]
    public class TagController : Controller
    {
        private readonly ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }
        [Route("Index")]
        public IActionResult Index()
        {
            var values = _tagService.TGetListTagWithArticle();
            return View(values);
        }
        [HttpGet]
        [Route("CreateTag")]
        public IActionResult CreateTag()
        {
            return View();
        }
        [HttpPost]
        [Route("CreateTag")]
        public IActionResult CreateTag(Tag p)
        {
            _tagService.TInsert(p);
            return RedirectToAction("Index");
        }
        [Route("DeleteTag/{id:int}")]
        public IActionResult DeleteTag(int id)
        {
            _tagService.TDelete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("UpdateTag/{id:int}")]
        public IActionResult UpdateTag(int id)
        {
            var values = _tagService.TGetById(id);
            return View(values);
        }
        [HttpPost]
        [Route("UpdateTag")]
        public IActionResult UpdateTag(Tag p)
        {
            _tagService.TUpdate(p);
            return RedirectToAction("Index");
        }
    }
}
