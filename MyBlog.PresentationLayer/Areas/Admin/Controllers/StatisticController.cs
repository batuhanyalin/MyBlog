using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;

namespace MyBlog.PresentationLayer.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin/{controller}")]
	public class StatisticController : Controller
	{
		private readonly ICategoryService _categoryService;
		private readonly IAppUserService _appUserService;
		private readonly IArticleService _articleService;
		private readonly ICommentService _commentService;
		private readonly IMessageService _messageService;

		public StatisticController(ICategoryService categoryService, IAppUserService appUserService, IArticleService articleService, ICommentService commentService, IMessageService messageService)
		{
			_categoryService = categoryService;
			_appUserService = appUserService;
			_articleService = articleService;
			_commentService = commentService;
			_messageService = messageService;
		}


		[Route("Index")]
		public IActionResult Index()
		{
			var values=_categoryService.TGetListCategoryWithArticle();
			ViewBag.totalAuthor = _appUserService.TGetListAll().Where(x => x.AppRoleId == 1).Count();
			ViewBag.totalAdmin = _appUserService.TGetListAll().Where(x => x.AppRoleId == 2 || x.AppRoleId == 3).Count();
			ViewBag.totalBlog = _articleService.TGetListAll().Count();
			ViewBag.totalComment = _commentService.TGetListAll().Count();
			ViewBag.totalCategory = _categoryService.TGetListAll().Count();
			ViewBag.totalMessage = _messageService.TGetListAll().Count();
			ViewBag.totalImportantMessage = _messageService.TGetListAll().Where(x => x.IsImportant == true).Count();			
			ViewBag.totalJunkMessage = _messageService.TGetListAll().Where(x => x.IsJunk == true).Count();
			return View(values);
		}
	}
}
