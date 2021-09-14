using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Blog Başlığını Boş Geçemezsiniz.");
            RuleFor(x => x.BlogImage).NotEmpty().WithMessage("Fotoğrafı Boş Geçemezsiniz.");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("İçeriği Boş Geçemezsiniz.");
            RuleFor(x => x.BlogTitle).MinimumLength(2).WithMessage("Lütfen en az 2 karakter kullanınız.");
            RuleFor(x => x.BlogTitle).MaximumLength(100).WithMessage("Lütfen en fazla 100 karakter kullanınız.");
            RuleFor(x => x.BlogImage).MinimumLength(2).WithMessage("Lütfen en az 2 karakter kullanınız.");
            RuleFor(x => x.BlogImage).MaximumLength(200).WithMessage("Lütfen en fazla 200 karakter kullanınız.");
            RuleFor(x => x.BlogContent).MinimumLength(2).WithMessage("Lütfen en az 2 karakter kullanınız.");
        }
    }
}
