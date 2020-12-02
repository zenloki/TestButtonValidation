using FluentValidation;
using TestButtonValidation.ViewModels;

namespace TestButtonValidation.Validators
{
    public class MainValidator:AbstractValidator<MainViewModel>

    {
        public MainValidator()
        {
            RuleFor(x => x.Name)
                    .NotEmpty()
                    .WithMessage("works");

            RuleFor(x => x.Name)
                .Length(2)
                .WithMessage("has Errors");



        }
    }
}
