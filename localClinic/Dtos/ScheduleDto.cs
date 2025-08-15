using localClinic.Models;

namespace localClinic.Dtos
{
    public class ScheduleDto
    {
        public int ScheduleId { get; set; }

        public int? DoctorId { get; set; }

        public string? DayOfWeek { get; set; }

        public string? Date { get; set; }

        public virtual ICollection<TimeDto> Times { get; set; } = new List<TimeDto>();

    }
}
