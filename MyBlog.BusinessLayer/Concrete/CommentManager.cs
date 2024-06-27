using MyBlog.BusinessLayer.Abstract;
using MyBlog.DataAccessLayer.Abstract;
using MyBlog.DataAccessLayer.EntityFramework;
using MyBlog.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.BusinessLayer.Concrete
{
    public class CommentManager : ICommentService
    {
        private readonly ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public void TDelete(int id)
        {
            _commentDal.Delete(id);
        }

        public Comment TGetById(int id)
        {
           return _commentDal.GetById(id);
        }

        public List<Comment> TGetCommentsByArticle(int id)
        {
            return _commentDal.GetCommentsByArticle(id);
        }

        public List<Comment> TGetListAll()
        {
            return _commentDal.GetListAll();
        }

        public void TInsert(Comment entity)
        {
            _commentDal.Insert(entity);
        }

        public void TUpdate(Comment entity)
        {
            _commentDal.Update(entity);
        }
        public Comment TChangeIsApproved(int id)
        {
            return _commentDal.ChangeIsApproved(id);
        }

        public List<Comment> TGetListAllWithArticleAndAuthor()
        {
            return _commentDal.GetListAllWithArticleAndAuthor();
        }

        public int TGetCommentCountByGuestNameSurname(string Name, string Surname)
        {
            return _commentDal.GetCommentCountByGuestNameSurname(Name, Surname);
        }

        public int TGetCommentCountByToday()
        {
            return _commentDal.GetCommentCountByToday();
        }
    }
}
