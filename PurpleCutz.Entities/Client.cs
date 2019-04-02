using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PurpleCutz.Entities
{
    [Table("Clients")]
    public class Client
    {
        [Key]
        public int ClientId { get; set; }
        [ForeignKey("People")]
        [Required]
        public int PersonId { get; set; }
        [Required, MaxLength(15)]
        public string Phone_Number { get; set; }


        public virtual Person Person { get; set; }

    }
}
