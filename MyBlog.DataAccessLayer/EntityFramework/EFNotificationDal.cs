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
    public class EFNotificationDal : GenericRepository<Notification>, INotificationDal
    {
        BlogContext context = new BlogContext();
        public Notification ChangeIsStatusNotification(int id)
        {
            var values = context.Notifications.Find(id);
            if (values.Status == false)
            {
                values.Status = true;
            }
            else
            {
                values.Status = false;
            }
            context.SaveChanges();
            return values;
        }
        public List<Notification> GetListNotificationOrderByDescendingDate()
        {
            var values=context.Notifications.OrderByDescending(x => x.Date).ToList();
            return values;
        }
    }
}
