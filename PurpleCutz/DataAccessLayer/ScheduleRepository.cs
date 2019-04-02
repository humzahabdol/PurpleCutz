using PurpleCutz.Entities;
using PurpleCutz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PurpleCutzApi.DataAccessLayer
{
    public class ScheduleRepository : IDataRepository<Schedule>
    {
        private readonly PurpleCutzContext _purpleCutzContext;
        public ScheduleRepository(PurpleCutzContext context)
        {
            _purpleCutzContext = context;
        }

        public IEnumerable<Schedule> GetAll()
        {
            return _purpleCutzContext.Schedules.ToList();
        }

        public Schedule Get(long id)
        {
            return _purpleCutzContext.Schedules
                .FirstOrDefault(e => e.ScheduleId == id);
        }

        public void Add(Schedule entity)
        {
            _purpleCutzContext.Schedules.Add(entity);
            _purpleCutzContext.SaveChanges();
        }

        public void Update(Schedule schedule, Schedule entity)
        {
            _purpleCutzContext.Entry(schedule).CurrentValues.SetValues(entity);
            _purpleCutzContext.SaveChanges();
        }

        public void Delete(Schedule schedule)
        {
            _purpleCutzContext.Schedules.Remove(schedule);
            _purpleCutzContext.SaveChanges();
        }
    }
}
