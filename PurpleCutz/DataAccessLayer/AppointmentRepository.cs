using System.Collections.Generic;
using System.Linq;
using PurpleCutz.Entities;
using PurpleCutz.Models;

namespace PurpleCutzApi.DataAccessLayer
{
    public class AppointmentRepository : IDataRepository<Appointment>
    {
        private readonly PurpleCutzContext _purpleCutzContext;
        public AppointmentRepository(PurpleCutzContext context)
        {
            _purpleCutzContext = context;
        }

        public IEnumerable<Appointment> GetAll()
        {
            return _purpleCutzContext.Appointments.ToList();
        }

        public Appointment Get(long id)
        {
            return _purpleCutzContext.Appointments
                .FirstOrDefault(e => e.AppointmentId == id);
        }

        public void Add(Appointment entity)
        {
            _purpleCutzContext.Appointments.Add(entity);
            _purpleCutzContext.SaveChanges();
        }

        public void Update(Appointment appointment, Appointment entity)
        {
            _purpleCutzContext.Entry(appointment).CurrentValues.SetValues(entity);
            _purpleCutzContext.SaveChanges();
        }

        public void Delete(Appointment appointment)
        {
            _purpleCutzContext.Appointments.Remove(appointment);
            _purpleCutzContext.SaveChanges();
        }
    }
}
