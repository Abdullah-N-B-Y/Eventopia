using System;
using System.Collections.Generic;

namespace Eventopia.Core.Data;

public partial class Comment
{
    public decimal Id { get; set; }

    public string? Content { get; set; }

    public decimal? Eventid { get; set; }

    public virtual Event? Event { get; set; }
}
