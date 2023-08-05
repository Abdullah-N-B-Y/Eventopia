﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Eventopia.Core.Data;

public partial class Category
{
    public decimal Id { get; set; }

	[Required(ErrorMessage = "Name is required.")]
	[MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters.")]
	public string? Name { get; set; }

	[MaxLength(100, ErrorMessage = "ImagePath cannot exceed 100 characters.")]
	public string? ImagePath { get; set; }

	[MaxLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
	public string? Description { get; set; }

    public DateTime? CreationDate { get; set; }

	[Required(ErrorMessage = "AdminId is required.")]
	[Range(1, int.MaxValue, ErrorMessage = "AdminId must be a positive number.")]
	public decimal? AdminId { get; set; }

    public virtual User? Admin { get; set; }

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}
