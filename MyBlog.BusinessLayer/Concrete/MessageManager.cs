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

        public Task<List<Message>> TGetInboxMessage(int id)
        {
            return _messageDal.GetInboxMessage(id);
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

        public void TInsert(Message entity)
        {
            _messageDal.Insert(entity);
        }

        public void TUpdate(Message entity)
        {
            _messageDal.Update(entity);
        }
    }
}
