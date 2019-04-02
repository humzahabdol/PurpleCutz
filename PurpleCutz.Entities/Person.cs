using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PurpleCutz.Entities
{
    [Table("People")]
    public class Person
    {
        [Key]
        public int PersonId { get; set; }
        [Required]
        public string First_Name { get; set; }
        [Required]
        public string Last_Name { get; set; }
    }
}
