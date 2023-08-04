using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Eventopia.Core.Data;

public partial class Page
{
    public decimal Id { get; set; }

	[MaxLength(500, ErrorMessage = "Content1 cannot exceed 500 characters.")]
	public string? Content1 { get; set; }

	[MaxLength(500, ErrorMessage = "Content2 cannot exceed 500 characters.")]
	public string? Content2 { get; set; }

	[MaxLength(100, ErrorMessage = "BackgroundImagePath cannot exceed 100 characters.")]
	public string? BackgroundImagePath { get; set; }

	[Required(ErrorMessage = "AdminId is required.")]
	[Range(1, int.MaxValue, ErrorMessage = "AdminId must be a positive number.")]
	public decimal? AdminId { get; set; }

    public virtual User? Admin { get; set; }
}
