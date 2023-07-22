using Eventopia.Core.Data;
using Eventopia.Core.Service;
using Eventopia.Infra.Service;
using Microsoft.AspNetCore.Mvc;

namespace Eventopia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IService<Event> _eventService;

        public EventController(IService<Event> eventService)
        {
            _eventService = eventService;
        }

        [HttpPost]
        [Route("CreateNewEvent")]
        public void CreateNewEvent(Event eventt)
        {
            _eventService.CreateNew(eventt);
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
        public void UpdateEvent(Event eventt)
        {
            _eventService.Update(eventt);
        }

        [HttpDelete]
        [Route("DeleteEvent/{id}")]
        public void DeleteEvent(int id)
        {
            _eventService.Delete(id);
        }
    }
}
