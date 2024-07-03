using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;
using MyBlog.PresentationLayer.Areas.Admin.Models;

namespace MyBlog.PresentationLayer.Areas.Admin.Controllers
{
    [Authorize(Roles = "Editor,Admin")]
    [Area("Admin")]
    [Route("Admin/[controller]")]
    public class BlogController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;
        private readonly IAppUserService _appUserService;
        private readonly IArticleTagService _articleTagService;
        private readonly ITagService _tagService;

        public BlogController(IArticleService articleService, ICategoryService categoryService, IAppUserService appUserService, IArticleTagService articleTagService, ITagService tagService)
        {
            _articleService = articleService;
            _categoryService = categoryService;
            _appUserService = appUserService;
            _articleTagService = articleTagService;
            _tagService = tagService;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            var values = _articleService.TGetArticlesWithCategory();
            return View(values);
        }

        [Route("CreateBlog")]
        [HttpGet]
        public IActionResult CreateBlog()
        {
            var categories = _categoryService.TGetListAll();
            var authors = _appUserService.TGetListAll();
            var tags = _tagService.TGetListAll();

            List<SelectListItem> tagList = (from x in tags.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.TagTitle,
                                                Value = x.TagId.ToString()
                                            }).ToList();

            List<SelectListItem> catList = (from x in categories.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.CategoryName,
                                                Value = x.CategoryId.ToString()
                                            }).ToList();

            List<SelectListItem> authorList = (from x in authors.ToList()
                                               select new SelectListItem
                                               {
                                                   Text = $"{x.Name} {x.Surname}",
                                                   Value = x.Id.ToString()
                                               }).ToList();

            ViewBag.Categories = catList;
            ViewBag.Authors = authorList;
            ViewBag.Tags = tagList;

            return View();
        }

        [Route("CreateBlog")]
        [HttpPost]
        public IActionResult CreateBlog(Article article, List<int> selectedTags, IFormFile CoverImageUrl)
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

            article.CreatedDate = DateTime.Now;
            _articleService.TInsert(article);

            foreach (var tagId in selectedTags)
            {
                ArticleTag articleTag = new ArticleTag
                {
                    ArticleId = article.ArticleId,
                    TagId = tagId
                };
                _articleTagService.TInsert(articleTag);
            }

            return RedirectToAction("Index");
        }

        [Route("DeleteBlog/{id:int}")]
        public IActionResult DeleteBlog(int id)
        {
            _articleService.TDelete(id);
            return RedirectToAction("Index");
        }

        [Route("UpdateBlog/{id:int}")] //Dışarıdan int değer geleceğini route ederek bildiriyorum.
        [HttpGet]
        public IActionResult UpdateBlog(int id)
        {
            var values = _articleService.TGetById(id);
            var author = _appUserService.TGetListAll();
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
            //Yazarlar listeleniyor
            List<SelectListItem> auth = (from y in author.ToList()
                                         select new SelectListItem
                                         {
                                             Text = $"{y.Name} {y.Surname}",  // Name ve Surname birleştiriliyor
                                             Value = y.Id.ToString()
                                         }).ToList();

            ViewBag.authors = auth;
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

        [HttpPost]
        [Route("DeleteArticleTag")]
        public IActionResult DeleteArticleTag(int articleId, int tagId)
        {
            var articleTag = _articleTagService.TGetByArticleIdAndTagId(articleId, tagId);
            _articleTagService.TDeleteArticleTag(articleTag);
            return RedirectToAction("UpdateBlog", new { id = articleId });
        }

        [Route("ChangeIsApprovedBlog/{id}")]
        public IActionResult ChangeIsApprovedBlog(int id)
        {
            var values = _articleService.TChangeIsApprovedArticleById(id);
            return RedirectToAction("Index");
        }

        [Route("ChangeIsFeaturePostBlog/{id}")]
        public IActionResult ChangeIsFeaturePostBlog(int id)
        {
            var values = _articleService.TChangeIsFeaturePostArticleById(id);
            return RedirectToAction("Index");
        }
    }
}
