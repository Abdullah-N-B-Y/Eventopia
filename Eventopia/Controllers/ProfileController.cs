using Microsoft.AspNetCore.Mvc;
using Eventopia.Core.Data;
using Eventopia.Core.Service;
using System.ComponentModel.DataAnnotations;
using Eventopia.Infra.Utility;
using Microsoft.Extensions.Logging;
using Eventopia.Infra.Service;

namespace Eventopia.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProfileController : ControllerBase
{
    private readonly IProfileService _profileService;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public ProfileController(IProfileService profileService, IWebHostEnvironment webHostEnvironment)
    {
        _profileService = profileService;
        _webHostEnvironment = webHostEnvironment;
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
    [Route("GetProfileByUserId/{id}")]
    public Profile GetProfileByUserId(
        [Required(ErrorMessage = "Id is required.")]
        int id)
    {
        return _profileService.GetProfileByUserId(id);
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
    [Route("CreateProfile")]
    public IActionResult CreateProfile([FromForm] Profile profile)
    {
		Profile p = _profileService.GetProfileByPhoneNumber(profile.PhoneNumber);
		if (p != null)
			return Conflict("PhoneNumber Already Exists");

		if (profile.ReceivedImageFile != null)
		{
			if (!ImageUtility.IsImageContentType(profile.ReceivedImageFile.ContentType))
				return BadRequest("Invalid file type. Only images are allowed.");

			profile.ImagePath = ImageUtility.StoreImage(profile.ReceivedImageFile, "Profile");
		}
		
        return Ok(_profileService.CreateNew(profile));
    }

    [HttpPut]
    [Route("UpdateProfile")]
    public IActionResult UpdateProfile([FromForm] Profile profile)
    {
        Profile p = _profileService.GetProfileByPhoneNumber(profile.PhoneNumber);
        if (p != null && p.Id != profile.Id)
            return Conflict("PhoneNumber Already Exists");

        if (profile.ReceivedImageFile != null)
        {
            if (!ImageUtility.IsImageContentType(profile.ReceivedImageFile.ContentType))
                return BadRequest("Invalid file type. Only images are allowed.");

            profile.ImagePath = ImageUtility.ReplaceImage(profile.ImagePath, profile.ReceivedImageFile, "Profile");
        }

        if (!_profileService.Update(profile))
            return BadRequest();
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

    private string localPath = @"D:\Thaluf\Files\Final project\Images\UsersImages";
    [HttpPost]
    [Route("UploadImage/{userId}")]
    public IActionResult UploadImage(IFormFile file, int userId)
    {
        if (file.Length > 0)
        {
            if (string.IsNullOrEmpty(localPath))
            {
                return BadRequest(new { Message = "Invalid localPath." });
            }

            string fileName = Path.GetFileName(file.FileName);
            string fullPath = Path.Combine(localPath, fileName);

            using (Stream fileStream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            _profileService.UpdateUserProfileImage(userId, fullPath);


            return Ok(new { Message = "Image path updated successfully." });
        }

        return BadRequest(new { Message = "Image file is empty" });
    }

    [HttpGet]
    [Route("GetProfileImage/{userId}")]
    public IActionResult GetProfileImage(int userId) 
    {
        Profile profile = _profileService.GetById(userId);
        string imagePath = profile.ImagePath;

        if (!string.IsNullOrEmpty(imagePath))
        {
            if (System.IO.File.Exists(imagePath))
            {
                return PhysicalFile(imagePath, "application/octet-stream", Path.GetFileName(imagePath));
            }
            else
            {
                return NotFound();
            }
        }
        return BadRequest();
    }
}
