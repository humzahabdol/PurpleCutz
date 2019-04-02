using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PurpleCutz.Entities
{
    [Table("Schedules")]
    public class Schedule
    {
        [Key]
        public int ScheduleId { get; set; }
        [Required]
        public int BarberId { get; set; }
        [Required]
        public DateTime Start_Time { get; set; }
        [Required]
        public DateTime End_Time { get; set; }
    }
}
