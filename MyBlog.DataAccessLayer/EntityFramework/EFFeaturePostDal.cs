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
    public class EFFeaturePostDal:GenericRepository<FeaturePost>,IFeaturePostDal
    {
        BlogContext context=new BlogContext();
        public List<FeaturePost> GetFeaturePostsWithArticle()
        {
            var values = context.FeaturePosts.Include(x=>x.Article).Include(x=>x.Article.Category).ToList();
            return values;
        }
    }
}
