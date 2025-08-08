using System;
using System.Collections.Generic;

namespace localClinic.Models;

public partial class Doctor
{
    public int DoctorId { get; set; }

    public string? DoctorName { get; set; }

    public string? DoctorAddress { get; set; }

    public string? DoctorGender { get; set; }

    public string? DoctorPhone { get; set; }

    public string? DoctorSpecialty { get; set; }

    public string? DoctorDescription { get; set; }

    public int? DoctorAge { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual ICollection<Receipt> Receipts { get; set; } = new List<Receipt>();

    public virtual ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
}
