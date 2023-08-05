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
        if(!_adminService.EventAcceptation(id, status))
            return NotFound("EventId not found");
		return Ok();
    }

    [HttpPut]
    [Route("BannedUser/{id}")]
    public IActionResult BannedUser(
		[Required(ErrorMessage = "UserId is required.")]
	    [Range(1, int.MaxValue, ErrorMessage = "userId must be a positive number.")]
		int id)
    {
        if(!_adminService.BannedUser(id))
		    return NotFound();
        return Ok();
    }

    [HttpPut]
    [Route("UnbannedUser/{id}")]
    public IActionResult UnbannedUser(
        [Required(ErrorMessage = "UserId is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "UserId must be a positive number.")] 
        int id)
    {
        if(!_adminService.UnbannedUser(id))
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
