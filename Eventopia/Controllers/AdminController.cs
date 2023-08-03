using Eventopia.Core.DTO;
using Eventopia.Core.Service;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Eventopia.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AdminController : ControllerBase
{
    private readonly IAdminService _adminService;

    public AdminController(IAdminService adminService)
    {
        _adminService = adminService;
    }

    [HttpPut]
    [Route("EventAcceptation/{id}/{status}")]
    public IActionResult EventAcceptation(
		[Required(ErrorMessage = "EventId is required.")]
	    [Range(1, int.MaxValue, ErrorMessage = "EventId must be a positive number.")]
        int id
        , string status)
    {
		return Ok(_adminService.EventAcceptation(id, status));
    }

    [HttpPut]
    [Route("BannedUser/{id}")]
    public IActionResult BannedUser(
		[Required(ErrorMessage = "UserId is required.")]
	    [Range(1, int.MaxValue, ErrorMessage = "userId must be a positive number.")]
		int id)
    {
		_adminService.BannedUser(id);
        return Ok();
    }

    [HttpPut]
    [Route("UnbannedUser/{id}")]
    public IActionResult UnbannedUser(
        [Required(ErrorMessage = "UserId is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "UserId must be a positive number.")] 
        int id)
    {
        return Ok(_adminService.UnbannedUser(id));
    }

    [HttpGet]
    [Route("Statistics")]
    public IActionResult GetStatistics()
    {
        return Ok(_adminService.GetStatistics());
    }

    [HttpPost]
    [Route("BenefitsReport")]
    public IActionResult GetBenefitsReport([FromBody] SearchBetweenDatesDTO searchDTO)
    {
		return Ok(_adminService.GetBenefitsReport(searchDTO));
    }
}
