using localClinic.Models;

namespace localClinic.Dtos
{
    public class BookingDto
    {
        public int BookingId { get; set; }

        public int? DoctorId { get; set; }

        public int? PatientId { get; set; }

        public DateTime? BookingDate { get; set; }

        public string? BookingStatus { get; set; }

        public string? Remark { get; set; }

        
    }
}
