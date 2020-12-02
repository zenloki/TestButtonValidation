using FluentValidation;
using System;
using TestButtonValidation.ViewModels;

namespace TestButtonValidation.Validators
{
    public class UserValidation : AbstractValidator<HomePageViewModel>
    {
        public UserValidation()
        {

            //RuleFor(x => x.Name)
            //    .NotNull()
            //    .WithMessage("Nothing Entered");

            //RuleFor(x => x.Name)
            // .Length(2)
            // .WithMessage("Please ensure you have entered your {PropertyName}");

            //RuleFor(x => x.DoubleValue)
            //    .NotNull().WithMessage("Nothing Entered");

            //RuleFor(x=>x.DoubleValue)
            //    .Length(2).WithMessage("Length has to be 2");

            RuleFor(x => x.DoubleValue)
                
                .Custom((x, context) =>
                {
                    double value;
                    if ((!(double.TryParse(x, out value))))
                    {
                        context.AddFailure($"Not a valid number");
                    }
                    double result = value % 1;
                    double dbTurn = Math.Truncate(result * 100) / 100;

                    if (result.ToString().EndsWith("0") ||
                      result.ToString().EndsWith("0.25") ||
                      result.ToString().EndsWith("0.50") ||
                      result.ToString().EndsWith("0.75"))
                    {
                        
                    }
                    else
                    {
                        context.AddFailure("Not in .25 increments");

                    }
                });

            When(x => x != null, () =>
            {
                RuleFor(item => item.Blank)
                .Length(2)
                .WithMessage("Lent has to b 2");

                              });
        }
    }
}
