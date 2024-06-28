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
using Microsoft.EntityFrameworkCore.Migrations.Operations;

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
        public async Task<List<Message>> GetDraftMessage(int id)
        {
            return await context.Messages.Where(x => x.SenderId == id).Where(x => x.IsDraft == true).Include(x => x.Receiver).Include(x => x.Sender).OrderByDescending(x=>x.SendingTime).ToListAsync();
        }

        public async Task<List<Message>> GetSentMessage(int id)
        {
            return await context.Messages.Where(x => x.SenderId == id).Where(x => x.IsDraft == false).Include(x => x.Sender).Include(x => x.Receiver).OrderByDescending(x => x.SendingTime).ToListAsync();
        }
        public async Task<List<Message>> GetImportantMessage(int id)
        {
            return await context.Messages.Where(x => x.ReceiverId == id).Where(x => x.IsDraft == false && x.IsJunk == false && x.IsImportant == true).Include(x => x.Sender).Include(x => x.Receiver).OrderByDescending(x => x.SendingTime).ToListAsync();
        }
        public async Task<List<Message>> GetJunkMessage(int id)
        {
            return await context.Messages.Where(x => x.ReceiverId == id).Where(x => x.IsDraft == false && x.IsJunk == true && x.IsImportant == false).Include(x => x.Sender).Include(x => x.Receiver).OrderByDescending(x => x.SendingTime).ToListAsync();
        }
        public Message ChangeIsImportantMessageById(int id)
        {
            var values = context.Messages.Find(id);
            if (values.IsJunk == false)
            {
                if (values.IsImportant == false)
                {
                    values.IsImportant = true;
                }
                else { values.IsImportant = false; }
            }
            else
            {
                return values;
            }
            context.SaveChanges();
            return values;
        }
        public Message ChangeIsJunkMessageById(int id)
        {
            var values = context.Messages.Find(id);
            if (values.IsImportant == false)
            {
                if (values.IsJunk == false)
                {
                    values.IsJunk = true;
                }
                else
                {
                    values.IsJunk = false;
                }
            }
            else
            {
                return values;
            }

            context.SaveChanges();
            return values;
        }

        public int GetSideBarInboxMessageCountByUserId(int id)
        {
            var values = context.Messages.Where(x => x.ReceiverId == id).Where(x => x.IsDraft == false && x.IsJunk == false && x.IsImportant == false).Include(x => x.Receiver).Include(x => x.Sender).Count();
            return values;
        }
        public int GetSideBarJunkMessageCountByUserId(int id)
        {
            var values = context.Messages.Where(x => x.ReceiverId == id).Where(x => x.IsJunk == true).Include(x => x.Receiver).Include(x => x.Sender).Count();
            return values;
        }
        public int GetSideBarImportantMessageCountByUserId(int id)
        {
            var values = context.Messages.Where(x => x.ReceiverId == id).Where(x => x.IsImportant == true).Include(x => x.Receiver).Include(x => x.Sender).Count();
            return values;
        }
        public int GetSideBarSentMessageCountByUserId(int id)
        {
            var values = context.Messages.Where(x => x.SenderId == id).Where(x => x.IsDraft == false).Include(x => x.Receiver).Include(x => x.Sender).Count();
            return values;
        }
        public int GetSideBarDraftMessageCountByUserId(int id)
        {
            var values = context.Messages.Where(x => x.SenderId == id).Where(x => x.IsDraft == true).Include(x => x.Receiver).Include(x => x.Sender).Count();
            return values;
        }
        public Message ChangeIsReadMessageByMessageId(int id)
        {
            var values = context.Messages.Find(id);
            if (values.IsRead == false)
            {
                values.IsRead = true;
            }
            else
            {
                values.IsRead = true;
            }
            context.SaveChanges();
            return values;
        }
        public Message GetMessageDetailByMessageId(int id)
        {
            var values = context.Messages.Where(x => x.MessageId == id).Include(x => x.Sender).Include(x => x.Receiver).FirstOrDefault();
            return values;
        }
        public List<Message> GetListAllMessageWithSenderReceiver()
        {
            var values = context.Messages.Include(x => x.Sender).Include(x => x.Receiver).ToList();
            return values;
        }
        public Message ChangeIsReadMessage2(int id)
        {
            var values = context.Messages.Find(id);
            if (values.IsRead == false)
            {
                values.IsRead = true;
            }
            else
            {
                values.IsRead = false;
            }
            context.SaveChanges();
            return values;
        }
        public Message ChangeIsReadMessageForAdminListMessagePanel(int id)
        {
            var values = context.Messages.Find(id);
            if (values.IsRead == false)
            {
                values.IsRead = true;
            }
            else
            {
                values.IsRead = false;
            }
            context.SaveChanges();
            return values;
        }
        public Message GetShowSentMessageDetail(int id)
        {
            var values = context.Messages.Where(x => x.MessageId == id).Include(x => x.Sender).Include(x => x.Receiver).FirstOrDefault();
            return values;
        }
        public Task<List<Message>> GetMessageByReceiverIdByIsReadForNavBarMessage(int id)
        {
            var values = context.Messages.Where(x => x.ReceiverId == id).Where(x => x.IsRead == false).Include(x => x.Sender).Include(x => x.Receiver).ToListAsync();
            return values;
        }
        public int GetSideBarInboxIsReadFalseMessageCountByUserId(int id)
        {
            var values = context.Messages.Where(x => x.ReceiverId == id).Where(x => x.IsRead == false&&x.IsImportant==false&&x.IsJunk==false).Include(x => x.Receiver).Include(x => x.Sender).Count();
            return values;
        }
        public Message EditDraftMessage(int id)
        {
            var values = context.Messages.Where(x => x.MessageId == id).Include(x => x.Receiver).Include(x => x.Sender).FirstOrDefault();
            return values;
        }
    }
}
