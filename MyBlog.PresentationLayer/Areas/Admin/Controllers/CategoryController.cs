using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;

namespace MyBlog.PresentationLayer.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
	[Route("Admin/{controller}")]
	public class CategoryController : Controller
	{
		private readonly ICategoryService _categoryService;

		public CategoryController(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}

		[Route("Index")]
		public IActionResult Index()
		{
			var values=_categoryService.TGetListCategoryWithArticle();
			return View(values);
		}
		[Route("CreateCategory")]
		[HttpGet]
		public IActionResult CreateCategory()
		{
			return View();
		}
		[Route("CreateCategory")]
		[HttpPost]
		public IActionResult CreateCategory(Category category)
		{
			_categoryService.TInsert(category);
			return RedirectToAction("Index");
		}
		[Route("UpdateCategory/{id:int}")]
		[HttpGet]
		public IActionResult UpdateCategory(int id)
		{
			var values = _categoryService.TGetCategoryByCategoryId(id);
			if (values.Articles==null)
			{
				ViewBag.articleCount = 0;
			}
			else
			{
				ViewBag.articleCount = values.Articles.Count();
			}
			return View(values);
		}
		
		[Route("UpdateCategory/{id:int}")]
		[HttpPost]
		public IActionResult UpdateCategory(Category category)
		{
			_categoryService.TUpdate(category);
			return RedirectToAction("Index");
		}
		[Route("DeleteCategory/{id:int}")]
		public IActionResult DeleteCategory(int id)
		{
			_categoryService.TDelete(id);
			return RedirectToAction("Index");
		}
	}
}
