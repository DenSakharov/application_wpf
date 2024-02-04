using System.Data.Entity;

namespace application.Models
{
    /// <summary>
    /// Контекст базы данных для работы с Oracle
    /// <summary>
    public class OracleDBContext : DbContext
    {
        /// <summary>
        /// Набор данных для работы с таблицей Подразделение 
        /// </summary>
        public DbSet<Department> Departments { get; set; }
        /// <summary>
        /// Набор данных для работы с таблицей Справочник городов
        /// </summary>
        public DbSet<CityDictionary> CityDictionaries { get; set; }
        /// <summary>
        /// Набор данных для работы с таблицей Сотрудник 
        /// </summary>
        public DbSet<Employee> Employees { get; set; }
        /// <summary>
        /// Набор данных для работы с таблицей Справочник должностей
        /// </summary>
        public DbSet<PositionDictionary> PositionDictionaries { get; set; }
    }
}
