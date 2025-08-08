using System;
using System.Collections.Generic;

namespace localClinic.Models;

public partial class Receipt
{
    public int ReceiptId { get; set; }

    public int? DoctorId { get; set; }

    public int? TotalPatient { get; set; }

    public DateTime? LastUpdated { get; set; }

    public virtual Doctor? Doctor { get; set; }
}
