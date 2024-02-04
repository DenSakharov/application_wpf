using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace application.Models
{
    /// <summary>
    /// Класс, представляющий Подразделение
    /// </summary>
    [Table("DEPARTMENTS", Schema = "MYUSER")]
    public class Department
    {
        /// <summary>
        /// Идентификатор Подразделения
        /// </summary>
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        /// <summary>
        /// Название Подразделения
        /// </summary>
        [Column("NAME")]
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        /// <summary>
        /// Идентификатор города Подразделения
        /// </summary>
        [Column("CITYID")]
        public int CityId { get; set; }

        /// <summary>
        /// Навигационное свойство, представляющее город Подразделения
        /// </summary>
        [ForeignKey("CityId")]
        public CityDictionary City { get; set; }
    }

}
