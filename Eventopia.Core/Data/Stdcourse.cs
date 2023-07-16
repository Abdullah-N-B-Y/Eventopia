using System;
using System.Collections.Generic;

namespace Eventopia.Core.Data;

public partial class Stdcourse
{
    public decimal Id { get; set; }

    public decimal Stdid { get; set; }

    public decimal Courseid { get; set; }

    public decimal Markofstd { get; set; }

    public DateTime Dateofregister { get; set; }

    public virtual Course Course { get; set; } = null!;

    public virtual Student Std { get; set; } = null!;
}
