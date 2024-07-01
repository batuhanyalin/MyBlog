using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;
using System.Security.Permissions;

namespace MyBlog.PresentationLayer.Controllers
{
    [Authorize]
    public class SocialMediaController : Controller
    {
        private ISocialMediaService _socialMediaService;

        public SocialMediaController(ISocialMediaService socialMediaService)
        {
            _socialMediaService = socialMediaService;
        }

        public IActionResult Index()
        {
            var value = _socialMediaService.TGetListAll();
            return View(value);
        }
        [HttpGet]
        public IActionResult SocialMediaCreate()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SocialMediaCreate(SocialMedia socialMedia)
        {
            _socialMediaService.TInsert(socialMedia);
            return RedirectToAction("Index");
        }
        public IActionResult SocialMediaDelete(int id)
        {
            _socialMediaService.TDelete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult SocialMediaUpdate(int id)
        {
            var value = _socialMediaService.TGetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult SocialMediaUpdate(SocialMedia socialMedia)
        {
            _socialMediaService.TUpdate(socialMedia);
            return RedirectToAction("Index");
        }
    }
}
