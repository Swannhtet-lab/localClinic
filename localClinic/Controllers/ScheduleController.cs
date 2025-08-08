using Microsoft.AspNetCore.Mvc;
using localClinic.Dtos;
using localClinic.Models;
using AutoMapper;
using localClinic.Data;
using Microsoft.EntityFrameworkCore;

namespace localClinic.Controllers
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
        public async Task <IActionResult> GetAllSchedules()
        {
            var schedules = await _context.Schedules
                .Include(s => s.Times)
                .ToListAsync();
            
            return Ok(schedules);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSchedule([FromBody] ScheduleDto scheduleDto)
        {
            var schedule = _mapper.Map<Schedule>(scheduleDto);
            _context.Schedules.Add(schedule);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAllSchedules), new { id = schedule.ScheduleId }, schedule);
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
