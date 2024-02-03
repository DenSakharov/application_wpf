using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace application.Models
{

    [Table("CITYDICTIONARY", Schema = "MYUSER")]
    public class CityDictionary
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("CITYNAME")]
        [Required]
        [MaxLength(255)]
        public string CityName { get; set; }
    }

}
