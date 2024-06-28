using MyBlog.PresentationLayer.Areas.Admin.Models;
using MyBlog.DataAccessLayer.Dto;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;

namespace MyBlog.PresentationLayer.ViewComponents.DashboardChartViewComponents
{
    public class _DashboardBarChartComponentPartial:ViewComponent
    {
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;
        private readonly IAppUserService _appUserService;
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;

        public _DashboardBarChartComponentPartial(IArticleService articleService, ICategoryService categoryService, IAppUserService appUserService, ICommentService commentService, IMapper mapper)
        {
            _articleService = articleService;
            _categoryService = categoryService;
            _appUserService = appUserService;
            _commentService = commentService;
            _mapper = mapper;
        }
        public IViewComponentResult Invoke()
        {
            var values = _articleService.TGetChartData();
            var model = _mapper.Map<List<CategoryBlogCountChart>>(values);
            return View(model);
        }
    }
}
