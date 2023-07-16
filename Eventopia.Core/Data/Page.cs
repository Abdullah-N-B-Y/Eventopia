using System;
using System.Collections.Generic;

namespace Eventopia.Core.Data;

public partial class Page
{
    public decimal Id { get; set; }

    public string? Content1 { get; set; }

    public string? Content2 { get; set; }

    public string? Backgroundimagepath { get; set; }

    public decimal? Adminid { get; set; }

    public virtual User? Admin { get; set; }
}
