using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Eventopia.Core.Data;

public partial class ContactUsEntry
{
    public decimal Id { get; set; }

	[Required(ErrorMessage = "Subject is required.")]
	[MaxLength(100, ErrorMessage = "Subject cannot exceed 100 characters.")]
	public string? Subject { get; set; }

	[Required(ErrorMessage = "Content is required.")]
	[MaxLength(500, ErrorMessage = "Content cannot exceed 500 characters.")]
	public string? Content { get; set; }

	[Required(ErrorMessage = "Email is required.")]
	[MaxLength(100, ErrorMessage = "Email cannot exceed 100 characters.")]
	[EmailAddress(ErrorMessage = "Invalid email address.")]
	public string? Email { get; set; }

	[RegularExpression(@"^\d{10,15}$", ErrorMessage = "PhoneNumber must be a valid number with 10 to 15 digits.")]
	public decimal? Phonenumber { get; set; }

	[Required(ErrorMessage = "AdminId is required.")]
	[Range(1, int.MaxValue, ErrorMessage = "AdminId must be a positive number.")]
	public decimal? Adminid { get; set; }

    public virtual User? Admin { get; set; }
}
