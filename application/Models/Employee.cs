using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace application.Models
{
    /// <summary>
    /// Класс, представляющий сотрудника 
    /// </summary>
    [Table("EMPLOYEES", Schema = "MYUSER")]
    public class Employee
    {
        /// <summary>
        /// Идентификатор сотрудника
        /// </summary>
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        /// <summary>
        /// ФИО сотрудника
        /// </summary>
        [Column("FULL_NAME")]
        [Required]
        [MaxLength(255)]
        public string FullName { get; set; }

        /// <summary>
        /// Идентификатор должности сотрудника
        /// </summary>
        [Column("POSITION_ID")]
        public int PositionId { get; set; }

        /// <summary>
        /// Навигационное свойство, представляющее должность сотрудника
        /// </summary>
        [ForeignKey("PositionId")]
        public PositionDictionary Position { get; set; }

        /// <summary>
        /// Идентификатор отдела, к которому принадлежит сотрудник
        /// </summary>
        [Column("DEPARTMENT_ID")]
        public int DepartmentId { get; set; }

        /// <summary>
        /// Навигационное свойство, представляющее отдел, к которому принадлежит сотрудник
        /// </summary>
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }

        /// <summary>
        /// Заработная плата сотрудника
        /// </summary>
        [Column("SALARY")]
        public decimal Salary { get; set; }
    }

}
