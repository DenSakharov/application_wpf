using application.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace application.ViewModels
{
    /// <summary>
    /// ViewModel для управления комбинированными данными.
    /// </summary>
    public class CombinedDataViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<CombinedData> _combinedDatas;
        /// <summary>
        /// Коллекция комбинированных данных.
        /// </summary>
        public ObservableCollection<CombinedData> CombinedDatas
        {
            get { return _combinedDatas; }
            set
            {
                _combinedDatas = value;
                OnPropertyChanged(nameof(CombinedDatas));
            }
        }

        public CombinedDataViewModel()
        {
            using (var dbContext = new OracleDBContext())
            {
                // Инициализация коллекции комбинированных данных при создании объекта ViewModel из 4х таблиц
                var combinedDatas = dbContext.Employees
                    .Join(
                        dbContext.Departments,
                        employee => employee.DepartmentId,
                        department => department.Id,
                        (employee, department) => new { employee, department })
                    .Join(
                        dbContext.CityDictionaries,
                        result => result.department.CityId,
                        city => city.Id,
                        (result, city) => new CombinedData
                    {
                        DepartmentName = result.department.Name,
                        EmployeeID = result.employee.Id,
                        EmployeeFullName = result.employee.FullName,
                        EmployeeSalary = result.employee.Salary,
                        CityName = city.CityName,
                        PositionTitle = result.employee.Position.PositionTitle
                    })
                .ToList();

                //CombinedDatas.Clear(); 
                CombinedDatas = new ObservableCollection<CombinedData>();
                foreach (var combinedData in combinedDatas)
                {
                    CombinedDatas.Add(combinedData);
                }
            }
        }
        /// <summary>
        /// Событие, уведомляющее об изменении свойства.
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
