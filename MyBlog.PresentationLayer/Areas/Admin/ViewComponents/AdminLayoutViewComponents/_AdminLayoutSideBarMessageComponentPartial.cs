using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;

namespace MyBlog.PresentationLayer.Areas.Admin.ViewComponents.AdminLayoutViewComponents
{
    public class _AdminLayoutSideBarMessageComponentPartial : ViewComponent
    {
        private readonly IMessageService _messageService;
        private readonly UserManager<AppUser> _userManager;

        public _AdminLayoutSideBarMessageComponentPartial(UserManager<AppUser> userManager, IMessageService messageService)
        {
            _userManager = userManager;
            _messageService = messageService;
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
            ViewBag.AllMessageCount = _messageService.TGetListAll().Count();
            return View();
        }
    }
}
