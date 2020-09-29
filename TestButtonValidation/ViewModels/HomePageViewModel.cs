using Caliburn.Micro;
using System;
using System.ComponentModel;
using System.Linq;
using TestButtonValidation.Validators;

namespace TestButtonValidation.ViewModels
{
    public class HomePageViewModel : Screen, IDataErrorInfo
    {
        private readonly UserValidation _userValidator;
        public HomePageViewModel()
        {
           _userValidator = new UserValidation();
        }
        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                NotifyOfPropertyChange(() => Name);
            }
        }
        public string this[string columnName]
        {
            get
            {
                var firstOrDefault = _userValidator.Validate(this).Errors.FirstOrDefault(lol => lol.PropertyName == columnName);
                if (firstOrDefault != null)
                    return _userValidator != null ? firstOrDefault.ErrorMessage : "";
                return "";
            }
        }
        public string Error
        {
            get
            {
                if (_userValidator != null)
                {
                    FluentValidation.Results.ValidationResult results = _userValidator.Validate(this);
                    if (results != null && results.Errors.Any())
                    {
                        string errors = string.Join(Environment.NewLine, results.Errors.Select(x => x.ErrorMessage).ToArray());
                        return errors;
                    }
                    
                }
                return string.Empty;
            }
        }


        public void ValidateText()
        {
            //I would like to hid the error on the view until it is validated with this method
        
        
        
        }

    }
}
