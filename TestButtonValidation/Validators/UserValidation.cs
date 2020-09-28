using FluentValidation;
using TestButtonValidation.ViewModels;

namespace TestButtonValidation.Validators
{
    public class UserValidation : AbstractValidator<HomePageViewModel>
    {
        public UserValidation()
        {

            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage("Nothing Entered");

        }
    }
}
