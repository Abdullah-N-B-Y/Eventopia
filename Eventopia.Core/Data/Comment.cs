using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Eventopia.Core.Data;

public partial class Comment
{
    public decimal Id { get; set; }

	[Required(ErrorMessage = "Content is required.")]
	[MaxLength(500, ErrorMessage = "Content cannot exceed 500 characters.")]
	public string? Content { get; set; }

	[Required(ErrorMessage = "EventId is required.")]
	[Range(1, int.MaxValue, ErrorMessage = "EventId must be a positive number.")]
	public decimal? Eventid { get; set; }

	[Required(ErrorMessage = "UserId is required.")]
	[Range(1, int.MaxValue, ErrorMessage = "UserId must be a positive number.")]
	public decimal? Userid { get; set; }

	public virtual Event? Event { get; set; }

	public virtual User? User { get; set; }
}
