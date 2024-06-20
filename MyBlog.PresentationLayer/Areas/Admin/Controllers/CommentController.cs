using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;

namespace MyBlog.PresentationLayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]")]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }
        [Route("Index")]
        public IActionResult Index()
        {
            var values = _commentService.TGetListAllWithArticleAndAuthor();
            return View(values);
        }
        [Route("DeleteBlog/{id:int}")]
        public IActionResult DeleteBlog(int id)
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
