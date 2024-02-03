using application.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace application.ViewModels
{
    public class DepartmentViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Department> _departments;

        public ObservableCollection<Department> Departments
        {
            get { return _departments; }
            set
            {
                _departments = value;
                OnPropertyChanged(nameof(Departments));
            }
        }

        public DepartmentViewModel()
        {
            using (var dbContext = new OracleDBContext())
            {
                Departments = new ObservableCollection<Department>(dbContext.Departments.ToList());
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
