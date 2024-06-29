using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;

namespace MyBlog.PresentationLayer.Areas.Writer.ViewComponents.WriterLayoutViewComponents
{
    public class _WriterLayoutDashboardStatisticComponentPartial : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IArticleService _articleService;
        private readonly ICommentService _commentService;
        private readonly ICategoryService _categoryService;

        public _WriterLayoutDashboardStatisticComponentPartial(UserManager<AppUser> userManager, IArticleService articleService, ICommentService commentService, ICategoryService categoryService)
        {
            _userManager = userManager;
            _articleService = articleService;
            _commentService = commentService;
            _categoryService = categoryService;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.articleCount = (user.Id);
            ViewBag.commentCount = (user.Id);
            ViewBag.categoryCount = (user.Id);
            ViewBag.InboxMessageCount = (user.Id);
            return View();
        }
    }
}
