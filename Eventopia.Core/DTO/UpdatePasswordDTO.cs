
using System.ComponentModel.DataAnnotations;

namespace Eventopia.Core.DTO;

public class UpdatePasswordDTO
{
	[Required(ErrorMessage = "old password is required")]
	[StringLength(50, MinimumLength = 8, ErrorMessage = "Old password must be at least 8 characters and less than 50")]
	[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z0-9]).{8,}$",
			ErrorMessage = "Old password must contain at least one lowercase letter, one uppercase letter, one digit, and one special character")]
	public string? OldPassword { set; get; }

	[Required(ErrorMessage = "New password is required")]
	[StringLength(50, MinimumLength = 8, ErrorMessage = "New password must be at least 8 characters and less than 50")]
	[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z0-9]).{8,}$",
			ErrorMessage = "New password must contain at least one lowercase letter, one uppercase letter, one digit, and one special character")]
	public string? NewPassword { set; get; }

	[Required(ErrorMessage = "Password is required")]
	public string? ConfirmPassword { set; get; }
}

