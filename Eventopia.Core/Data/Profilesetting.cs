using System;
using System.Collections.Generic;

namespace Eventopia.Core.Data;

public partial class Profilesetting
{
    public decimal Id { get; set; }

    public string? Language { get; set; }

    public string? Theme { get; set; }

    public decimal? Profileid { get; set; }

    public virtual Profile? Profile { get; set; }
}
