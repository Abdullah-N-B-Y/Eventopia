using Eventopia.Core.Data;
using Eventopia.Core.DTO;
using Eventopia.Core.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Eventopia.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EventController : ControllerBase
{
    private readonly IEventService _eventService; 

    public EventController(IEventService eventService) 
    {
        _eventService = eventService;
    }

    [HttpPost]
    [Route("SearchEventsBetweenDates")]
    //[Authorize(Policy = "AdminOnly")]
    public ActionResult<List<Event>> SearchEventsBetweenDates([FromBody] SearchBetweenDatesDTO searchDTO)
    {
		if (!ModelState.IsValid)
		{
			return BadRequest(ModelState);
		}
		// Call the backend logic to get the events within the date range
		List<Event> eventsInRange = ((IEventService)_eventService).GetEventsBetweenDates(searchDTO); 

        // Return the result to the admin
        return Ok(eventsInRange);
    }


    [HttpPost]
    [Route("SearchEventsByName")]
    //[AllowAnonymous] 
    public ActionResult<List<Event>> SearchEventsByName(string eventName)
    {
        // Call the backend logic to search events by name
        List<Event> eventsByName = _eventService.SearchEventsByName(eventName);

        // Return the result
        return Ok(eventsByName);
    }

    [HttpPost]
    [Route("CreateNewEvent")]
    public IActionResult CreateNewEvent([FromBody] Event eventt)
    {
		if (!ModelState.IsValid)
		{
			return BadRequest(ModelState);
		}
		_eventService.CreateNew(eventt);

        return Ok();
    }

    [HttpGet]
    [Route("GetEventByID/{id}")]
    public Event GetEventByID(int id)
    {
        return _eventService.GetById(id);
    }

    [HttpGet]
    [Route("GetAllEvents")]
    public List<Event> GetAllEvents()
    {
        return _eventService.GetAll();
    }

    [HttpPut]
    [Route("UpdateEvent")]
    public IActionResult UpdateEvent([FromBody] Event eventt)
    {
		if (!ModelState.IsValid)
		{
			return BadRequest(ModelState);
		}
		_eventService.Update(eventt);
        return Ok();
    }

    [HttpDelete]
    [Route("DeleteEvent/{id}")]
    public void DeleteEvent(int id)
    {
        _eventService.Delete(id);
    }
}
