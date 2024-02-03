using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace application.Models
{
    [Table("EMPLOYEES", Schema = "MYUSER")]
    public class Employee
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("FULL_NAME")]
        [Required]
        [MaxLength(255)]
        public string FullName { get; set; }

        [Column("POSITION_ID")]
        public int PositionId { get; set; }

        [ForeignKey("PositionId")]
        public PositionDictionary Position { get; set; }
        [Column("DEPARTMENT_ID")]
        public int DepartmentId { get; set; } 

        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }

        [Column("SALARY")]
        public decimal Salary { get; set; }
    }
}
