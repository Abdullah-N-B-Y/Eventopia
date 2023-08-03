using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Eventopia.Core.Data;

public partial class Profilesetting
{
    public decimal Id { get; set; }

	[MaxLength(50, ErrorMessage = "Language cannot exceed 50 characters.")]
	public string? Language { get; set; }

	[MaxLength(50, ErrorMessage = "Theme cannot exceed 50 characters.")]
	public string? Theme { get; set; }

	[Required(ErrorMessage = "Profileid is required.")]
	[Range(1, int.MaxValue, ErrorMessage = "ProfileId must be a positive number.")]
	public decimal? Profileid { get; set; }

    public virtual Profile? Profile { get; set; }
}
