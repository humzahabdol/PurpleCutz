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
    public class AppointmentController : ControllerBase
    {
        private readonly IDataRepository<Appointment> _dataRepository;
        public AppointmentController(IDataRepository<Appointment> dataRepository)
        {
            _dataRepository = dataRepository;
        }
        // GET: api/Appointment
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Appointment> appointments = _dataRepository.GetAll();
            return Ok(appointments);
        }

        // GET: api/Appointment/5
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            Appointment appointment = _dataRepository.Get(id);

            if (appointment == null)
            {
                return NotFound("The appointment record couldn't be found.");
            }

            return Ok(appointment);
        }

        // POST: api/Appointment
        [HttpPost]
        public IActionResult Post([FromBody] Appointment appointment)
        {
            if (appointment == null)
            {
                return BadRequest("Appointment is null.");
            }

            _dataRepository.Add(appointment);
            return CreatedAtRoute(
                "Get",
                new { Id = appointment.AppointmentId },
                appointment);
        }

        // PUT: api/Appointment/5
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Appointment appointment)
        {
            if (appointment == null)
            {
                return BadRequest("Appointment is null.");
            }

            Appointment appointmentToUpdate = _dataRepository.Get(id);
            if (appointmentToUpdate == null)
            {
                return NotFound("The appointment record couldn't be found.");
            }

            _dataRepository.Update(appointmentToUpdate, appointment);
            return NoContent();
        }

        // DELETE: api/Appointment/5
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            Appointment appointment = _dataRepository.Get(id);
            if (appointment == null)
            {
                return NotFound("The appointment record couldn't be found.");
            }

            _dataRepository.Delete(appointment);
            return NoContent();
        }
    }
}