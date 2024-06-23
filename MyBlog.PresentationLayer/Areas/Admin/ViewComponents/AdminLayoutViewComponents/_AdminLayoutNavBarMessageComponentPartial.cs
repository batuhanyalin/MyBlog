﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;

namespace MyBlog.PresentationLayer.Areas.Admin.ViewComponents.AdminLayoutViewComponents
{
    public class _AdminLayoutNavBarMessageComponentPartial:ViewComponent
    {
    private readonly IMessageService _messageService;
        private readonly UserManager<AppUser> _userManager;

        public _AdminLayoutNavBarMessageComponentPartial(IMessageService messageService, UserManager<AppUser> userManager)
        {
            _messageService = messageService;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var messages = await _messageService.TGetMessageByReceiverIdAsync(user.Id);
            return View(messages);
        }
    }
}
