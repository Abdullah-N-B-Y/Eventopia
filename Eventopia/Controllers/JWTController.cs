using Eventopia.Core.Data;
using Eventopia.Core.DTO;
using Eventopia.Core.Service;
using Microsoft.AspNetCore.Mvc;

namespace Eventopia.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class JWTController : ControllerBase
	{
		private readonly IJWTService _jwtService;
		private readonly IUserService _userService;
		public JWTController(IJWTService jwtservice, IUserService userService)
		{
			_jwtService = jwtservice;
			_userService = userService;
		}

		[HttpPost]
		[Route("Login")]
		public IActionResult Login([FromBody] LoginDTO loginDTO)
		{
			var token = _jwtService.Login(loginDTO);
			if (token == null)
			{
				return Unauthorized();
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
			bool usernameExists = _jwtService.CheckUsernameExists(registerDTO.Username);
			if(usernameExists)
			{
				return BadRequest("username already exists");
			}

			bool emailExists = _jwtService.CheckEmailExists(registerDTO.Email);

			if(emailExists)
			{
				return BadRequest("email already exists");
			}

			User user = new User();
			user.Username = registerDTO.Username;
			user.Email = registerDTO.Email;
			user.Password = registerDTO.Password;
			user.Userstatus = registerDTO.UserStatus;
			user.Verfiicationcode = registerDTO.VerificationCode;
			user.Roleid = registerDTO.RoleId;

			_userService.CreateNew(user);

			return Ok();
		}

		[HttpPost]
		[Route("CheckUsernameExists")]
		public bool CheckUsernameExists([FromBody] string username)
		{
			return _jwtService.CheckUsernameExists(username);
		}

		[HttpPost]
		[Route("CheckEmailExists")]
		public bool CheckEmailExists([FromBody] string email)
		{
			return _jwtService.CheckEmailExists(email);
		}
	}
}
