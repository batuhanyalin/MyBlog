using MyBlog.BusinessLayer.Abstract;
using MyBlog.DataAccessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.BusinessLayer.Concrete
{
    public class AppUserManager : IAppUserService
    {
        private readonly IAppUserDal _appUserDal;

        public AppUserManager(IAppUserDal appUserDal)
        {
            _appUserDal = appUserDal;
        }

        public AppUser TChangeIsApprovedArticleById(int id)
        {
            return _appUserDal.ChangeIsApprovedArticleById(id);
        }

        public void TDelete(int id)
        {
            _appUserDal.Delete(id);
        }

        public int TGetArticleCountByAuthor(int id)
        {
           return _appUserDal.GetArticleCountByAuthor(id);
        }

        public List<AppUser> TGetAuthorWithCommentArticle()
        {
            return _appUserDal.GetAuthorWithCommentArticle();
        }

        public List<AppUser> TGetAuthorWithCommentArticleByIsApproved()
        {
            return _appUserDal.GetAuthorWithCommentArticleByIsApproved();
        }

        public AppUser TGetById(int id)
        {
            return _appUserDal.GetById(id);
        }

        public int TGetCommentsCountByAuthor(int id)
        {
            return _appUserDal.GetCommentsCountByAuthor(id);
        }

        public List<AppUser> TGetListAll()
        {
            return _appUserDal.GetListAll();
        }

        public void TInsert(AppUser entity)
        {
            _appUserDal.Insert(entity);
        }

        public void TUpdate(AppUser entity)
        {
            _appUserDal.Update(entity);
        }
    }
}
