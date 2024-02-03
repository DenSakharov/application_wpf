using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace application.Models
{
    [Table("DEPARTMENTS", Schema = "MYUSER")]
    public class Department
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }

        [Column("NAME")]
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Column("CITYID")]
        public int CityId { get; set; }

        [ForeignKey("CityId")]
        public CityDictionary City { get; set; }
    }
}
