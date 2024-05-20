﻿using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;

namespace MyBlog.PresentationLayer.ViewComponents.DefaultViewComponents
{
    public class _DefaultBlogListComponentPartial:ViewComponent

    {
        private readonly IArticleService _articleService;

        public _DefaultBlogListComponentPartial(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _articleService.TGetListAll();
            return View(values);
        }
    }
}