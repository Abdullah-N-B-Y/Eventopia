using Eventopia.Core.Data;
using Eventopia.Core.DTO;
using Eventopia.Core.Service;
using Microsoft.AspNetCore.Mvc;

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
		if (!ModelState.IsValid)
		{
			return BadRequest(ModelState);
		}
		_userService.CreateNew(user);
		return Ok();
	}

	[HttpDelete]
	[Route("DeleteUser/{id}")]
	public void DeleteUser(int id)
	{
		_userService.Delete(id);
	}
	
	[HttpGet]
	[Route("GetAllUsers")]
	public List<User> GetAllUsers()
	{
		return _userService.GetAll();
	}

	[HttpGet]
	[Route("GetUserById/{id}")]
	public User GetUserById(int id)
	{
		return _userService.GetById(id);
	}

	[HttpGet]
	[Route("GetUserByUserName")]
	public User GetUserByUserName(string username)
	{
		return _userService.GetUserByUserName(username);
	}

	[HttpPut]
	[Route("UpdateUser")]
	public IActionResult UpdateUser([FromBody] User user)
	{
		if (!ModelState.IsValid)
		{
			return BadRequest(ModelState);
		}
		_userService.Update(user);
		return Ok();
	}

    [HttpPut]
    [Route("UpdateUserProfile/{password}")]
    public IActionResult UpdateUserProfile([FromBody] Profile profile, string password)
    {
		if (!ModelState.IsValid)
		{
			return BadRequest(ModelState);
		}
		_userService.UpdateUserProfile(profile, password);
		return Ok();
    }

    [HttpPut]
    [Route("UpdatePassword/{id}")]
    public IActionResult UpdatePassword(int id, [FromBody] UpdatePasswordDTO updatePasswordDTO)
    {
		if (!ModelState.IsValid)
		{
			return BadRequest(ModelState);
		}
		_userService.UpdatePassword(id, updatePasswordDTO);
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
	public User GetUserByEmail(string email)
	{
		return _userService.GetUserByEmail(email);
	}

	[HttpPost]
	[Route("ForgotPassword")]
	public bool ForgotPassword(string email)
	{
		return _userService.ForgotPassword(email);
	}

	[HttpPost]
	[Route("CheckPasswordResetToken")]
	public bool CheckPasswordResetToken(string email, string token)
	{
		return _userService.CheckPasswordResetToken(email, token);
	}

	[HttpPost]
	[Route("ResetForgottenPassword")]
	public bool ResetForgottenPassword(string email, string resetToken, string newPassword)
	{
		return _userService.ResetForgottenPassword(email, newPassword);
	}
}
