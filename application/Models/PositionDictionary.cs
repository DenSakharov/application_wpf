using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace application.Models
{
    [Table("POSITIONDICTIONARY", Schema = "MYUSER")]
    public class PositionDictionary
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("POSITIONTITLE")]
        [Required]
        [MaxLength(255)]
        public string PositionTitle { get; set; }
    }
}
