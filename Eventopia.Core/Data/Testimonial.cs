using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Eventopia.Core.Data;

public partial class Testimonial
{
    public decimal Id { get; set; }

	[Required(ErrorMessage = "Content is required.")]
	[MaxLength(500, ErrorMessage = "Content cannot exceed 500 characters.")]
	public string? Content { get; set; }

    public DateTime? Creationdate { get; set; }

	[Required(ErrorMessage = "Status is required.")]
	[MaxLength(20, ErrorMessage = "Status cannot exceed 20 characters.")]
	public string? Status { get; set; }

	[Required(ErrorMessage = "UserId is required.")]
	[Range(1, int.MaxValue, ErrorMessage = "UserId must be a positive number.")]
	public decimal? Userid { get; set; }

    public virtual User? User { get; set; }
}
