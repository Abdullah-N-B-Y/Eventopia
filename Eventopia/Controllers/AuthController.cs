using Eventopia.Core.Data;
using Eventopia.Core.DTO;
using Eventopia.Core.Service;
using Eventopia.Infra.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eventopia.API.Controllers
{
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
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

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
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

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
				Userstatus = registerDTO.UserStatus,
				Verfiicationcode = registerDTO.VerificationCode,
				Roleid = registerDTO.RoleId
			};

			_userService.CreateNew(user);

			return Ok();
		}

		[HttpPost]
		[Route("CheckUsernameExists")]
		public bool CheckUsernameExists([FromBody] string username)
		{
			return _authService.CheckUsernameExists(username);
		}

		[HttpPost]
		[Route("CheckEmailExists")]
		public bool CheckEmailExists([FromBody] string email)
		{
			return _authService.CheckEmailExists(email);
		}
	}
}
