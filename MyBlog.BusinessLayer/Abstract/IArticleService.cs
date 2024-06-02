using MyBlog.DataAccessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.BusinessLayer.Abstract
{
    public interface IArticleService : IGenericService<Article>
    {
        List<Article> TGetArticlesByWriter(int id); //Article için oluşturulan özel metot buraya da başında T harfi konarak oluşturuluyor.
        List<Article> TGetArticlesWithCategoryByWriter(int id);
        List<Article> TGetArticlesWithCategory();
        Article TGetArticleWithCategoryByArticleId(int id);
        public int TCommentsCountByArticle(int id);
        public int GetReadingTime(int id);
    }
}
