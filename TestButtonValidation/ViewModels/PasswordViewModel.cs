using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TestButtonValidation.Views
{
   public class PasswordViewModel : Screen
    {
        private string _password;
        private bool _isShow;
        private string _showPassword = "Show Password";

        public string ShowPassword
        {
            get { return _showPassword; }
            set { _showPassword = value;
                NotifyOfPropertyChange(() => ShowPassword);
            }
        }


        public bool IsShow
        {
            get { return _isShow ; }
            set { _isShow= value;
                NotifyOfPropertyChange(() => IsShow);
            }
        }

        public string Password
        {
            get { return _password; }
            set { 
                _password = value;
                NotifyOfPropertyChange(() => Password)
                ;
            }
        }
        public void CheckboxClicked()
        {
            if (IsShow == true)
            {
                ShowPassword = Password;
            }
            else
            { ShowPassword = null; }
        
        }
        public void ShowPasswordMethod()
        {
            ShowPassword = Password;
        }
        public void HidePassword()
        {
            ShowPassword = "Show Pass";
        }
    }
}
