﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MyBlog.PresentationLayer.Areas.Writer.Controllers
{
    [Authorize(Roles = "Admin,Writer")]
    [Area("Writer")]
    [Route("Writer/Dashboard")]
    public class DashboardController : Controller
    {
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
