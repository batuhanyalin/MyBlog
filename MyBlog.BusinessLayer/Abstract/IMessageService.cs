using MyBlog.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.BusinessLayer.Abstract
{
    public interface IMessageService:IGenericService<Message>
    {
        public List<Message> TGetListMessageOrderByDescendingDate();
        Task<List<Message>> TGetMessageByReceiverIdAsync(int id);
        Task<List<Message>> TGetInboxMessage(int id);
        public Message TChangeIsImportantMessageById(int id);
        public Message TChangeIsJunkMessageById(int id);
    }
}
