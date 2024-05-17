using FluentValidation;
using FluentValidation.AspNetCore;
using MyBlog.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.BusinessLayer.ValidationRules.CategoryValidation
{
    public class CreateCategoryValidation:AbstractValidator<Category> //Abstracvalidator çağırılıp içine ilgili sınıf ekleniyor
    {
        public CreateCategoryValidation()//Validasyon için gerekli metot ancak metotla birlikte çağırılabilir, bundan dolayı CreateCategoryValidation classı içine constructur method tanımlayıp RuleFor metodunu bu şekilde çağırabiliriz.
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori adı boş geçilemez.");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Lütfen en az 3 karakter veri girişi yapınız.");
            RuleFor(x => x.CategoryName).MaximumLength(30).WithMessage("Lütfen en fazla 30 karakter veri girişi yapınız.");
        }
    }
}
