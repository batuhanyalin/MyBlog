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
    public class EFCategoryDal : GenericRepository<Category>, ICategoryDal //efcategorydal hem genericrepository hem icategorydal interfaceinden miras alıyor. * Entityi repository ile haberleştiriyor.
    {
        private readonly ICategoryDal _categoryDal;

        public EFCategoryDal(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public int GetCategoryCount()
        {
            var value = _categoryDal.GetListAll().GroupBy(x => x.CategoryId).Count();
            return value;
        }
    }
}
