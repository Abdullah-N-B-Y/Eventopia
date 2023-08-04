using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Eventopia.Core.Data;

public partial class Profile
{
    public decimal Id { get; set; }

	[Required(ErrorMessage = "FirstName is required.")]
	[MaxLength(50, ErrorMessage = "FirstName cannot exceed 50 characters.")]
	public string? FirstName { get; set; }

	[Required(ErrorMessage = "LastName is required.")]
	[MaxLength(50, ErrorMessage = "LastName cannot exceed 50 characters.")]
	public string? LastName { get; set; }

	[MaxLength(100, ErrorMessage = "ImagePath cannot exceed 100 characters.")]
	public string? ImagePath { get; set; }

	[RegularExpression(@"^\d{10,15}$", ErrorMessage = "PhoneNumber must be a valid number with 10 to 15 digits.")]
	public decimal? PhoneNumber { get; set; }

	[MaxLength(10, ErrorMessage = "Gender cannot exceed 10 characters.")]
	public string? Gender { get; set; }

    public DateTime? DateOfBirth { get; set; }

	[MaxLength(500, ErrorMessage = "Bio cannot exceed 500 characters.")]
	public string? Bio { get; set; }

	[Range(0, 5, ErrorMessage = "Rate must be between 0 and 5.")]
	public decimal? Rate { get; set; }

	[Required(ErrorMessage = "Userid is required.")]
	[Range(1, int.MaxValue, ErrorMessage = "Userid must be a positive number.")]
	public decimal? UserId { get; set; }

    public virtual ICollection<Profilesetting> Profilesettings { get; set; } = new List<Profilesetting>();

    public virtual User? User { get; set; }
}
