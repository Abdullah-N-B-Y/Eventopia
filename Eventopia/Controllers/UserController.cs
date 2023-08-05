using Eventopia.Core.Data;
using Eventopia.Core.DTO;
using Eventopia.Core.Service;
using Eventopia.Infra.Repository;
using Eventopia.Infra.Service;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Eventopia.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
	private readonly IUserService _userService;

	public UserController(IUserService userService)
	{
		_userService = userService;
	}

	[HttpPost]
	[Route("CreateNewUser")]
	public IActionResult CreateNewUser([FromBody] User user)
	{
		User userByUsername = _userService.GetUserByUserName(user.Username);
		if (userByUsername != null)
			return Conflict("username already exists");

		User userByEmail = _userService.GetUserByUserName(user.Email);
		if (userByEmail != null)
			return Conflict("email already exists");

		_userService.CreateNew(user);
		return Ok();
	}

	[HttpDelete]
	[Route("DeleteUser/{id}")]
	public IActionResult DeleteUser(
		[Required(ErrorMessage = "UserId is required.")]
		[Range(1, int.MaxValue, ErrorMessage = "UserId must be a positive number.")]
		int id)
	{
		if(!_userService.Delete(id))
			return NotFound();

		return Ok();
	}
	
	[HttpGet]
	[Route("GetAllUsers")]
	public List<User> GetAllUsers()
	{
		return _userService.GetAll();
	}

	[HttpGet]
	[Route("GetUserById/{id}")]
	public IActionResult GetUserById(
		[Required(ErrorMessage = "UserId is required.")]
		[Range(1, int.MaxValue, ErrorMessage = "UserId must be a positive number.")]
		int id)
	{
		User user = _userService.GetById(id);
		if(user == null)
			return NotFound();
		return Ok(user);
	}

	[HttpGet]
	[Route("GetUserByUserName/{username}")]
	public IActionResult GetUserByUserName(
		[Required(ErrorMessage = "Username is required")]
		[StringLength(50, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 50 characters")]
		string username)
	{
		User user = _userService.GetUserByUserName(username);
		if (user == null)
			return NotFound();
		return Ok(user);
	}

	[HttpPut]
	[Route("UpdateUser")]
	public IActionResult UpdateUser([FromBody] User user)
	{
		User userByUsername = _userService.GetUserByUserName(user.Username);
		if (userByUsername != null && userByUsername.Id != user.Id)
			return Conflict("username already exists");

		User userByEmail = _userService.GetUserByUserName(user.Email);
		if (userByEmail != null && userByEmail.Id != user.Id)
			return Conflict("email already exists");

		if (!_userService.Update(user))
			return NotFound();
		return Ok();
	}

  //  [HttpPut]
  //  [Route("UpdateUserProfile/{password}")]
  //  public IActionResult UpdateUserProfile([FromBody] Profile profile,
		//[StringLength(50, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters and less than 50")]
		//[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z0-9]).{8,}$",
		//	ErrorMessage = "Password must contain at least one lowercase letter, one uppercase letter, one digit, and one special character")]
		//[Required(ErrorMessage = "Password is required")]
		//string password)
  //  {
		//if (!_userService.UpdateUserProfile(profile, password))
		//	return NotFound();

		//return Ok();
  //  }

    [HttpPut]
    [Route("UpdatePassword/{id}")]
    public IActionResult UpdatePassword([FromBody] UpdatePasswordDTO updatePasswordDTO,
		[Required(ErrorMessage = "UserId is required.")]
		[Range(1, int.MaxValue, ErrorMessage = "UserId must be a positive number.")]
		int id)
    {
		if (!_userService.UpdatePassword(id, updatePasswordDTO))
			return NotFound();
		;
		return Ok();
    }

    [HttpGet]
    [Route("GetAllRegisteredUsersDetails")]
    public List<RegisteredUsersDetailsDTO> GetAllRegisteredUsersDetails()
    {
        return _userService.GetAllRegisteredUsersDetails();
    }

	[HttpGet]
	[Route("GetUserByEmail/{email}")]
	public IActionResult GetUserByEmail(
		[Required(ErrorMessage = "Email is required")]
		[EmailAddress(ErrorMessage = "Invalid email address")]
		[StringLength(50, ErrorMessage = "Email must be at least 50 characters long")]
		string email)
	{
		User user = _userService.GetUserByEmail(email);
		if (user == null)
			return NotFound();
		return Ok(user);
	}

	[HttpPost]
	[Route("ForgotPassword")]
	public IActionResult ForgotPassword(
		[Required(ErrorMessage = "Email is required")]
		[EmailAddress(ErrorMessage = "Invalid email address")]
		[StringLength(50, ErrorMessage = "Email must be at least 50 characters long")]
		string email)
	{
		bool success = _userService.ForgotPassword(email);
		if (!success)
			return NotFound("Email not found");
		return Ok();
	}

	[HttpPost]
	[Route("CheckPasswordResetToken")]
	public IActionResult CheckPasswordResetToken(
		[Required(ErrorMessage = "Email is required")]
		[EmailAddress(ErrorMessage = "Invalid email address")]
		[StringLength(50, ErrorMessage = "Email must be at least 50 characters long")]
		string email, string token)
	{
		bool success = _userService.CheckPasswordResetToken(email, token);
		if (!success)
			return NotFound("Email or token not found");
		return Ok();
	}

	[HttpPost]
	[Route("ResetForgottenPassword")]
	public IActionResult ResetForgottenPassword(
		[Required(ErrorMessage = "Email is required")]
		[EmailAddress(ErrorMessage = "Invalid email address")]
		[StringLength(50, ErrorMessage = "Email must be at least 50 characters long")]
		string email,
		[StringLength(50, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters and less than 50")]
		[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z0-9]).{8,}$",
			ErrorMessage = "Password must contain at least one lowercase letter, one uppercase letter, one digit, and one special character")]
		[Required(ErrorMessage = "Password is required")]
		string newPassword)
	{
		bool success = _userService.ResetForgottenPassword(email, newPassword);
		if (!success)
			return NotFound("Email not found");
		return Ok();
	}
}
