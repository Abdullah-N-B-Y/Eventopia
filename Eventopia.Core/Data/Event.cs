using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Eventopia.Core.Data;

public partial class Event
{
    public decimal Id { get; set; }

	[Required(ErrorMessage = "Name is required.")]
	[MaxLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
	public string? Name { get; set; }

	[Required(ErrorMessage = "AttendingCost is required.")]
	[Range(0, double.MaxValue, ErrorMessage = "AttendingCost must be a non-negative number.")]
	public decimal? AttendingCost { get; set; }

	[Required(ErrorMessage = "StartDate is required.")]
	public DateTime? StartDate { get; set; }

	[Required(ErrorMessage = "EndDate is required.")]
	public DateTime? EndDate { get; set; }

	[Required(ErrorMessage = "Status is required.")]
	[MaxLength(20, ErrorMessage = "Status cannot exceed 20 characters.")]
	public string? Status { get; set; }

	[Required(ErrorMessage = "EventDescription is required.")]
	[MaxLength(500, ErrorMessage = "EventDescription cannot exceed 500 characters.")]
	public string? EventDescription { get; set; }

	[MaxLength(100, ErrorMessage = "ImagePath cannot exceed 100 characters.")]
	public string? ImagePath { get; set; }

	[Required(ErrorMessage = "EventCapacity is required.")]
	[Range(0, int.MaxValue, ErrorMessage = "EventCapacity must be a non-negative number.")]
	public decimal? EventCapacity { get; set; }

	[Required(ErrorMessage = "Latitude is required.")]
	public decimal? Latitude { get; set; }

	[Required(ErrorMessage = "Longitude is required.")]
	public decimal? Longitude { get; set; }

	[Required(ErrorMessage = "EventCreatorId is required.")]
	[Range(1, int.MaxValue, ErrorMessage = "EventCreatorId must be a positive number.")]
	public decimal? EventCreatorId { get; set; }

	[Required(ErrorMessage = "CategoryId is required.")]
	[Range(1, int.MaxValue, ErrorMessage = "CategoryId must be a positive number.")]
	public decimal? CategoryId { get; set; }

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual Category? Category { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual User? Eventcreator { get; set; }
}
