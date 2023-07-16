using System;
using System.Collections.Generic;

namespace Eventopia.Core.Data;

public partial class Booking
{
    public decimal Id { get; set; }

    public DateTime? Bookingdate { get; set; }

    public decimal? Userid { get; set; }

    public decimal? Eventid { get; set; }

    public virtual Event? Event { get; set; }

    public virtual User? User { get; set; }
}
