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
        Task<List<Message>> TGetImportantMessage(int id);
        Task<List<Message>> TGetSentMessage(int id);
        Task<List<Message>> TGetJunkMessage(int id);
        public int TGetSideBarInboxMessageCountByUserId(int id);
        public int TGetSideBarJunkMessageCountByUserId(int id);
        public int TGetSideBarImportantMessageCountByUserId(int id);
        public int TGetSideBarSentMessageCountByUserId(int id);
        public int TGetSideBarDraftMessageCountByUserId(int id);
        public Message TChangeIsReadMessageByMessageId(int id);
        public Message TGetMessageDetailByMessageId(int id);
        public List<Message> TGetListAllMessageWithSenderReceiver();
        public Message TChangeIsReadMessage2(int id);
        public Message TChangeIsReadMessageForAdminListMessagePanel(int id);
        public Message TGetShowSentMessageDetail(int id);
    }
}
