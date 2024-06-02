using Microsoft.Data.SqlClient.DataClassification;
using Microsoft.EntityFrameworkCore;
using MyBlog.DataAccessLayer.Abstract;
using MyBlog.DataAccessLayer.Context;
using MyBlog.DataAccessLayer.Repositories;
using MyBlog.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DataAccessLayer.EntityFramework
{
    public class EFArticleDal : GenericRepository<Article>, IArticleDal
    {
        BlogContext context = new BlogContext();
        public List<Article> GetArticlesByWriter(int id)
        {
            //ArticleDal içerisinde tanımlanan metodun içi burada dolduruluyor.
            var values = context.Articles.Where(x => x.AppUser.Id == id).ToList();
            return values;
        }

        public List<Article> GetArticlesWithCategory()
        {
            var values = context.Articles.Include(x => x.Category).Include(x => x.Comments).ToList();
            return values;
        }

        public List<Article> GetArticlesWithCategoryByWriter(int id)
        {
            var values = context.Articles.Where(x => x.AppUserId == id).Include(x => x.Category).ToList(); //Include kullanarak articlea categorileri dahil etmiş oluyoruz.
            return values;
        }

        public Article GetArticleWithCategoryByArticleId(int id)
        {
            var values = context.Articles.Where(x => x.CategoryId == id).Include(y => y.Category).FirstOrDefault();
            return values;
        }

        public int CommentsCountByArticle(int id)
        {
            var values = context.Comments.Where(x => x.Article.ArticleId == id).Count();
            return values;
        }
    }
}
