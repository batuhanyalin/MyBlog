using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        [Route("CreateMessage")]
        [HttpGet]
        public ActionResult CreateMessage()
        {
            var values = _userManager.Users.ToList();
            List<SelectListItem> receiverList = (from x in values.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = $"{x.Name} {x.Surname}",
                                                     Value = x.Id.ToString()
                                                 }).ToList();
            ViewBag.receiver = receiverList;
            return View();
        }
        [Route("CreateMessage")]
        [HttpPost]
        public async Task<ActionResult> CreateMessage(Message message)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            message.SenderId = (user.Id);
            message.SendingTime = DateTime.Now;
            _messageService.TInsert(message);
            if (message.IsDraft == false)
            {
                return RedirectToAction("SentMessage");
            }
            else
            {
                return RedirectToAction("DraftMessage");
            }

        }

        [Route("InboxMessage")]
        public async Task<IActionResult> InboxMessage()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var message = await _messageService.TGetInboxMessage(user.Id);
            return View(message);
        }

        [Route("DraftMessage")]
        public async Task<IActionResult> DraftMessage()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var message = await _messageService.TGetDraftMessage(user.Id);
            return View(message);
        }
        [Route("EditDraftMessage/{id:int}")]
        [HttpGet]
        public async Task<IActionResult> EditDraftMessage(int id)
        {
            var users = _userManager.Users.ToList();
            List<SelectListItem> author=(from x in users.ToList()
                                         select new SelectListItem
                                         {
                                             Text = $"{x.Name} {x.Surname}",
                                             Value=x.Id.ToString()
                                         }).ToList();
            ViewBag.author = author;
            var message = _messageService.TEditDraftMessage(id);
            return View(message);
        }        
        [Route("EditDraftMessage/{id}")]
        [HttpPost]
        public async Task<IActionResult> EditDraftMessage(Message message)
        {

            _messageService.TUpdate(message);
            return RedirectToAction("InboxMessage");
        }



        [Route("ImportantMessage")]
        public async Task<IActionResult> ImportantMessage()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var message = await _messageService.TGetImportantMessage(user.Id);
            return View(message);
        }

        [Route("SentMessage")]
        public async Task<IActionResult> SentMessage()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var message = await _messageService.TGetSentMessage(user.Id);
            return View(message);
        }

        [Route("JunkMessage")]
        public async Task<IActionResult> JunkMessage()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var message = await _messageService.TGetJunkMessage(user.Id);
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
        [Route("AdminListMessage")]
        public IActionResult AdminListMessage()
        {
            var values = _messageService.TGetListAllMessageWithSenderReceiver();
            return View(values);
        }
        [Route("ChangeIsReadMessageForAdminListMessage/{id:int}")]
        public IActionResult ChangeIsReadMessageForAdminListMessage(int id)
        {
            var values = _messageService.TChangeIsReadMessageForAdminListMessagePanel(id);
            return RedirectToAction("AdminListMessage");
        }
        [Route("ChangeIsReadMessage2/{id:int}")]
        public IActionResult ChangeIsReadMessage2(int id)
        {
            var values = _messageService.TChangeIsReadMessage2(id);
            return RedirectToAction("InboxMessage");
        }
        [Route("DetailMessage/{id:int}")]
        public IActionResult DetailMessage(int id)
        {
            var values = _messageService.TGetMessageDetailByMessageId(id);
            _messageService.TChangeIsReadMessageByMessageId(id);
            return View(values);
        }
        [Route("DeleteMessage/{id:int}")]
        public IActionResult DeleteMessage(int id)
        {
            _messageService.TDelete(id);
            return RedirectToAction("AdminListMessage");
        }
        [HttpGet]
        [Route("UpdateMessage/{id:int}")]
        public IActionResult UpdateMessage(int id)
        {

            var senderlist = _userManager.Users.ToList();

            List<SelectListItem> senderlistitem = (from x in senderlist.ToList()
                                                   select new SelectListItem
                                                   {
                                                       Text = $"{x.Name} {x.Surname}",
                                                       Value = x.Id.ToString(),
                                                   }).ToList();
            ViewBag.userList = senderlistitem;
            var values = _messageService.TGetById(id);
            return View(values);
        }
        [HttpPost]
        [Route("UpdateMessage/{id}")]
        public IActionResult UpdateMessage(Message message)
        {
            _messageService.TUpdate(message);
            return RedirectToAction("AdminListMessage");
        }
        [Route("ShowSentMessageDetail/{id:int}")]
        public IActionResult ShowSentMessageDetail(int id)
        {
            var values = _messageService.TGetShowSentMessageDetail(id);
            return View(values);
        }
    }
}
