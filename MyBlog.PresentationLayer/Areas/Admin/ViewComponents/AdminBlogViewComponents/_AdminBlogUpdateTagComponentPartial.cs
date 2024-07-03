using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;
using MyBlog.PresentationLayer.Areas.Admin.Models;
using System.Collections.Generic;

namespace MyBlog.PresentationLayer.Areas.Admin.ViewComponents.AdminBlogViewComponents
{
    public class _AdminBlogUpdateTagComponentPartial : ViewComponent
    {
        private readonly ITagService _tagService;

        public _AdminBlogUpdateTagComponentPartial(ITagService tagService)
        {
            _tagService = tagService;
        }

        [HttpGet]
        public IViewComponentResult Invoke()
        {
            var tags = _tagService.TGetListAll();
            return View(tags);
        }
    }
}
