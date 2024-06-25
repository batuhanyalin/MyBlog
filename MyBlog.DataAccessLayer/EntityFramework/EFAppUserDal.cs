using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Query;
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
    public class EFAppUserDal : GenericRepository<AppUser>, IAppUserDal
    {
        BlogContext context = new BlogContext();

        public AppUser ChangeIsApprovedArticleById(int id)
        {
            var values = context.Users.Find(id);
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
        public int GetCommentsCountByAuthor(int id)
        {
            var values = context.Comments.Where(x => x.AppUserId == id).Count();
            return values;
        }
        public int GetArticleCountByAuthor(int id)
        {
            var values = context.Articles.Where(x => x.AppUserId == id).Count();
            return values;
        }
        public List<AppUser> GetAuthorWithCommentArticle()
        {
            var values= context.Users.Where(x=>x.AppRoleId==1).Include(x=>x.Articles).Include(x=>x.Comments).ToList();
            return values;
        }   
        public List<AppUser> GetAdminWithCommentArticle()
        {
            var values= context.Users.Where(x=>x.AppRoleId==3 ||x.AppRoleId==2).Include(x=>x.Articles).Include(x=>x.Comments).ToList();
            return values;
        }
        public List<AppUser> GetAuthorWithCommentArticleByIsApproved()
        {
            var values=context.Users.Where(x=>x.IsApproved==true).Include(x => x.Articles).Include(x => x.Comments).OrderBy(x=>x.Name+x.Surname).ToList();
            return values;
        }
    }
}
