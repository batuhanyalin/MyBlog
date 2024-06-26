﻿using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;

namespace MyBlog.PresentationLayer.ViewComponents.DefaultViewComponents
{
    public class _DefaultBlogListComponentPartial : ViewComponent

    {
        private readonly IArticleService _articleService;


        public _DefaultBlogListComponentPartial(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _articleService.TGetArticlesWithCategoryForIsApproved();
            foreach (var x in values)
            {
                x.ReadingTime = _articleService.TGetReadingTime(x.ArticleId);
            }
            return View(values);
        }
    }
}
