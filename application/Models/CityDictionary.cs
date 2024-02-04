using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace application.Models
{
    /// <summary>
    /// Класс, представляющий сущность "Город".
    /// </summary>
    [Table("CITYDICTIONARY", Schema = "MYUSER")]
    public class CityDictionary
    {
        /// <summary>
        /// Уникальный идентификатор города
        /// </summary>
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        /// <summary>
        /// Название города
        /// </summary>
        [Column("CITYNAME")]
        [Required]
        [MaxLength(255)]
        public string CityName { get; set; }
    }
}
