using localClinic.Models;

namespace localClinic.Dtos
{
    public class DoctorDto
    {
        public int DoctorId { get; set; }

        public string? DoctorName { get; set; }

        public string? DoctorAddress { get; set; }

        public string? DoctorGender { get; set; }

        public string? DoctorPhone { get; set; }

        public string? DoctorSpecialty { get; set; }

        public string? DoctorDescription { get; set; }

        public int? DoctorAge { get; set; }

        public virtual ICollection<BookingDto> Bookings { get; set; } = new List<BookingDto>();

        public virtual ICollection<ReceiptDto> Receipts { get; set; } = new List<ReceiptDto>();

        public virtual ICollection<ScheduleDto> Schedules { get; set; } = new List<ScheduleDto>();
    }
}
