namespace MyBlog.PresentationLayer.Models
{
    public class CreateCommentBlogViewModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public int ArticleId { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
