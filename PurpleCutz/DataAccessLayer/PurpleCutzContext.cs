using Microsoft.EntityFrameworkCore;
using PurpleCutz.Entities;

namespace PurpleCutz.Models
{
    public class PurpleCutzContext : DbContext
    {
        public PurpleCutzContext(DbContextOptions options):base(options){}

        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Barber> Barbers { get; set; }
        public DbSet<Client> Clients { get; set; }
        
    }
}