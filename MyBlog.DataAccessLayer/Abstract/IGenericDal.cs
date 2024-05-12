using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class //t entityden gelen bir isimlendirme | Dışarıdan gelen T değeri bir class olmak zorunda.
        //Interfaceler genellikle I harfiyle adlandırılır.
    {
        //BU METOTLAR BÜTÜN ENTİTYLER İÇİN GEÇERLİ OLACAKLAR.
        void Insert(T entity);
        void Update(T entity);
        void Delete(int id);
        List<T> GetListAll();
        T GetById(int id);
    }
}
