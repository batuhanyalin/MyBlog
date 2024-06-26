using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.PresentationLayer.Areas.Admin.Models;
using System.Linq;
using System.Collections.Generic;

namespace MyBlog.PresentationLayer.Areas.Admin.ViewComponents.AdminLayoutViewComponents
{
    public class _AdminLayoutTableChartComponentPartial : ViewComponent
    {
        private readonly IArticleService _articleService;
        public _AdminLayoutTableChartComponentPartial(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _articleService.TGetArticlesWithCategory()
                                        .GroupBy(a => a.Category.CategoryName)
                                        .Select(g => new CategoryBlogCount
                                        {
                                            Category = g.Key,
                                            Count = g.Count()
                                        })
                                        .ToList();
            return View(values);
        }
    }
}
