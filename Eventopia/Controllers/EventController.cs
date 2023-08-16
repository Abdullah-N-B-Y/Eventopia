using Eventopia.Core.Data;
using Eventopia.Core.DTO;
using Eventopia.Core.Service;
using Eventopia.Infra.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Eventopia.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Policy = "AdminAndUserOnly")]
public class EventController : ControllerBase
{
    private readonly IEventService _eventService; 

    public EventController(IEventService eventService) 
    {
        _eventService = eventService;
    }

    [HttpPost]
    [Route("SearchEventsBetweenDates")]
    public IActionResult SearchEventsBetweenDates([FromBody] SearchBetweenDatesDTO searchDTO)
    {
        return Ok(_eventService.GetEventsBetweenDates(searchDTO));
    }


    [HttpPost]
    [Route("SearchEventsByName")]
    public IActionResult SearchEventsByName(
		[Required(ErrorMessage = "Name is required.")]
	    [MaxLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
		string eventName)
    {
        return Ok(_eventService.SearchEventsByName(eventName));
    }

    [HttpPost]
    [Route("CreateNewEvent")]
    public IActionResult CreateNewEvent([FromForm] Event eventt)
    {
		if (eventt.ReceivedImageFile != null)
		{
			if (!ImageUtility.IsImageContentType(eventt.ReceivedImageFile.ContentType))
				return BadRequest("Invalid file type. Only images are allowed.");

			eventt.ImagePath = ImageUtility.StoreImage(eventt.ReceivedImageFile, "Event");
		}

        return Ok(_eventService.CreateNew(eventt));
    }

    [HttpGet]
    [Route("GetEventByID/{id}")]
    public IActionResult GetEventByID(
		[Required(ErrorMessage = "EventId is required.")]
		[Range(1, int.MaxValue, ErrorMessage = "EventId must be a positive number.")]
		int id)
    {
        Event eventt = _eventService.GetById(id);
        if (eventt == null)
            return NotFound();
		return Ok(eventt);
    }

    [HttpGet]
    [Route("GetAllEvents")]
    public List<Event> GetAllEvents()
    {
        return _eventService.GetAll();
    }

	[HttpGet]
	[Route("GetAllActiveEvents")]
	public List<Event> GetAllActiveEvents()
	{
		return _eventService.GetAllActiveEvents();
	}

	[HttpGet]
	[Route("GetAllActiveEventsWithDetails")]
	public List<EventWithDetailsDTO> GetAllActiveEventsWithDetails()
	{
		return _eventService.GetAllActiveEventsWithDetails();
	}

	[HttpGet]
	[Route("GetAllEventsWithDetails")]
	public List<EventWithDetailsDTO> GetAllEventsWithDetails()
	{
		return _eventService.GetAllEventsWithDetails();
	}

	[HttpPut]
    [Route("UpdateEvent")]
    public IActionResult UpdateEvent([FromForm] Event eventt)
    {
		if (eventt.ReceivedImageFile != null)
		{
			if (!ImageUtility.IsImageContentType(eventt.ReceivedImageFile.ContentType))
				return BadRequest("Invalid file type. Only images are allowed.");

			eventt.ImagePath = ImageUtility.ReplaceImage(eventt.ImagePath, eventt.ReceivedImageFile, "Event");
		}
        if (!_eventService.Update(eventt))
            return NotFound();
        return Ok();
    }

    [HttpDelete]
    [Route("DeleteEvent/{id}")]
    public IActionResult DeleteEvent(
		[Required(ErrorMessage = "EventId is required.")]
		[Range(1, int.MaxValue, ErrorMessage = "EventId must be a positive number.")]
		int id)
    {
		if(!_eventService.Delete(id))
            return NotFound();
        return Ok();
    }

    [HttpGet("GetAllEventsByCreatorId/{id}")]
    public IActionResult GetAllEventsByCreatorId([Range(1, int.MaxValue, ErrorMessage = "User id must be a positive number.")] int id) 
    {
        return Ok(_eventService.GetAllEventsByCreatorId(id));
    }
}
