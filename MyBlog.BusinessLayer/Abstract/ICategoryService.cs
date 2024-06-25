using MyBlog.DataAccessLayer.Abstract;
using MyBlog.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.BusinessLayer.Abstract
{
    public interface ICategoryService : IGenericService<Category>
    {
        public List<Category> TGetCategory();
        public List<Category> TGetCategoryWithArticles();
        public List<Category> TGetListCategoryWithArticle();
    }

}
