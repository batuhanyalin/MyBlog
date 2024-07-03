using Microsoft.AspNetCore.Mvc.Rendering;
using MyBlog.EntityLayer.Concrete;

namespace MyBlog.PresentationLayer.Areas.Admin.Models
{
    public class ArticleUpdateViewModel
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public int? CategoryId { get; set; }
        public int? AppUserId { get; set; }
        public bool IsApproved { get; set; }
        public bool IsFeaturePost { get; set; }
        public string CoverImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string Detail { get; set; }
        public Article Article { get; set; }
        public List<SelectListItem> Categories { get; set; }
        public List<SelectListItem> Authors { get; set; }
        public List<SelectListItem> Tags { get; set; }
        public List<int> SelectedTags { get; set; }
    }
}
