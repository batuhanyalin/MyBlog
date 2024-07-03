using MyBlog.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.DataAccessLayer.Abstract
{
    public interface IArticleTagDal:IGenericDal<ArticleTag>
    {
        public List<Tag> GetTagsByArticleId(int id);
        ArticleTag GetByArticleIdAndTagId(int articleId, int tagId);
        void DeleteArticleTag(ArticleTag articleTag);
    }
}
