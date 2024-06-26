﻿using MyBlog.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DataAccessLayer.Abstract
{
    public interface ICategoryDal:IGenericDal<Category>
    {
        public List<Category> GetCategory();
        public List<Category> GetCategoryWithArticles();
        public List<Category> GetListCategoryWithArticle();
        public Category GetCategoryByCategoryId(int id);
    }
}
