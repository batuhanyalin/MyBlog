using MyBlog.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DataAccessLayer.Abstract
{
    public interface IMessageDal:IGenericDal<Message>
    {
        public List<Message> GetListMessageOrderByDescendingDate();
        Task<List<Message>> GetMessageByReceiverIdAsync(int id); //async yalnızca gövdeli metotlarda kullanılır, o yüzden o ibare kullanılamıyor.
        Task<List<Message>> GetInboxMessage(int id);
        public Message ChangeIsImportantMessageById(int id);
        public Message ChangeIsJunkMessageById(int id);
        Task<List<Message>> GetImportantMessage(int id);
        Task<List<Message>> GetSentMessage(int id);
        Task<List<Message>> GetJunkMessage(int id);
        public int GetSideBarInboxMessageCountByUserId(int id);
        public int GetSideBarJunkMessageCountByUserId(int id);
        public int GetSideBarImportantMessageCountByUserId(int id);
        public int GetSideBarSentMessageCountByUserId(int id);
        public int GetSideBarDraftMessageCountByUserId(int id);
        public Message ChangeIsReadMessageByMessageId(int id);
        public Message GetMessageDetailByMessageId(int id);
        public List<Message> GetListAllMessageWithSenderReceiver();
        public Message ChangeIsReadMessage2(int id);
        public Message ChangeIsReadMessageForAdminListMessagePanel(int id);
        public Message GetShowSentMessageDetail(int id);
        Task<List<Message>> GetMessageByReceiverIdByIsReadForNavBarMessage(int id);
        public int GetSideBarInboxIsReadFalseMessageCountByUserId(int id);

    }
}
