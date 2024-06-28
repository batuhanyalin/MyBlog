using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;

namespace MyBlog.PresentationLayer.Areas.Writer.ViewComponents.WriterLayoutViewComponents
{
    public class _WriterLayoutSideBarComponentPartial : ViewComponent
    {
        private readonly IMessageService _messageService;
        private readonly IArticleService _articleService;
        private readonly UserManager<AppUser> _userManager;

        public _WriterLayoutSideBarComponentPartial(UserManager<AppUser> userManager, IMessageService messageService, IArticleService articleService)
        {
            _userManager = userManager;
            _messageService = messageService;
            _articleService = articleService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.InboxCount = _messageService.TGetSideBarInboxMessageCountByUserId(user.Id);
            ViewBag.InboxIsReadFalseCount = _messageService.TGetSideBarInboxIsReadFalseMessageCountByUserId(user.Id);
            ViewBag.JunkMessageCount = _messageService.TGetSideBarJunkMessageCountByUserId(user.Id);
            ViewBag.ImportantMessageCount = _messageService.TGetSideBarImportantMessageCountByUserId(user.Id);
            ViewBag.SentMessageCount = _messageService.TGetSideBarSentMessageCountByUserId(user.Id);
            ViewBag.DraftMessageCount = _messageService.TGetSideBarDraftMessageCountByUserId(user.Id);
            ViewBag.articlecount = _articleService.TGetArticleCountByAuthorId(user.Id);
            return View(user);
        }
    }
}
