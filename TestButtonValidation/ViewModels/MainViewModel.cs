using Caliburn.Micro;
using System;
using System.Linq;
using TestButtonValidation.Validators;
using System.Windows;
using FluentValidation;
using FluentValidation.Results;

namespace TestButtonValidation.ViewModels
{
    public  class MainViewModel : Screen
    {
        public MainViewModel()
        { _mainVal = new MainValidator(); }

        private readonly MainValidator _mainVal;
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value;
                NotifyOfPropertyChange(() => Name);
               
            }
        }

        public string this[string columnName]
        {
            get
            {
                var firstOrDefault = _mainVal.Validate(this).Errors.FirstOrDefault(lol => lol.PropertyName == columnName);
                if (firstOrDefault != null)
                    return _mainVal != null ? firstOrDefault.ErrorMessage : "";
                return "";
            }
        }
        public string Error
        {
            get
            {
                if (_mainVal != null)
                {
                    FluentValidation.Results.ValidationResult results = _mainVal.Validate(this);
                    if (results != null && results.Errors.Any())
                    {
                        string errors = string.Join(Environment.NewLine, results.Errors.Select(x => x.ErrorMessage).ToArray());
                        return errors;
                    }
                }
                return string.Empty;
            }
        }

        public void Testing_click()
        {
            ValidationResult results = _mainVal.Validate(this);
        }
    }
}
