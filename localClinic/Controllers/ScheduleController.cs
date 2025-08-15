using AutoMapper;
using localClinic.Data;
using localClinic.Dtos;
using localClinic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace SchoolProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ScheduleController : ControllerBase
    {
        private readonly PjContext _context;
        private readonly IMapper _mapper;

        public ScheduleController(PjContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllSchedules()
        {
            var schedules = await _context.Schedules
                .Include(s => s.Doctor)
                .Include(s => s.Times)
                .Select(s => new {
                    s.ScheduleId,
                    s.DoctorId,
                    s.Date,
                    DoctorName = s.Doctor.DoctorName,
                    s.DayOfWeek,
                    Times = s.Times.Select(t => new {
                        t.TimeId,
                        t.StartTime,
                        t.EndTime,
                        t.TimeType,
                        t.ScheduleId,
                        t.AppointmentAvailability
                    })
                })
                .ToListAsync();

            return Ok(schedules);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDoctorWithSchedule([FromBody] DoctorDto doctorDto)
        {
            if (doctorDto == null)
                return BadRequest("Invalid data");

            var doctor = _mapper.Map<Doctor>(doctorDto);

            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAllSchedules), new { id = doctor.DoctorId }, doctor);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateSchedule(int id, [FromBody] ScheduleDto scheduleDto)
        {
            var existingSchedule = await _context.Schedules
                .Include(s => s.Times)
                .FirstOrDefaultAsync(s => s.ScheduleId == id);

            if (existingSchedule == null)
                return NotFound();
            _mapper.Map(scheduleDto, existingSchedule);
            await _context.SaveChangesAsync();
            return Ok(existingSchedule);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteSchedule(int id)
        {
            var deleteSchedule = await _context.Schedules
                .Include(s => s.Times)
                .FirstOrDefaultAsync(s => s.ScheduleId == id);
            if (deleteSchedule == null)
            {
                return NotFound();
            }
            _context.Schedules.Remove(deleteSchedule);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}