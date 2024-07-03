using Microsoft.EntityFrameworkCore;
using MyBlog.DataAccessLayer.Abstract;
using MyBlog.DataAccessLayer.Context;
using MyBlog.DataAccessLayer.Repositories;
using MyBlog.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DataAccessLayer.EntityFramework
{
    public class EFArticleTagDal : GenericRepository<ArticleTag>, IArticleTagDal
    {
        BlogContext context = new BlogContext();
        public List<Tag> GetTagsByArticleId(int id)
        {
            return context.ArticleTags.Where(x => x.ArticleId == id).Include(x=>x.Article).Include(x=>x.Tag).Select(x => x.Tag).ToList();

        }
        public ArticleTag GetByArticleIdAndTagId(int articleId, int tagId)
        {
            return context.ArticleTags.FirstOrDefault(at => at.ArticleId == articleId && at.TagId == tagId);
        }
        public void DeleteArticleTag(ArticleTag articleTag)
        {
                context.ArticleTags.Remove(articleTag);
                context.SaveChanges();
        }
    }
}
