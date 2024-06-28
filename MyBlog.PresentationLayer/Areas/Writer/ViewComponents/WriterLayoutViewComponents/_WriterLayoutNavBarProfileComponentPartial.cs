using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlog.EntityLayer.Concrete;

namespace MyBlog.PresentationLayer.Areas.Writer.ViewComponents.WriterLayoutViewComponents
{
    public class _WriterLayoutNavBarProfileComponentPartial : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public _WriterLayoutNavBarProfileComponentPartial(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            return View(user);
        }
    }
}
