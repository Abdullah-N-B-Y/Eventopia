using Eventopia.Core.Data;
using Eventopia.Core.DTO;
using Eventopia.Core.Service;
using Microsoft.AspNetCore.Mvc;

namespace Eventopia.API.Controllers
{
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
		public void CreateNewUser(User user)
		{
			_userService.CreateNew(user);
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
		public void UpdateUser(User user)
		{
			_userService.Update(user);
		}

        [HttpPut]
        [Route("UpdateUserProfile/{password}")]
        public void UpdateUserProfile(Profile profile, string password)
        {
            _userService.UpdateUserProfile(profile, password);
        }

        [HttpPut]
        [Route("UpdatePassword/{id}")]
        public void UpdatePassword(int id, UpdatePasswordDTO updatePasswordDTO)
        {
            _userService.UpdatePassword(id, updatePasswordDTO);
        }
    }
}
