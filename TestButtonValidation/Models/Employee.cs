using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TestButtonValidation.Models
{
    public  class Employee: INotifyPropertyChanged
    {
        public int IdEmployee { get; set; }
        // public string NameEmployee { get; set; }
        private string _nameEmployee;

        public string NameEmployee
        {
            get { return _nameEmployee; }
            set {
                _nameEmployee = value;
                OnPropertyChanged();
            }
        }

        public int DeptId { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
       
        // Create the OnPropertyChanged method to raise the event
        // The calling member's name will be used as the parameter.
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
