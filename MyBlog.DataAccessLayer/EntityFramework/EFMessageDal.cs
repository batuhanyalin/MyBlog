using MyBlog.DataAccessLayer.Repositories;
using MyBlog.DataAccessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyBlog.DataAccessLayer.Context;
using Microsoft.EntityFrameworkCore;

namespace MyBlog.DataAccessLayer.EntityFramework
{
    public class EFMessageDal : GenericRepository<Message>, IMessageDal
    {
        BlogContext context = new BlogContext();
        public List<Message> GetListMessageOrderByDescendingDate()
        {
            var values = context.Messages.OrderByDescending(x => x.SendingTime).ToList();
            return values;
        }
        public async Task<List<Message>> GetMessageByReceiverIdAsync(int id)
        {
            return await context.Messages.Where(x => x.ReceiverId == id).Include(x => x.Sender).Include(x => x.Receiver).ToListAsync();
        }
    }
}
