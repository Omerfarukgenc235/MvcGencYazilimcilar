using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori Adını Boş Geçemezsiniz.");
            RuleFor(x => x.CategoryAciklama).NotEmpty().WithMessage("Açıklamayı Boş Geçemezsiniz.");
            RuleFor(x => x.CategoryName).MinimumLength(2).WithMessage("Lütfen en az 2 karakter kullanınız.");
            RuleFor(x => x.CategoryName).MaximumLength(40).WithMessage("Lütfen en fazla 40 karakter kullanınız.");
            RuleFor(x => x.CategoryAciklama).MinimumLength(2).WithMessage("Lütfen en az 2 karakter kullanınız.");
            RuleFor(x => x.CategoryAciklama).MaximumLength(500).WithMessage("Lütfen en fazla 500 karakter kullanınız.");
        }
    }
}
