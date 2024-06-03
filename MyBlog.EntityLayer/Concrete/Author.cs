using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.EntityLayer.Concrete
{
    public class Author
    {
        public int AuthorId { get; set; }
        public int? AppUserId { get; set; }
    }
}
