using Caliburn.Micro;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using TestButtonValidation.Models;
using TestButtonValidation.Validators;

namespace TestButtonValidation.ViewModels
{
    public class ListViewModel : Screen,IDataErrorInfo
    {
        public System.Action NotifyFromParent;
        private BindableCollection<Employee> _employees = new BindableCollection<Employee>();
        private BindableCollection<Department> _departments = new BindableCollection<Department>();
        public BindableCollection<Employee> Employees
        {
            get { return _employees; }
            set
            { _employees = value;
              
                NotifyOfPropertyChange(() => NameEmployee);
               
            }
        }
        public BindableCollection<Department> Departments
        {
            get { return _departments; }
            set
            {
                _departments = value;
                NotifyOfPropertyChange(() => Departments);
            }
        }

        private Employee _selectedItem;

        public Employee SelectedItem
        {
            get { return _selectedItem; }
            set { _selectedItem = value; NotifyOfPropertyChange(() => SelectedItem); }
        }

        private string _nameEmployee;

        public string NameEmployee
        {
            get { return _nameEmployee; }
            set { _nameEmployee = value;  NotifyOfPropertyChange(() => NameEmployee); }
        }
        private readonly EmployeeValidator _empValidator;
        public ListViewModel()
        {
            _empValidator = new EmployeeValidator();
            // simulated data from DB
            Employees.Add(new Employee { IdEmployee = 1, NameEmployee = string.Empty, DeptId = 1 });
            Employees.Add(new Employee { IdEmployee = 2, NameEmployee = "Mike", DeptId = 3 });

            Departments.Add(new Department { IdDept = 1, NameDept = "Accounting" });
            Departments.Add(new Department { IdDept = 2, NameDept = "Human Resource" });
            Departments.Add(new Department { IdDept = 3, NameDept = "IT" });


        }
        public void ShowSelectedItem()
        {

            if (SelectedItem != null)
            {
                MessageBox.Show(SelectedItem.DeptId.ToString());
            }
        }

        public string this[string columnName]
        {
            get
            {
               
                var firstOrDefault = _empValidator.Validate(this).Errors.FirstOrDefault(lol => lol.PropertyName == columnName);
                if (firstOrDefault != null)
                    return _empValidator != null ? firstOrDefault.ErrorMessage : "";
                return "";
            }
        }
        public string Error
        {
            get
            {
              

                    if (_empValidator != null)
                    {
                        FluentValidation.Results.ValidationResult results = _empValidator.Validate(this);
                        if (results != null && results.Errors.Any())
                        {
                            string errors = string.Join(Environment.NewLine, results.Errors.Select(x => x.ErrorMessage).ToArray());
                      
                            return errors;
                        }

                    }
              
                return string.Empty;
            }
        }
        public void AddEmp()
        {
            Employees.Add(new Employee { DeptId = 2, IdEmployee = 5, NameEmployee = "HHH" }); 
        }

    }
}
