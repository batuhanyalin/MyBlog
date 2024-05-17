using MyBlog.BusinessLayer.Abstract;
using MyBlog.DataAccessLayer.Abstract;
using MyBlog.DataAccessLayer.Repositories;
using MyBlog.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService //Interface ICategoryService business katmanından geliyor.
    {
        //DEPENDENCY INECJTION
        private readonly ICategoryDal _categoryDal; //_categoryDal adında field oluşturuluyor.

        public CategoryManager(ICategoryDal categoryDal) // CONSTRUCTOR METHOD OLUŞTURULUYOR. YAPICI METOT
        {
            _categoryDal = categoryDal;
        }

        public void TDelete(int id) //IGenericService business katmanında gelen metotlar
        {
            _categoryDal.Delete(id);
        }

        public Category TGetById(int id)
        {
            return _categoryDal.GetById(id);
        }

        public List<Category> TGetListAll()
        {
            return _categoryDal.GetListAll();
        }

        public void TInsert(Category entity)
        {
            if (entity.CategoryName != "" && entity.CategoryName.Length > 3 && entity.CategoryName.Length < 30)
            {
                _categoryDal.Insert(entity);
            }
            else
            {
                //hata mesajı
            }
        }

        public void TUpdate(Category entity)
        {
           _categoryDal.Update(entity);
        }
    }
}
