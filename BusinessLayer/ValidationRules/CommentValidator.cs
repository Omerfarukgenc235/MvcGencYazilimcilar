using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CommentValidator : AbstractValidator<Comment>
    {
        public CommentValidator()
        {
            RuleFor(x => x.CommentText).NotEmpty().WithMessage("Yorumu Boş Geçemezsiniz.");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Açıklamayı Boş Geçemezsiniz.");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı Adını Boş Geçemezsiniz.");
            RuleFor(x => x.BlogRating).NotEmpty().WithMessage("Puanı Boş Geçemezsiniz.");
            RuleFor(x => x.UserName).MinimumLength(1).WithMessage("Lütfen en az 1 karakter kullanınız.");
            RuleFor(x => x.UserName).MaximumLength(20).WithMessage("Lütfen en fazla 20 karakter kullanınız.");
            RuleFor(x => x.Mail).MinimumLength(1).WithMessage("Lütfen en az 1 karakter kullanınız.");
            RuleFor(x => x.Mail).MaximumLength(50).WithMessage("Lütfen en fazla 50 karakter kullanınız.");
            RuleFor(x => x.CommentText).MinimumLength(1).WithMessage("Lütfen en az 1 karakter kullanınız.");
            RuleFor(x => x.Mail).MaximumLength(400).WithMessage("Lütfen en fazla 50 karakter kullanınız.");
        }
    }
}
