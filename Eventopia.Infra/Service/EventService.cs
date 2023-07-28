using Eventopia.Core.Data;
using Eventopia.Core.DTO;
using Eventopia.Core.Repository;
using Eventopia.Core.Service;


namespace Eventopia.Infra.Service;

public class EventService : IEventService
{
    private readonly IEventRepository _eventRepository;

    public EventService(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }

    public List<Event> GetEventsBetweenDates(SearchBetweenDatesDTO datesDTO)
    {
        var allEvents = _eventRepository.GetAll();
        return allEvents.Where(e => e.Startdate >= datesDTO.Startdate && e.Enddate <= datesDTO.Enddate).ToList();
    }

    public List<Event> SearchEventsByName(string eventName)
    {
        return _eventRepository.SearchEventsByName(eventName);
    }
    
    public void CreateNew(Event @event)
    {
        _eventRepository.CreateNew(@event);
    }

    public void Delete(int id)
    {
        _eventRepository.Delete(id);
    }

    public List<Event> GetAll()
    {
        return _eventRepository.GetAll();
    }

    public Event GetById(int id)
    {
        return _eventRepository.GetById(id);
    }

    public void Update(Event @event)
    {
        _eventRepository.Update(@event);
    }
}
