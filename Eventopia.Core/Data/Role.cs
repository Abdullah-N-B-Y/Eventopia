using System;
using System.Collections.Generic;

namespace Eventopia.Core.Data;

public partial class Role
{
    public decimal Roleid { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Login> Logins { get; set; } = new List<Login>();
}
