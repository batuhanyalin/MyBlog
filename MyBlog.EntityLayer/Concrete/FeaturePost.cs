using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.EntityLayer.Concrete
{
    public class FeaturePost
    {
        public int FeaturePostId { get; set; }
        public int? ArticleId { get; set; }
        public Article Article { get; set; }
    }
}
