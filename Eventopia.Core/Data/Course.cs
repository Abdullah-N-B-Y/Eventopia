using System;
using System.Collections.Generic;

namespace Eventopia.Core.Data;

public partial class Course
{
    public decimal Courseid { get; set; }

    public string Coursename { get; set; } = null!;

    public decimal Categoryyid { get; set; }

    public string Imagename { get; set; } = null!;

    public virtual Categoryy Categoryy { get; set; } = null!;

    public virtual ICollection<Stdcourse> Stdcourses { get; set; } = new List<Stdcourse>();
}
