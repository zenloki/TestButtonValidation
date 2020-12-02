using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using TestButtonValidation.ViewModels;

namespace TestButtonValidation.Validators
{
  public  class EmployeeValidator : AbstractValidator<ListViewModel>
    {
        public EmployeeValidator()
        {
            RuleFor(s => s.NameEmployee)
                .NotEmpty()
                  .WithMessage("nope");
          
            
            //RuleForEach(x => x.Employees).ChildRules(orders => {
            //    orders.RuleFor(x => x.NameEmployee)
            //    .NotEmpty()
            //    .WithMessage("Works");
            //});


        }
    }
}
