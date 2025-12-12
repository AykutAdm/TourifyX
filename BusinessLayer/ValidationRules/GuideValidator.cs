using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class GuideValidator : AbstractValidator<Guide>
    {
        public GuideValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Lütfen rehber ismini giriniz...!");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Lütfen rehber açıklamasını giriniz...!");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Lütfen rehber görselini giriniz...!");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Lütfen en az 3 karakterlik isim giriniz...!");
            RuleFor(x => x.Name).MaximumLength(30).WithMessage("Lütfen 30 karakterden daha kısa bir isim giriniz...!");
        }
    }
}
