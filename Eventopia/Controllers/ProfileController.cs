using Microsoft.AspNetCore.Mvc;
using Eventopia.Core.Data;
using Eventopia.Core.Service;
using System.ComponentModel.DataAnnotations;

namespace Eventopia.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProfileController : ControllerBase
{
    private readonly IProfileService _profileService;

    public ProfileController(IProfileService profileService)
    {
        _profileService = profileService;
    }

    [HttpGet]
    [Route("GetAllProfiles")]
    public List<Profile> GetAllProfiles()
    {
        return _profileService.GetAll();
    }

    [HttpGet]
    [Route("GetProfileByID/{id}")]
    public IActionResult GetProfileByID(
		[Required(ErrorMessage = "ProfileId is required.")]
		[Range(1, int.MaxValue, ErrorMessage = "ProfileId must be a positive number.")]
		int id)
    {
        Profile profile = _profileService.GetById(id);
        if(profile == null)
            return NotFound();
		return Ok(profile);
    }

	[HttpGet]
	[Route("GetProfileByPhoneNumber/{phoneNumber}")]
	public IActionResult GetProfileByPhoneNumber(
		[Required(ErrorMessage = "PhoneNumber is required.")]
		[RegularExpression(@"^\+?[0-9]{10,12}$", ErrorMessage = "Invalid phone number. It should contain 10 to 12 digits and may start with a '+' symbol.")]
		string phoneNumber)
	{
		Profile profile = _profileService.GetProfileByPhoneNumber(phoneNumber);
		if (profile == null)
			return NotFound();
		return Ok(profile);
	}

    [HttpPost]
    [Route("CreateNewProfile")]
    public IActionResult CreateNewProfile([FromBody] Profile profile)
    {
		_profileService.CreateNew(profile);
        return Ok();
    }

    [HttpPut]
    [Route("UpdateProfile")]
    public IActionResult UpdateProfile([FromBody] Profile profile)
    {
		_profileService.Update(profile);
        return Ok();
    }

    [HttpDelete]
    [Route("DeleteProfile/{id}")]
    public IActionResult DeleteProfile(
		[Required(ErrorMessage = "ProfileId is required.")]
		[Range(1, int.MaxValue, ErrorMessage = "ProfileId must be a positive number.")]
		int id)
    {
        if(!_profileService.Delete(id))
            return NotFound();
        return Ok();
    }
}
