﻿using MyBlog.DataAccessLayer.Abstract;
using MyBlog.DataAccessLayer.Context;
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
        BlogContext context = new BlogContext();
        public List<Category> GetCategory()
        {
            var values = context.Categories.ToList();
            return values;
        }

    }
}
