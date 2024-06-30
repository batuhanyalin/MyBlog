using MyBlog.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.BusinessLayer.Abstract
{
    public interface IAppUserService:IGenericService<AppUser>
    {
        public AppUser TChangeIsApprovedArticleById(int id);
        public int TGetCommentsCountByAuthor(int id);
        public int TGetArticleCountByAuthor(int id);
        public List<AppUser> TGetAuthorWithCommentArticle();
        public List<AppUser> TGetAuthorWithCommentArticleByIsApproved();
        public List<AppUser> TGetAdminWithCommentArticle();
        public List<AppUser> TGetListAuthorById(int id);

    }
}
