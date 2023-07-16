using System;
using System.Collections.Generic;

namespace Eventopia.Core.Data;

public partial class Student
{
    public decimal Studentid { get; set; }

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public DateTime? Dateofbirth { get; set; }

    public virtual ICollection<Login> Logins { get; set; } = new List<Login>();

    public virtual ICollection<Stdcourse> Stdcourses { get; set; } = new List<Stdcourse>();
}
