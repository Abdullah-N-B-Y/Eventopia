using System;
using System.Collections.Generic;

namespace Eventopia.Core.Data;

public partial class Role
{
    public decimal Id { get; set; }

    public string? Rolename { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
