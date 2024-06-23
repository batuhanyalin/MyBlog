using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;

namespace MyBlog.PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]")]
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly UserManager<AppUser> _userManager;

        public MessageController(IMessageService messageService, UserManager<AppUser> userManager)
        {
            _messageService = messageService;
            _userManager = userManager;
        }
        [Route("InboxMessage")]
        public async Task<IActionResult> InboxMessage()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var message = await _messageService.TGetInboxMessage(user.Id);
            return View(message);
        }
        [Route("ChangeIsImportantMessage/{id:int}")]
        public IActionResult ChangeIsImportantMessage(int id)
        {
            _messageService.TChangeIsImportantMessageById(id);
            return RedirectToAction("InboxMessage");
        }
        [Route("ChangeIsJunkMessage/{id:int}")]
        public IActionResult ChangeIsJunkMessage(int id)
        {
            _messageService.TChangeIsJunkMessageById(id);
            return RedirectToAction("InboxMessage");
        }
    }
}
