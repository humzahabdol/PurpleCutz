using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PurpleCutz.Entities
{
    [Table("Appointments")]
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }

        [Required]
        public DateTime Date_Created { get; set; }

        [Required, ForeignKey("Client")]
        public int ClientId { get; set; }

        [Required, ForeignKey("Barber")]
        public int BarberId { get; set; }

        public DateTime Start_Time { get; set; }
        public DateTime End_Time_Expected { get; set; }
        public DateTime End_Time { get; set; }
        public int Price { get; set; }
        public int Price_Final { get; set; }
        public bool Cancelled { get; set; }
        public string Cancellation_Reason { get; set; }



        public virtual Client Client { get; set; }
        public virtual Barber Barber { get; set; }

    }
}
