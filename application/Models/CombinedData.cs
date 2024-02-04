using System.ComponentModel;

namespace application.Models
{
    /// <summary>
    /// Класс, представляющий комбинированные данные о сотруднике
    /// </summary>
    public class CombinedData
    {
        /// <summary>
        /// Идентификатор сотрудника
        /// </summary>
        [DisplayName("Идентификатор сотрудника")]
        public int EmployeeID { get; set; }

        /// <summary>
        /// ФИО сотрудника
        /// </summary>
        [DisplayName("Полное имя сотрудника")]
        public string EmployeeFullName { get; set; }

        /// <summary>
        /// Название отдела
        /// </summary>
        [DisplayName("Название отдела")]
        public string DepartmentName { get; set; }

        /// <summary>
        /// Название города
        /// </summary>
        [DisplayName("Название города")]
        public string CityName { get; set; }

        /// <summary>
        /// Должность сотрудника
        /// </summary>
        [DisplayName("Должность")]
        public string PositionTitle { get; set; }

        /// <summary>
        /// Заработная плата сотрудника
        /// </summary>
        [DisplayName("Заработная плата сотрудника")]
        public decimal EmployeeSalary { get; set; }
    }

}
