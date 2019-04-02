using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PurpleCutz.Entities;
using PurpleCutzApi.DataAccessLayer;

namespace PurpleCutzApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly IDataRepository<Schedule> _dataRepository;

        public ScheduleController(IDataRepository<Schedule> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        // GET: api/Schedule
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Schedule> schedules = _dataRepository.GetAll();
            return Ok(schedules);
        }

        // GET: api/Schedule/5
        [HttpGet("{id}",Name = "Get")]
        public IActionResult Get(long id)
        {
            Schedule schedule = _dataRepository.Get(id);

            if (schedule == null)
            {
                return NotFound("The schedule record couldn't be found.");
            }

            return Ok(schedule);
        }

        // POST: api/Schedule
        [HttpPost]
        public IActionResult Post([FromBody] Schedule schedule)
        {
            if (schedule == null)
            {
                return BadRequest("Schedule is null.");
            }

            _dataRepository.Add(schedule);
            return CreatedAtRoute(
                "Get",
                new { Id = schedule.ScheduleId },
                schedule);
        }

        // PUT: api/Schedule/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Schedule schedule)
        {
            if (schedule == null)
            {
                return BadRequest("schedule is null.");
            }

            Schedule scheduleToUpdate = _dataRepository.Get(id);
            if (scheduleToUpdate == null)
            {
                return NotFound("The schedule record couldn't be found.");
            }

            _dataRepository.Update(schedule);
            return NoContent();
        }

        // DELETE: api/Schedule/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            Schedule schedule = _dataRepository.Get(id);
            if (schedule == null)
            {
                return NotFound("The schedule record couldn't be found.");
            }

            _dataRepository.Delete(schedule);
            return NoContent();
        }

    }
}