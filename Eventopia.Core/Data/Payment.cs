using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Eventopia.Core.Data;

public partial class Payment
{
    public decimal? Id { get; set; }

	[Required(ErrorMessage = "PaymentDate is required.")]
	public DateTime? PaymentDate { get; set; }

	[Required(ErrorMessage = "Amount is required.")]
	[Range(0, double.MaxValue, ErrorMessage = "Amount must be a non-negative number.")]
	public decimal? Amount { get; set; }

	[Required(ErrorMessage = "Method is required.")]
	[MaxLength(50, ErrorMessage = "Method cannot exceed 50 characters.")]
	public string? Method { get; set; }

	[Required(ErrorMessage = "Status is required.")]
	[MaxLength(20, ErrorMessage = "Status cannot exceed 20 characters.")]
	public string? Status { get; set; }

	[Required(ErrorMessage = "PaymentDate is required.")]
	[Range(1, int.MaxValue, ErrorMessage = "UserId must be a positive number.")]
	public decimal? UserId { get; set; }

    public virtual User? User { get; set; }
}
