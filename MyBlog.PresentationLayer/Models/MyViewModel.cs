using MyBlog.DataAccessLayer.EntityFramework;
using MyBlog.EntityLayer.Concrete;

namespace MyBlog.PresentationLayer.Models
{
    public class MyViewModel
    {
        public IEnumerable<Article> Articles { get; set; }
        public EFArticleDal EFArticleDal { get; set; }
    }
}
