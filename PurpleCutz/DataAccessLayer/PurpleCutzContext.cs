using Microsoft.EntityFrameworkCore;
using PurpleCutz.Entities;

namespace PurpleCutz.Models
{
    public class PurpleCutzContext : DbContext
    {
        public PurpleCutzContext(DbContextOptions options):base(options){}

        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        
    }
}