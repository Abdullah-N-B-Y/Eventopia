using System;
using System.Collections.Generic;

namespace Eventopia.Core.Data;

public partial class Message
{
    public decimal Id { get; set; }

    public string? Content { get; set; }

    public DateTime? Messagedate { get; set; }

    public decimal? Isread { get; set; }

    public decimal? Isdeleted { get; set; }

    public decimal? Senderid { get; set; }

    public decimal? Receiverid { get; set; }

    public virtual User? Receiver { get; set; }

    public virtual User? Sender { get; set; }
}
