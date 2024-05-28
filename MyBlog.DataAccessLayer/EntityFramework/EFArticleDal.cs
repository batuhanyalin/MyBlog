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
        BlogContext context=new BlogContext();
        public List<Article> GetArticlesByWriter(int id)
        {
            //ArticleDal içerisinde tanımlanan metodun içi burada dolduruluyor.
            var values= context.Articles.Where(x=>x.AppUser.Id==id).ToList();
            return values;
        }

        public List<Article> GetArticlesWithCategoryByWriter(int id)
        {
            var values=context.Articles.Where(x=>x.AppUserId==id).Include(x=>x.Category).ToList(); //Include kullanarak articlea categorileri dahil etmiş oluyoruz.
            return values;
        }
    }
}
