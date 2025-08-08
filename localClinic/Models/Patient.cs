using System;
using System.Collections.Generic;

namespace localClinic.Models;

public partial class Patient
{
    public int PatientId { get; set; }

    public string? PatientName { get; set; }

    public string? PatientAddress { get; set; }

    public string? PatientGender { get; set; }

    public int? PatientAge { get; set; }

    public string? PatientType { get; set; }

    public DateTime? CreatedDate { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}
