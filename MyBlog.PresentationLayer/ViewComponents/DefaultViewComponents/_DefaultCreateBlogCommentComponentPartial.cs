using Microsoft.AspNetCore.Mvc;
using MyBlog.BusinessLayer.Abstract;
using MyBlog.PresentationLayer.Models;

namespace MyBlog.PresentationLayer.ViewComponents.DefaultViewComponents
{
    public class _DefaultCreateBlogCommentComponentPartial : ViewComponent
    {
        private readonly IArticleService _articleService;
        private readonly ICommentService _commentService;

        public _DefaultCreateBlogCommentComponentPartial(IArticleService articleService, ICommentService commentService)
        {
            _articleService = articleService;
            _commentService = commentService;
        }

        public IViewComponentResult Invoke(int id)
        {
            CreateCommentBlogViewModel createBlogModel = new CreateCommentBlogViewModel();
            createBlogModel.ArticleId=id;
            return View(createBlogModel);
        }
    }
}
