using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PurpleCutz.Entities
{
    [Table("Barbers")]
    public class Barber
    {
        [Key]
        public int BarberId { get; set; }
        [ForeignKey("Person")]
        public int PersonId { get; set; }

        public virtual Person Person { get; set; }

    }
}
