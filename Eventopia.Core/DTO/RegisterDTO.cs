﻿using System.ComponentModel.DataAnnotations;

namespace Eventopia.Core.DTO;

public class RegisterDTO
{
	[Required(ErrorMessage = "Username is required")]
	[StringLength(50, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 50 characters")]
	public string? Username { get; set; }

	[StringLength(50, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters and less than 50")]
	[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z0-9]).{8,}$",
		ErrorMessage = "Password must contain at least one lowercase letter, one uppercase letter, one digit, and one special character")]
	[Required(ErrorMessage = "Password is required")]
	public string? Password { get; set; }

	[Required(ErrorMessage = "Email is required")]
	[EmailAddress(ErrorMessage = "Invalid email address")]
	[StringLength(50, ErrorMessage = "Email must be less than 50 characters long")]
	public string? Email { get; set; }

	public RegisterDTO(string? username, string? password, string? email)
	{
		Username = username;
		Password = password;
		Email = email;
	}
}
