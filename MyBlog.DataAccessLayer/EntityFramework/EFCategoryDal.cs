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
    public class EFCategoryDal : GenericRepository<Category>, ICategoryDal //efcategorydal hem genericrepository hem icategorydal interfaceinden miras alıyor. * Entityi repository ile haberleştiriyor.
    {
        BlogContext context = new BlogContext();
        public List<Category> GetCategory()
        {
            var values = context.Categories.ToList();
            return values;
        }
        public List<Category> GetCategoryWithArticles()
        {
            var values = context.Categories.Include(x => x.Articles).ToList();
            return values;
        }
        public List<Category> GetListCategoryWithArticle()
        {
            var values = context.Categories.Include(x => x.Articles).ToList();
            return values;
        }
        public Category GetCategoryByCategoryId(int id)
        {
            var values = context.Categories.Where(x => x.CategoryId == id).Include(x => x.Articles).FirstOrDefault();
            return values;
        }

    }
}
