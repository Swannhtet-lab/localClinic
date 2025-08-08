using Microsoft.AspNetCore.Mvc;
using localClinic.Dtos;
using localClinic.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using localClinic.Models;

namespace localClinic.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class DoctorController : ControllerBase
    {
        private readonly PjContext _context;
        private readonly IMapper _mapper;
        public DoctorController(PjContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetDoctors()
        {
            var doctors = await _context.Doctors.ToListAsync();
            return Ok(doctors);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDoctors([FromBody] DoctorDto dotcorDto)
        {
            var doctors = _mapper.Map<Doctor>(dotcorDto);
            _context.Doctors.Add(doctors);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDoctors), new { id = doctors.DoctorId }, doctors);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateDoctor(int id, [FromBody] DoctorDto doctorDto)
        {
            var existingDoctor = await _context.Doctors.FindAsync(id);
            if (existingDoctor == null)
                return NotFound();

            _mapper.Map(doctorDto, existingDoctor);
            await _context.SaveChangesAsync();

            return Ok(existingDoctor);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteDocotr(int id)
        {
            var deleteDoctor = await _context.Doctors.FindAsync(id);
            if(deleteDoctor == null)
            {
                return NotFound();
            }
            _context.Doctors.Remove(deleteDoctor);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
