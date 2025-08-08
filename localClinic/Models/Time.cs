using System;
using System.Collections.Generic;

namespace localClinic.Models;

public partial class Time
{
    public int TimeId { get; set; }

    public string? StartTime { get; set; }

    public string? EndTime { get; set; }

    public string? TimeType { get; set; }

    public int? ScheduleId { get; set; }

    public string? AppointmentAvailability { get; set; }

    public virtual Schedule? Schedule { get; set; }
}
