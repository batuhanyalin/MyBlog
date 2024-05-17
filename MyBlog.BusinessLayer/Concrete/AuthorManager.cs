using MyBlog.BusinessLayer.Abstract;
using MyBlog.DataAccessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.BusinessLayer.Concrete
{
    public class AuthorManager : IAuthorService
    {
        private readonly IAuthorDal _authorDal;
        public AuthorManager(IAuthorDal authorDal)
        {
           _authorDal = authorDal;
        }
        public void TDelete(int id)
        {
            _authorDal.Delete(id);
        }

        public Author TGetById(int id)
        {
           return _authorDal.GetById(id);
        }

        public List<Author> TGetListAll()
        {
            return _authorDal.GetListAll();
        }

        public void TInsert(Author entity)
        {
            _authorDal.Insert(entity);
        }

        public void TUpdate(Author entity)
        {
            _authorDal.Update(entity);
        }
    }
}
