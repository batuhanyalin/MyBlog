using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.BusinessLayer.Abstract
{
    public interface IGenericService<T> where T:class // T İLE BURAYA PARAMETRE GÖNDERİLİYOR VE BU PARAMETRE MUTLAKA CLASS OLMAK ZORUNDA, GENERICSERVICE ÇAĞIRILDIĞI YERDE MUTLAKA BİR PARAMETRE VERİLMEK ZORUNDA OLUNACAK. -  DALdan gelen metotlar çağrılmadan önce validasyonlara tabi tutulacaklar.
    {
        //BURADA METOTLAR DATAACCESS KATMANIYLA ÇAKIŞMAMASI İÇİN METOT İSİMLERİNİN BAŞLARINA T HARFİ EKLENDİ.
        void TInsert(T entity);
        void TDelete(int id);
        void TUpdate(T entity);      
        List<T> TGetListAll();
        T TGetById(int id);
    }
}
