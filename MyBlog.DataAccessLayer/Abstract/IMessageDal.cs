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
        Task<List<Message>> GetJunkMessage(int id);
    }
}
