using Eventopia.Core.Service;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Eventopia.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProfileSettingController : ControllerBase
{
    private readonly IProfileSettingService _profileSettingService;

    public ProfileSettingController(IProfileSettingService profileSettingService)
    {
        _profileSettingService = profileSettingService;
    }

    [HttpPut]
    [Route("SetTheme/{userId}")]
    public IActionResult SetTheme(
		[Required(ErrorMessage = "UserId is required.")]
		[Range(1, int.MaxValue, ErrorMessage = "UserId must be a positive number.")]
		int userId,
		[MaxLength(50, ErrorMessage = "Theme cannot exceed 50 characters.")]
		string theme)
    {
		_profileSettingService.SetTheme(userId, theme);
        return Ok();
    }

    [HttpGet]
	[Route("GetTheme/{userId}")]
	public IActionResult GetTheme(
		[Required(ErrorMessage = "UserId is required.")]
		[Range(1, int.MaxValue, ErrorMessage = "UserId must be a positive number.")]
		int userId) 
    {
		return Ok(_profileSettingService.GetTheme(userId));
    }
}
