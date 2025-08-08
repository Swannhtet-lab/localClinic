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
    public class PatientController : ControllerBase
    {
        // Assuming you have a DbContext and IMapper injected here
        private readonly PjContext _context;
        private readonly IMapper _mapper;
        public PatientController(PjContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        // Define your actions here, e.g., GetPatients, CreatePatient, UpdatePatient, DeletePatient

        [HttpGet]
        public async Task<IActionResult> GetPatients()
        {
            var patients = await _context.Patients.ToListAsync();
            return Ok(patients);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePatient([FromBody] PatientDto patientDto)
        {
            var patient = _mapper.Map<Patient>(patientDto);
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPatients), new { id = patient.PatientId }, patient);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdatePatient(int id, [FromBody] PatientDto patientDto)
        {
            var existingPatient = await _context.Patients.FindAsync(id);
            if (existingPatient == null)
                return NotFound();
            _mapper.Map(patientDto, existingPatient);
            await _context.SaveChangesAsync();
            return Ok(existingPatient);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            var deletePatient = await _context.Patients.FindAsync(id);
            if (deletePatient == null)
            {
                return NotFound();
            }
            _context.Patients.Remove(deletePatient);
            await _context.SaveChangesAsync();
            return NoContent();

        }
    }
}
