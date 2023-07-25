using System;
using System.Collections.Generic;

namespace Eventopia.Core.Data;

public partial class Comment
{
    public decimal Id { get; set; }

    public string? Content { get; set; }

    public decimal? Eventid { get; set; }

	public decimal? Userid { get; set; }

	public virtual Event? Event { get; set; }

	public virtual User? User { get; set; }
}
