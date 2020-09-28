using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using TestButtonValidation.Views;

namespace TestButtonValidation.ViewModels
{
  public  class ShellViewModel : Conductor<object>
    {
        public ShellViewModel()
        {
           
            ActivateItem(new HomePageViewModel());
        }
    }
}
