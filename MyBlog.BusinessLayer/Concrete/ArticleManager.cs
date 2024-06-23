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
    public class ArticleManager : IArticleService
    {
        private readonly IArticleDal _articleDal;
        public ArticleManager(IArticleDal articleDal)
        {
            _articleDal = articleDal;
        }

        public int TGetReadingTime(int id)
        {
            return _articleDal.GetReadingTime(id);
        }

        public int TCommentsCountByArticle(int id)
        {
            return _articleDal.CommentsCountByArticle(id);
        }

        public void TDelete(int id)
        {
            _articleDal.Delete(id);
        }

        public List<Article> TGetArticlesByWriter(int id)
        {
            return _articleDal.GetArticlesByWriter(id);
        }

        public List<Article> TGetArticlesWithCategory()
        {
            return _articleDal.GetArticlesWithCategory();
        }

        public List<Article> TGetArticlesWithCategoryByWriter(int id)
        {
            return _articleDal.GetArticlesWithCategoryByWriter(id);
        }

        public Article TGetArticleWithCategoryByArticleId(int id)
        {
            return _articleDal.GetArticleWithCategoryByArticleId(id);
        }

        public Article TGetById(int id)
        {
            return _articleDal.GetById(id);
        }

        public List<Article> TGetListAll()
        {
            return _articleDal.GetListAll();
        }

        public void TInsert(Article entity)
        {
            _articleDal.Insert(entity);
        }

        public void TUpdate(Article entity)
        {
            _articleDal.Update(entity);
        }

        public List<Article> TGetAppUserInfoByArticleId(int id)
        {
            return _articleDal.GetAppUserInfoByArticleId(id);
        }

        public Article TGetCategoryNameByArticleId(int id)
        {
            return _articleDal.GetCategoryNameByArticleId(id);
        }

        public List<Article> TGetArticlesByCategoryId(int id)
        {
            return _articleDal.GetArticlesByCategoryId(id);
        }

        public List<int> TGetReadingTimeAll()
        {
            return _articleDal.GetReadingTimeAll();
        }

        public List<Article> TGetFeaturePost()
        {
            return _articleDal.GetFeaturePost();
        }

        public Article TChangeIsApprovedArticleById(int id)
        {
            return _articleDal.ChangeIsApprovedArticleById(id);
        }

        public Article TChangeIsFeaturePostArticleById(int id)
        {
            return _articleDal.ChangeIsFeaturePostArticleById(id);
        }

        public List<Article> TGetArticlesWithCategoryForIsApproved()
        {
           return _articleDal.GetArticlesWithCategoryForIsApproved();
        }

        public int TGetArticleCountByAuthorId(int id)
        {
           return _articleDal.GetArticleCountByAuthorId(id);
        }
    }
}
