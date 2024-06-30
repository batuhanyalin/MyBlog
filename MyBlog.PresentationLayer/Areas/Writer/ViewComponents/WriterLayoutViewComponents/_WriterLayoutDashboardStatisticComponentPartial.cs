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
        private readonly IMessageService _messageService;

        public _WriterLayoutDashboardStatisticComponentPartial(UserManager<AppUser> userManager, IArticleService articleService, ICommentService commentService, ICategoryService categoryService, IMessageService messageService)
        {
            _userManager = userManager;
            _articleService = articleService;
            _commentService = commentService;
            _categoryService = categoryService;
            _messageService = messageService;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.articleCount = _articleService.TGetArticleCountByAuthorId(user.Id);
            ViewBag.commentCount = _commentService.TGetCommentCountByAuthorId(user.Id);
            ViewBag.categoryCount = _articleService.TGetCategoryCountByAuthorId(user.Id).Count();
            ViewBag.InboxMessageCount = _messageService.TGetSideBarInboxMessageCountByUserId(user.Id);
            return View();
        }
    }
}
