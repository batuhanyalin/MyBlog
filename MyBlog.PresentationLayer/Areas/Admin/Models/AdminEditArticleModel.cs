using MyBlog.EntityLayer.Concrete;

namespace MyBlog.PresentationLayer.Areas.Admin.Models
{
    public class AdminEditArticleModel
    {
        public string Title { get; set; }
        public string CoverImageUrl { get; set; }
        public string ThumbImageUrl { get; set; }
        public string Detail { get; set; }
        public int? ReadingTime { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public bool IsFeaturePost { get; set; }
        public int? CategoryId { get; set; }
        public bool IsApproved { get; set; }
        public Category Category { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
