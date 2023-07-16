using System;
using System.Collections.Generic;

namespace Eventopia.Core.Data;

public partial class Testimonial
{
    public decimal Id { get; set; }

    public string? Content { get; set; }

    public DateTime? Creationdate { get; set; }

    public string? Status { get; set; }

    public decimal? Userid { get; set; }

    public virtual User? User { get; set; }
}
