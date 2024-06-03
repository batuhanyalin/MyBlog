﻿using MyBlog.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DataAccessLayer.Abstract
{
    public interface IArticleDal : IGenericDal<Article>
    {
        //Entitye özgü metotlar yazılıyor.
        List<Article> GetArticlesByWriter(int id);

        List<Article> GetArticlesWithCategoryByWriter(int id);

        List<Article> GetArticlesWithCategory();
        Article GetArticleWithCategoryByArticleId(int id);
        public int CommentsCountByArticle(int id);
        public int GetReadingTime(int id);
        public List<Article> GetAppUserInfoByArticleId(int id);
    }
}
