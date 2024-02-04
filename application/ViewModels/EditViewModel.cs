using application.Commands;
using application.Models;
using System;
using System.ComponentModel;
using System.Windows.Input;

namespace application.ViewModels
{
    public class EditViewModel : INotifyPropertyChanged
    {
        private CombinedData _data;

        public EditViewModel(CombinedData data)
        {
            _data = data;
        }

        public string DepartmentName
        {
            get { return _data.DepartmentName; }
            set
            {
                if (_data.DepartmentName != value)
                {
                    _data.DepartmentName = value;
                    OnPropertyChanged(nameof(DepartmentName));
                }
            }
        }

        public string EmployeeFullName
        {
            get { return _data.EmployeeFullName; }
            set
            {
                if (_data.EmployeeFullName != value)
                {
                    _data.EmployeeFullName = value;
                    OnPropertyChanged(nameof(EmployeeFullName));
                }
            }
        }

        public decimal EmployeeSalary
        {
            get { return _data.EmployeeSalary; }
            set
            {
                if (_data.EmployeeSalary != value)
                {
                    _data.EmployeeSalary = value;
                    OnPropertyChanged(nameof(EmployeeSalary));
                }
            }
        }

        public string PositionTitle
        {
            get { return _data.PositionTitle; }
            set
            {
                if (_data.PositionTitle != value)
                {
                    _data.PositionTitle = value;
                    OnPropertyChanged(nameof(PositionTitle));
                }
            }
        }

        public ICommand SaveCommand => new RelayCommand(obj=>Save());

        public event EventHandler RequestClose;

        private void Save()
        {
            using (var dbContext = new OracleDBContext())
            {
                var employee = dbContext.Employees.Find(_data.EmployeeID);
                var department = dbContext.Departments.Find(employee.DepartmentId);
                var position = dbContext.PositionDictionaries.Find(employee.PositionId);

                if (employee != null && department != null && position != null)
                {
                    employee.FullName = _data.EmployeeFullName;
                    employee.Salary = _data.EmployeeSalary;
                    department.Name = _data.DepartmentName;
                    position.PositionTitle = _data.PositionTitle;

                    dbContext.SaveChanges();
                }
            }
            RequestClose?.Invoke(this, EventArgs.Empty);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
