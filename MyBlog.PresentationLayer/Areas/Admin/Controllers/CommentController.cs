using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;

namespace MyBlog.PresentationLayer.Areas.Admin.Controllers
{
    [Authorize(Roles = "Editor,Admin")]
    [Area("Admin")]
    [Route("Admin/[controller]")]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly IAppUserService _appUserService;
        private readonly IArticleService _articleService;

        public CommentController(ICommentService commentService, IAppUserService appUserService, IArticleService articleService)
        {
            _commentService = commentService;
            _appUserService = appUserService;
            _articleService = articleService;
        }

        [Route("Index")]
        public IActionResult Index()
        {
            var values = _commentService.TGetListAllWithArticleAndAuthor();
            return View(values);
        }

        [Route("UpdateComment/{id:int}")]
        [HttpGet]
        public IActionResult UpdateComment(int id)
        {
            var values = _commentService.TGetById(id);
            if (values == null)
            {
                return NotFound();
            }

            var articles = _articleService.TGetListAll();
            List<SelectListItem> artc = (from y in articles.ToList()
                                         select new SelectListItem
                                         {
                                             Text = y.Title,
                                             Value = y.ArticleId.ToString()
                                         }).ToList();
            ViewBag.article = artc;
            ViewBag.commentscount = _commentService.TGetCommentCountByGuestNameSurname(values.Name, values.Surname);
            return View(values);
        }

        [Route("UpdateComment/{id:int}")]
        [HttpPost]
        public IActionResult UpdateComment(Comment comment)
        {
            _commentService.TUpdate(comment);
            return RedirectToAction("Index");
        }

        [Route("DeleteComment/{id:int}")]
        public IActionResult DeleteComment(int id)
        {
            _commentService.TDelete(id);
            return RedirectToAction("Index");
        }

        [Route("ChangeIsApprovedComment/{id:int}")]
        public IActionResult ChangeIsApprovedComment(int id)
        {
            _commentService.TChangeIsApproved(id);
            return RedirectToAction("Index");
        }
    }
}
