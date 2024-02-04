using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace application.Models
{
    /// <summary>
    /// Сущность, представляющая таблицу Справочник должностей
    /// </summary>
    [Table("POSITIONDICTIONARY", Schema = "MYUSER")]
    public class PositionDictionary
    {
        /// <summary>
        /// Уникальный идентификатор должности
        /// </summary>
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        /// <summary>
        /// Название должности
        /// </summary>
        [Column("POSITIONTITLE")]
        [Required]
        [MaxLength(255)]
        public string PositionTitle { get; set; }
    }
}
