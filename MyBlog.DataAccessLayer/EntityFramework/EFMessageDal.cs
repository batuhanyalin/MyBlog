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
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
            return await context.Messages.Where(x => x.ReceiverId == id).Include(x => x.Sender).Include(x => x.Receiver).OrderByDescending(x => x.SendingTime).ToListAsync();
        }
        public async Task<List<Message>> GetInboxMessage(int id)
        {
            return await context.Messages.Where(x => x.ReceiverId == id).Where(x => x.IsDraft == false && x.IsJunk == false && x.IsImportant == false).Include(x => x.Sender).Include(x => x.Receiver).OrderByDescending(x => x.SendingTime).ToListAsync();
        }
        public async Task<List<Message>> GetImportantMessage(int id)
        {
            return await context.Messages.Where(x => x.ReceiverId == id).Where(x => x.IsDraft == false && x.IsJunk == false && x.IsImportant == true).Include(x => x.Sender).Include(x => x.Receiver).OrderByDescending(x => x.SendingTime).ToListAsync();
        }
        public async Task<List<Message>> GetJunkMessage(int id)
        {
            return await context.Messages.Where(x=>x.ReceiverId==id).Where(x=>x.IsDraft==false && x.IsJunk == true &&x.IsImportant==false).Include(x=>x.Sender).Include(x=>x.Receiver).OrderByDescending(x=>x.SendingTime).ToListAsync();
        }
        public Message ChangeIsImportantMessageById(int id)
        {
            var values = context.Messages.Find(id);
            if (values.IsImportant == false)
            {
                values.IsImportant = true;
            }
            else { values.IsImportant = false; }
            context.SaveChanges();
            return values;
        }
        public Message ChangeIsJunkMessageById(int id)
        {
            var values = context.Messages.Find(id);
            if (values.IsJunk == false)
            {
                values.IsJunk = true;
            }
            else
            {
                values.IsJunk = false;
            }
            context.SaveChanges();
            return values;
        }
    }
}
