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
    public class EFCommetDal : GenericRepository<Comment>, ICommentDal
    {
        BlogContext context = new BlogContext();

        public List<Comment> GetCommentsByArticle(int id)
        {
            return context.Comments.Where(x => x.ArticleId == id).Where(x=>x.IsApproved==true).OrderByDescending(x=>x.CreatedDate).ToList();
        }
        public Comment ChangeIsApproved(int id)
        {
            var values = context.Comments.Find(id);
            if (values.IsApproved == false)
            {
                values.IsApproved = true;
            }
            else
            {
                values.IsApproved = false;
            }
            context.SaveChanges();
            return values;
        }
        public List<Comment> GetListAllWithArticleAndAuthor()
        {
            return context.Comments.Include(x => x.Article).Include(x=>x.Article.AppUser).Include(x=>x.AppUser).ToList();
        }
        public int GetCommentCountByGuestNameSurname(string Name,string Surname)
        {
            var value = context.Comments.Where(x => x.Name == Name && x.Surname == Surname).Count();
            return value;
        }
        public int GetCommentCountByToday()
        {
            var startOfDay=DateTime.Today;
            var endOfDay = startOfDay.AddDays(1).AddTicks(-1);
            var values = context.Comments.Where(x => x.CreatedDate >= startOfDay && x.CreatedDate <= endOfDay).Count();
            return values;
        }
        public List<Comment> GetListAllWithArticleByAuthorId(int id)
        {
            var values = context.Comments.Where(x=>x.Article.AppUserId==id).Include(x => x.Article).Include(x => x.AppUser).ToList();
            return values;
        }
    }
}
