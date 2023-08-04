using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Eventopia.Core.Data;

public partial class Message
{
    public decimal Id { get; set; }

	[Required(ErrorMessage = "Content is required.")]
	[MaxLength(500, ErrorMessage = "Content cannot exceed 500 characters.")]
	public string? Content { get; set; }

    public DateTime? MessageDate { get; set; }

    public decimal? IsRead { get; set; }

    public decimal? IsDeleted { get; set; }

	[Required(ErrorMessage = "SenderId is required.")]
	[Range(1, int.MaxValue, ErrorMessage = "SenderId must be a positive number.")]
	public decimal? SenderId { get; set; }

	[Required(ErrorMessage = "ReceiverId is required.")]
	[Range(1, int.MaxValue, ErrorMessage = "ReceiverId must be a positive number.")]
	public decimal? ReceiverId { get; set; }

    public virtual User? Receiver { get; set; }

    public virtual User? Sender { get; set; }
}
