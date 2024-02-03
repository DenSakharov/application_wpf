using application.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace application.ViewModels
{
    public class CombinedDataViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<CombinedData> _combinedDatas;

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

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
