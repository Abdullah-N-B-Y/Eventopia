using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Eventopia.Core.Data;

public partial class Role
{
    public decimal Id { get; set; }

	[Required(ErrorMessage = "RoleName is required.")]
	[MaxLength(50, ErrorMessage = "RoleName cannot exceed 50 characters.")]
	public string? Rolename { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
