using FluentValidation;
using ZACx.Templates.WebApiProject.Core.Parameters.Examples;
using System.Text.RegularExpressions;

namespace ZACx.Templates.WebApiProject.Business.Validators.Examples
{
    internal class ExampleRequestParameterValidator : AbstractValidator<ExampleRequestParameter>
    {
        internal ExampleRequestParameterValidator()
        {
            RuleFor(p => p.Code)
                .NotEmpty().NotNull().WithMessage("Code bilgisi zorunludur!")
                .Matches(new Regex(@"^[a-zA-ZiİçÇşŞğĞÜüÖö]*$")).WithMessage("Sadece harf girebilirsiniz");

            When(p => p.Page <= 0, () =>
            {
                RuleFor(rl => rl.Page).NotEmpty().WithMessage("'Page' 0 dan büyük olmalıdır.");
            });

            When(x => x.Limit > 1000, () =>
            {
                RuleFor(m => m.Limit).LessThanOrEqualTo(1001).WithMessage("Limit Aşımı! Bir sayfada maksimum 1000 adet data görüntülenebilmektedir.");
            });
        }
    }
}
