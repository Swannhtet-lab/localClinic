using localClinic.Models;

namespace localClinic.Dtos
{
    public class ReceiptDto
    {
        public int ReceiptId { get; set; }

        public int? DoctorId { get; set; }

        public int? TotalPatient { get; set; }

        public DateTime? LastUpdated { get; set; }

        
    }
}
