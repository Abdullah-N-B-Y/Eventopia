using System;
using System.Collections.Generic;

namespace Eventopia.Core.Data;

public partial class Categoryy
{
    public decimal Categoryyid { get; set; }

    public string Categoryname { get; set; } = null!;

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}
