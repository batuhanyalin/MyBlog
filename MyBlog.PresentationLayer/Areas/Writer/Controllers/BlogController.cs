using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.DataAccessLayer.Context;
using MyBlog.DataAccessLayer.Repositories;
using MyBlog.EntityLayer.Concrete;
using NuGet.Protocol.Core.Types;

namespace MyBlog.PresentationLayer.Areas.Writer.Controllers
{
    [Authorize(Roles = "Writer")]
    [Area("Writer")] //Area tanıtılıyor.
    [Route("Writer/[controller]")]
    public class BlogController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;
        private readonly IArticleTagService _articleTagService;

        public BlogController(UserManager<AppUser> userManager, IArticleService articleService, ICategoryService categoryService, IArticleTagService articleTagService)
        {
            _userManager = userManager;
            _articleService = articleService;
            _categoryService = categoryService;
            _articleTagService = articleTagService;
        }
        [Route("Index")]
        public async Task<IActionResult> Index() //Giriş yapan yazara ait blogları tutacak olan
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _articleService.TGetArticlesByWriter(user.Id);
            return View(values);

        }
        [Route("DeleteBlog/{id:int}")]
        public IActionResult DeleteBlog(int id)
        {
            _articleService.TDelete(id);
            return RedirectToAction("Index");
        }
        [Route("UpdateBlog/{id:int}")]
        [HttpGet]
        public IActionResult UpdateBlog(int id)
        {
            var values = _articleService.TGetById(id);
            var articletag = _articleTagService.TGetListAll();
            var categories = _categoryService.TGetListAll();
            //Kategoriler listeleniyor
            List<SelectListItem> cat = (from x in categories.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.CategoryName,
                                            Value = x.CategoryId.ToString()
                                        }).ToList();
            ViewBag.categories = cat;
            return View(values);
        }
        [Route("UpdateBlog/{id}")]
        [HttpPost]
        public IActionResult UpdateBlog(Article article, IFormFile CoverImageUrl)
        {
            if (CoverImageUrl != null && CoverImageUrl.Length > 0)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(CoverImageUrl.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = Path.Combine(resource, "wwwroot/images", imageName);

                using (var stream = new FileStream(saveLocation, FileMode.Create))
                {
                    CoverImageUrl.CopyTo(stream);
                }

                article.CoverImageUrl = $"/images/{imageName}";
            }
            else if (article.CoverImageUrl == null)
            {
                article.CoverImageUrl = $"/images/no-image.jpg";
            }
            article.UpdateDate = DateTime.Now;
            _articleService.TUpdate(article);
            return RedirectToAction("Index");
        }
        [Route("CreateBlog")]
        [HttpGet]
        public IActionResult CreateBlog()
        {

            var categories = _categoryService.TGetListAll();
            List<SelectListItem> cat = (from x in categories.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.CategoryName,
                                            Value = x.CategoryId.ToString()
                                        }).ToList();
            ViewBag.categories = cat;
            return View();
        }
        [Route("CreateBlog")]
        [HttpPost]
        public async Task<IActionResult> CreateBlog(Article article, IFormFile CoverImageUrl)
        {
            var user = _userManager.FindByNameAsync(User.Identity.Name);
            if (CoverImageUrl != null && CoverImageUrl.Length > 0)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(CoverImageUrl.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = Path.Combine(resource, "wwwroot/images", imageName);

                using (var stream = new FileStream(saveLocation, FileMode.Create))
                {
                    CoverImageUrl.CopyTo(stream);
                }

                article.CoverImageUrl = $"/images/{imageName}";
            }
            else if (article.CoverImageUrl == null)
            {
                article.CoverImageUrl = $"/images/no-image.jpg";
            }
            article.AppUserId = user.Id;
            article.CreatedDate = DateTime.Now;
            _articleService.TInsert(article);
            return RedirectToAction("Index");
        }
    }
}
