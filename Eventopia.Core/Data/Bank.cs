using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Eventopia.Core.Data;

public partial class Bank
{
    public decimal Id { get; set; }

	[Required(ErrorMessage = "CardNumber is required.")]
	[MaxLength(20, ErrorMessage = "CardNumber cannot exceed 20 characters.")]
	[RegularExpression("^[0-9]*$", ErrorMessage = "Only numbers are allowed.")]
	public string? CardNumber { get; set; }

	[Required(ErrorMessage = "CardHolder is required.")]
	[MaxLength(100, ErrorMessage = "CardHolder cannot exceed 100 characters.")]
	public string? CardHolder { get; set; }

	[Required(ErrorMessage = "ExpirationDate is required.")]
	public DateTime? ExpirationDate { get; set; }

	[Required(ErrorMessage = "CVV is required.")]
	[StringLength(3, MinimumLength = 3, ErrorMessage = "CVV cannot exceed 3 characters.")]
	public string? CVV { get; set; }

    public decimal? Balance { get; set; }
}
