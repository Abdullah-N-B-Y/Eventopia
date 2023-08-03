using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Eventopia.Core.Data;

public partial class Notification
{
    public decimal Id { get; set; }

	[Required(ErrorMessage = "Content is required.")]
	[MaxLength(500, ErrorMessage = "Content cannot exceed 500 characters.")]
	public string? Content { get; set; }

    public DateTime? Receiveddate { get; set; }

	[Required(ErrorMessage = "ReceiverId is required.")]
	[Range(1, int.MaxValue, ErrorMessage = "ReceiverId must be a positive number.")]
	public decimal? Receiverid { get; set; }

    public virtual User? Receiver { get; set; }
}
