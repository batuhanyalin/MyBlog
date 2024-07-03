using MyBlog.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.BusinessLayer.Abstract
{
    public interface IArticleTagService:IGenericService<ArticleTag>
    {
        public List<Tag> TGetTagsByArticleId(int id);
        ArticleTag TGetByArticleIdAndTagId(int articleId, int tagId);
        void TDeleteArticleTag(ArticleTag articleTag);
    }
}
