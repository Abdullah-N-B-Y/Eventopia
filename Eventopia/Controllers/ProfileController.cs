using Microsoft.AspNetCore.Mvc;
using Eventopia.Core.Data;
using Eventopia.Core.Service;

namespace Eventopia.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProfileController : ControllerBase
{
    private readonly IService<Profile> _profileService;

    public ProfileController(IService<Profile> profileService)
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
    public Profile GetProfileByID(int id)
    {
        return _profileService.GetById(id);
    }

    [HttpPost]
    [Route("CreateNewProfile")]
    public IActionResult CreateNewProfile([FromBody] Profile profile)
    {
		if (!ModelState.IsValid)
		{
			return BadRequest(ModelState);
		}
		_profileService.CreateNew(profile);
        return Ok();
    }

    [HttpPut]
    [Route("UpdateProfile")]
    public IActionResult UpdateProfile([FromBody] Profile profile)
    {
		if (!ModelState.IsValid)
		{
			return BadRequest(ModelState);
		}
		_profileService.Update(profile);
        return Ok();
    }

    [HttpDelete]
    [Route("DeleteProfile/{id}")]
    public void DeleteProfile(int id)
    {
        _profileService.Delete(id);
    }
}
