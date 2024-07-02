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
    public class EFTagDal:GenericRepository<Tag>,ITagDal
    {
        BlogContext context=new BlogContext();
        public List<Tag> GetListTagWithArticle()
        {
            var values=context.Tags.Include(x=>x.ArticleTags).ThenInclude(x=>x.Article).ThenInclude(x=>x.AppUser).ToList();
            return values;
        }
    }
}
