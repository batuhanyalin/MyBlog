using MyBlog.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DataAccessLayer.Abstract
{
    public interface IAppUserDal : IGenericDal<AppUser>
    {
        public AppUser ChangeIsApprovedArticleById(int id);
        public int GetCommentsCountByAuthor(int id);
        public int GetArticleCountByAuthor(int id);
        public List<AppUser> GetAuthorWithCommentArticle();
    }
}
