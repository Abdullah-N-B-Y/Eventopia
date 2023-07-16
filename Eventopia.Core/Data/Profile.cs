using System;
using System.Collections.Generic;

namespace Eventopia.Core.Data;

public partial class Profile
{
    public decimal Id { get; set; }

    public string? Firstname { get; set; }

    public string? Lastname { get; set; }

    public string? Imagepath { get; set; }

    public decimal? Phonenumber { get; set; }

    public string? Gender { get; set; }

    public DateTime? Dateofbirth { get; set; }

    public string? Bio { get; set; }

    public decimal? Rate { get; set; }

    public decimal? Userid { get; set; }

    public virtual ICollection<Profilesetting> Profilesettings { get; set; } = new List<Profilesetting>();

    public virtual User? User { get; set; }
}
