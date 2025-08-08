using System;
using System.Collections.Generic;

namespace localClinic.Models;

public partial class Booking
{
    public int BookingId { get; set; }

    public int? DoctorId { get; set; }

    public int? PatientId { get; set; }

    public DateTime? BookingDate { get; set; }

    public string? BookingStatus { get; set; }

    public string? Remark { get; set; }

    public virtual Doctor? Doctor { get; set; }

    public virtual Patient? Patient { get; set; }
}
