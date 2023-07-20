using Eventopia.Core.Data;
using Eventopia.Core.Service;
using Eventopia.Infra.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eventopia.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class JWTController : ControllerBase
	{
		private readonly IJWTService _jwtService;
		public JWTController(IJWTService jwtservice)
		{
			_jwtService = jwtservice;
		}

		[HttpPost]
		[Route("Login")]
		public IActionResult Login([FromBody] User user)
		{
			var token = _jwtService.Login(user.Username, user.Password);
			if (token == null)
			{
				return Unauthorized();
			}
			else
			{
				return Ok(token);
			}
		}

	}
}
