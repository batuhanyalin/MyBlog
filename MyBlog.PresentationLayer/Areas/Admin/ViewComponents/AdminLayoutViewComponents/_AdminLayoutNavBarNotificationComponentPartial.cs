using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;

namespace MyBlog.PresentationLayer.Areas.Admin.ViewComponents.AdminLayoutViewComponents
{
    public class _AdminLayoutNavBarNotificationComponentPartial : ViewComponent
    {
        private readonly INotificationService _notificationService;

        public _AdminLayoutNavBarNotificationComponentPartial(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _notificationService.TGetListNotificationOrderByDescendingDate();
            return View(values);
        }
    }
}
