using Eventopia.Core.Data;
using Eventopia.Core.DTO;
using Eventopia.Core.Service;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Eventopia.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
	private readonly IAuthService _authService;
	private readonly IUserService _userService;
	public AuthController(IAuthService authService, IUserService userService)
	{
		_authService = authService;
		_userService = userService;
	}

	[HttpPost]
	[Route("Login")]
	public IActionResult Login([FromBody] LoginDTO loginDTO)
	{
		var token = _authService.Login(loginDTO);
		if (token == null)
		{
			return Unauthorized("Username or password are invalid");
		}
		else
		{
			return Ok(token);
		}
	}

	[HttpPost]
	[Route("Register")]
	public IActionResult Register([FromBody] RegisterDTO registerDTO)
	{
		bool usernameExists = _authService.CheckUsernameExists(registerDTO.Username);
		if(usernameExists)
		{
			return Conflict("username already exists");
		}

		bool emailExists = _authService.CheckEmailExists(registerDTO.Email);

		if(emailExists)
		{
			return Conflict("email already exists");
		}

		User user = new User
		{
			Username = registerDTO.Username,
			Email = registerDTO.Email,
			Password = registerDTO.Password,
			UserStatus = registerDTO.UserStatus,
			VerificationCode = "",
			RoleId = registerDTO.RoleId
		};

		_userService.CreateNew(user);

		return Ok();
	}

	[HttpPost]
	[Route("CheckUsernameExists")]
	public IActionResult CheckUsernameExists(
		[Required(ErrorMessage = "Username is required")]
		[StringLength(50, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 50 characters")]
		string username)
	{
		return Ok(_authService.CheckUsernameExists(username));
	}

	[HttpPost]
	[Route("CheckEmailExists")]
	public IActionResult CheckEmailExists(
		[Required(ErrorMessage = "Email is required")]
		[EmailAddress(ErrorMessage = "Invalid email address")]
		[StringLength(50, ErrorMessage = "Email must be at least 50 characters long")]
		string email)
	{
		return Ok(_authService.CheckEmailExists(email));
	}
}
