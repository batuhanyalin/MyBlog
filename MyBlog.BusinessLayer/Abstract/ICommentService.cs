using MyBlog.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.BusinessLayer.Abstract
{
    public interface ICommentService:IGenericService<Comment>
    {
        List<Comment> TGetCommentsByArticle(int id);
        public Comment TChangeIsApproved(int id);
        public List<Comment> TGetListAllWithArticleAndAuthor();
        public int TGetCommentCountByGuestNameSurname(string Name, string Surname);
        public int TGetCommentCountByToday();
    }
}
