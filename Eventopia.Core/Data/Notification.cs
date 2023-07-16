using System;
using System.Collections.Generic;

namespace Eventopia.Core.Data;

public partial class Notification
{
    public decimal Id { get; set; }

    public string? Content { get; set; }

    public DateTime? Receiveddate { get; set; }

    public decimal? Receiverid { get; set; }

    public virtual User? Receiver { get; set; }
}
