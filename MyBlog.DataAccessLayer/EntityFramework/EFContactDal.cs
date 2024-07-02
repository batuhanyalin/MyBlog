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
    public class EFContactDal:GenericRepository<Contact>,IContactDal
    {
        BlogContext context= new BlogContext();
        public Contact ChangeIsReadContact(int id)
        {
            var values=context.Contacts.Find(id);
            if (values.IsRead == true)
            {
                values.IsRead = false;
            }
            else
            {
                values.IsRead = true;
            }
            context.SaveChanges();
            return values;
        }
    }
}
