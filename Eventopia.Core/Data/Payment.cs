using System;
using System.Collections.Generic;

namespace Eventopia.Core.Data;

public partial class Payment
{
    public decimal? Id { get; set; }

    public DateTime? Paymentdate { get; set; }

    public decimal? Amount { get; set; }

    public string? Method { get; set; }

    public string? Status { get; set; }

    public decimal? Userid { get; set; }

    public virtual User? User { get; set; }
}
