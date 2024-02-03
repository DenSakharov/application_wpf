using System.Data.Entity;

namespace application.Models
{
    public class OracleDBContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<CityDictionary> CityDictionaries { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<PositionDictionary> PositionDictionaries { get; set; }
    }
}
