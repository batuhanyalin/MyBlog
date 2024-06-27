﻿using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;

namespace MyBlog.PresentationLayer.Areas.Admin.ViewComponents.AdminLayoutViewComponents
{
    public class _AdminLayoutStatisticComponentPartial : ViewComponent
    {
        private readonly IArticleService _articleService;
        private readonly ICommentService _commentService;

        public _AdminLayoutStatisticComponentPartial(IArticleService articleService, ICommentService commentService)
        {
            _articleService = articleService;
            _commentService = commentService;
        }

        public IViewComponentResult Invoke()
        {
            var values=_articleService.TGetListAll();
            return View();
        }
    }
}
