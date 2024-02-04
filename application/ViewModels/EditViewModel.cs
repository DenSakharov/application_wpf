using application.Commands;
using application.Models;
using System;
using System.ComponentModel;
using System.Windows.Input;

namespace application.ViewModels
{
    /// <summary>
    /// ViewModel для редактирования комбинированных данных.
    /// </summary>
    public class EditViewModel : INotifyPropertyChanged
    {
        private CombinedData _data;
        /// <summary>
        /// Конструктор класса EditViewModel.
        /// </summary>
        /// <param name="data">Данные для редактирования.</param>
        public EditViewModel(CombinedData data)
        {
            _data = data;
        }
        /// <summary>
        /// Название отдела.
        /// </summary>
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
        /// <summary>
        /// Полное имя сотрудника.
        /// </summary>
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
        /// <summary>
        /// Заработная плата сотрудника.
        /// </summary>
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
        /// <summary>
        /// Должность сотрудника.
        /// </summary>
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
        /// <summary>
        /// Команда сохранения изменений.
        /// </summary>
        public ICommand SaveCommand => new RelayCommand(obj => Save());
        /// <summary>
        /// Событие, уведомляющее о закрытии окна редактирования.
        /// </summary>
        public event EventHandler RequestClose;
        /// <summary>
        /// Метод сохранения изменений в базе данных.
        /// </summary>
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
        /// <summary>
        /// Событие, уведомляющее об изменении значения свойства.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Вызывается при изменении значения свойства.
        /// </summary>
        /// <param name="propertyName">Имя измененного свойства.</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
