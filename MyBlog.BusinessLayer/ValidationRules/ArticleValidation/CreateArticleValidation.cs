using FluentValidation;
using MyBlog.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.BusinessLayer.ValidationRules.ArticleValidation
{
    public class CreateArticleValidation : AbstractValidator<Article>
    {
        public CreateArticleValidation()
        {
            RuleFor(X=>X.Title).NotEmpty().WithMessage("Başlık boş geçilemez.").MinimumLength(3).WithMessage("Başlık değeri en az 3 karakter olmak zorundadır.").MaximumLength(3).WithMessage("Başlık değeri en fazla 20 karakter olmak zorundadır.");
            RuleFor(x=>x.Detail).NotEmpty().WithMessage("Detaylar bölümü boş geçilemez.");
        }
    }
}
