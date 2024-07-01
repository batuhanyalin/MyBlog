using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient.DataClassification;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;

namespace MyBlog.PresentationLayer.Areas.Admin.Controllers
{
    [Authorize(Roles = "Editor,Admin")]
    [Area("Admin")]
    [Route("Admin/[controller]")]
    public class NotificationController : Controller
    {
        private readonly INotificationService _notificationService;
            public NotificationController(INotificationService notificationService)
        {
            _notificationService=notificationService;

        }
        [Route("Index")]
        public IActionResult Index()
        {
            var values = _notificationService.TGetListNotificationOrderByDescendingDate();
            return View(values);
        }
        [HttpGet]
        [Route("UpdateNotification/{id:int}")]
        public IActionResult UpdateNotification(int id)
        {
            var values=_notificationService.TGetById(id);
            return View(values);
        }
        [HttpPost]
        [Route("UpdateNotification/{id}")]
        public IActionResult UpdateNotification(Notification notification)
        {
            _notificationService.TUpdate(notification);
            return RedirectToAction("Index");
        }
        [Route("DeleteNotification/{id:int}")]
        public IActionResult DeleteNotification(int id)
        {
            _notificationService.TDelete(id);
            return RedirectToAction("Index");
        }
        [Route("CreateNotification")]
        [HttpGet]
        public IActionResult CreateNotification()
        {
            return View();
        }
        [HttpPost]
        [Route("CreateNotification")]
        public IActionResult CreateNotification(Notification notification)
        {
            notification.Date = DateTime.Now;
           _notificationService.TInsert(notification);
            return RedirectToAction("Index");
        }
        [Route("ChangeIsStatusNotification/{id}")]
        public IActionResult ChangeIsStatusNotification(int id)
        {
            _notificationService.TChangeIsStatusNotification(id);
            return RedirectToAction("Index");
        }
    }
}
