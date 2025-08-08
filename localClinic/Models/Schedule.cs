using System;
using System.Collections.Generic;

namespace localClinic.Models;

public partial class Schedule
{
    public int ScheduleId { get; set; }

    public int? DoctorId { get; set; }

    public string? DayOfWeek { get; set; }

    public virtual Doctor? Doctor { get; set; }

    public virtual ICollection<Time> Times { get; set; } = new List<Time>();
}
