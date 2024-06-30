using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;

namespace MyBlog.PresentationLayer.Areas.Writer.ViewComponents.WriterLayoutViewComponents
{
    public class _WriterLayoutNavBarNotificationComponentPartial : ViewComponent
    {
        private readonly INotificationService _notificationService;

        public _WriterLayoutNavBarNotificationComponentPartial(INotificationService notificationService)
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
