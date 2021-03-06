﻿using Caliburn.Micro;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using TestButtonValidation.Validators;

namespace TestButtonValidation.ViewModels
{
    public class HomePageViewModel : Screen, IDataErrorInfo
    {
        private bool _validation;
        private string _blank;

        private bool _mybool=true;

        public bool Mybool
        {
            get { return _mybool; }
            set { _mybool = value; }
        }

        public string Blank
        {
            get { return _blank; }
            set { _blank = value;
                NotifyOfPropertyChange(() => Blank);
                }
        }

        public bool Validation
        {
            get { return _validation; }
            set { _validation = value;
                NotifyOfPropertyChange(() => Validation);
                }
        }
        private string _doubleValue;

        public string DoubleValue
        {
            get{ return _doubleValue; }
            set {
                _doubleValue = value;
                NotifyOfPropertyChange(() => DoubleValue);    
            }
        }


        private readonly UserValidation _userValidator;
        public HomePageViewModel()
        {
           _userValidator = new UserValidation();
            _validation = false;
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
                if (!Validation)
                {
                    return null;
                }
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
                if (Validation)
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
                }
                return string.Empty;
            }
        }
        public bool ValidatedForm()
        {
            bool isValid = false;
            Validation = true; // turn on validation
            NotifyOfPropertyChange(null); //refresh the properties/view
        
            if (Error.Length == 0)
            {
                isValid = true; //  no validation errors
            }
            else
            {
                isValid = false; // has validation Erros
            }

            return isValid;
        }

        public void ValidateText()
        {
            if (ValidatedForm())
            {
                MessageBox.Show("Valid Data");
                //No Errors
              //TODO: Add logic
            }
            else
            {
                //Has Errors
                //TODO: Add logic   
            }
        }
        public void ClearValidation()
        {

            Validation = false; // turn off validation
            NotifyOfPropertyChange(null); //refresh the properties/view
            
        }

    }
}
