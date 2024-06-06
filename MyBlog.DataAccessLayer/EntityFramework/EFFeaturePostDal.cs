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
        public int GetFeaturePostsWithArticle()
        {
            return 0;
        }
    }
}
