using localClinic.Models;

namespace localClinic.Dtos
{
    public class PatientDto
    {
        public int PatientId { get; set; }

        public string? PatientName { get; set; }

        public string? PatientAddress { get; set; }

        public string? PatientGender { get; set; }

        public int? PatientAge { get; set; }

        public string? PatientType { get; set; }

        public DateTime? CreatedDate { get; set; }

        public virtual ICollection<BookingDto> Bookings { get; set; } = new List<BookingDto>();
    }
}
