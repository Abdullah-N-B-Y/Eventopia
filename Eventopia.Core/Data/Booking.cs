using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Eventopia.Core.Data;

public partial class Booking
{
    public decimal Id { get; set; }

    public DateTime? Bookingdate { get; set; }

	[Required(ErrorMessage = "UserId is required.")]
	[Range(1, int.MaxValue, ErrorMessage = "UserId must be a positive number.")]
	public decimal? Userid { get; set; }

	[Required(ErrorMessage = "EventId is required.")]
	[Range(1, int.MaxValue, ErrorMessage = "EventId must be a positive number.")]
	public decimal? Eventid { get; set; }

    public virtual Event? Event { get; set; }

    public virtual User? User { get; set; }
}
