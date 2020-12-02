using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Caliburn.Micro;
using TestButtonValidation.Helpers;
using TestButtonValidation.ViewModels;

namespace TestButtonValidation
{
   public class AppBootstrapper : BootstrapperBase
    {
        public AppBootstrapper()
        {
            ConventionManager.AddElementConvention<PasswordBox>(
      PasswordBoxHelper.BoundPasswordProperty,
      "Password",
      "PasswordChanged");
            Initialize();
        }
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }
    }
    
}
