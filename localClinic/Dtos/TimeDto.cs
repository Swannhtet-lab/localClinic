using localClinic.Models;

namespace localClinic.Dtos
{
    public class TimeDto
    {
        public int TimeId { get; set; }

        public string? StartTime { get; set; }

        public string? EndTime { get; set; }

        public string? TimeType { get; set; }

        public int? ScheduleId { get; set; }

        public string? AppointmentAvailability { get; set; }

       
    }
}
