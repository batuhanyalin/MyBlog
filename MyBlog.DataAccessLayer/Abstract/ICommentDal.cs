using MyBlog.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DataAccessLayer.Abstract
{
    public interface ICommentDal:IGenericDal<Comment>
    {
        List<Comment> GetCommentsByArticle(int id);
        public Comment ChangeIsApproved(int id);
        public List<Comment> GetListAllWithArticleAndAuthor();
        public int GetCommentCountByGuestNameSurname(string Name, string Surname);
        public int GetCommentCountByToday();
    }
}
