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
    public class ArticleTagManager : IArticleTagService
    {
        private readonly IArticleTagDal _articleTagDal;

        public ArticleTagManager(IArticleTagDal articleTagDal)
        {
            _articleTagDal = articleTagDal;
        }

        public void TDelete(int id)
        {
            _articleTagDal.Delete(id);
        }

        public ArticleTag TGetById(int id)
        {
            return _articleTagDal.GetById(id);
        }

        public List<ArticleTag> TGetListAll()
        {
            return _articleTagDal.GetListAll();
        }

        public void TInsert(ArticleTag entity)
        {
            _articleTagDal.Insert(entity);
        }

        public void TUpdate(ArticleTag entity)
        {
            _articleTagDal.Update(entity);
        }
    }
}
