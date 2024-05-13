using MyBlog.DataAccessLayer.Abstract;
using MyBlog.DataAccessLayer.Repositories;
using MyBlog.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DataAccessLayer.EntityFramework
{
    public class EFAuthorDal : GenericRepository<Author>, IAuthorDal
    {
        public int GetAuthorCount()
        {
            //yazar sayısını getiren sorgu
            return 0;
        }
    }
}
