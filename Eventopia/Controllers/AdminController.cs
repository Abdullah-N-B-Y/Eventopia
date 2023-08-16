using Eventopia.Core.DTO;
using Eventopia.Core.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Eventopia.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Policy = "AdminOnly")]
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
        if(!_adminService.EventAcceptation(id, status))
            return NotFound("EventId not found");
		return Ok();
    }

    [HttpPut]
    [Route("BannedUser/{username}")]
    public IActionResult BannedUser(
		[Required(ErrorMessage = "Username is required.")]
        string username)
    {
        if(!_adminService.BannedUser(username))
		    return NotFound();
        return Ok();
    }

    [HttpPut]
    [Route("UnbannedUser/{username}")]
    public IActionResult UnbannedUser(
        [Required(ErrorMessage = "Username is required.")]
        string username)
    {
        if(!_adminService.UnbannedUser(username))
            return NotFound();
        return Ok();
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
