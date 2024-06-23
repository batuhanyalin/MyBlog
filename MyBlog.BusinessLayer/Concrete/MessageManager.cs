using MyBlog.BusinessLayer.Abstract;
using MyBlog.DataAccessLayer.Abstract;
using MyBlog.DataAccessLayer.Context;
using MyBlog.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        private readonly IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public Message TChangeIsImportantMessageById(int id)
        {
            return _messageDal.ChangeIsImportantMessageById(id);
        }

        public Message TChangeIsJunkMessageById(int id)
        {
            return _messageDal.ChangeIsJunkMessageById(id);
        }

        public void TDelete(int id)
        {
            _messageDal.Delete(id);
        }

        public Message TGetById(int id)
        {
            return _messageDal.GetById(id);
        }

        public Task<List<Message>> TGetImportantMessage(int id)
        {
            return _messageDal.GetImportantMessage(id);
        }

        public Task<List<Message>> TGetInboxMessage(int id)
        {
            return _messageDal.GetInboxMessage(id);
        }

        public Task<List<Message>> TGetJunkMessage(int id)
        {
            return _messageDal.GetJunkMessage(id);
        }

        public List<Message> TGetListAll()
        {
            return _messageDal.GetListAll();
        }

        public List<Message> TGetListMessageOrderByDescendingDate()
        {
            return _messageDal.GetListMessageOrderByDescendingDate();

        }

        public Task<List<Message>> TGetMessageByReceiverIdAsync(int id)
        {
            return _messageDal.GetMessageByReceiverIdAsync(id);
        }

        public int TGetSideBarDraftMessageCountByUserId(int id)
        {
            return _messageDal.GetSideBarDraftMessageCountByUserId(id);
        }

        public int TGetSideBarImportantMessageCountByUserId(int id)
        {
            return _messageDal.GetSideBarImportantMessageCountByUserId(id);
        }

        public int TGetSideBarInboxMessageCountByUserId(int id)
        {
            return _messageDal.GetSideBarInboxMessageCountByUserId(id);
        }

        public int TGetSideBarJunkMessageCountByUserId(int id)
        {
            return _messageDal.GetSideBarJunkMessageCountByUserId(id);
        }

        public int TGetSideBarSentMessageCountByUserId(int id)
        {
            return _messageDal.GetSideBarSentMessageCountByUserId(id);
        }

        public void TInsert(Message entity)
        {
            _messageDal.Insert(entity);
        }

        public void TUpdate(Message entity)
        {
            _messageDal.Update(entity);
        }
        public Message TChangeIsReadMessageByMessageId(int id)
        {
            return _messageDal.ChangeIsReadMessageByMessageId(id);
        }

        public Message TGetMessageDetailByMessageId(int id)
        {
            return _messageDal.GetMessageDetailByMessageId(id);
        }
    }
}
