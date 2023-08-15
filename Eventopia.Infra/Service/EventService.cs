using Eventopia.Core.Data;
using Eventopia.Core.DTO;
using Eventopia.Core.Repository;
using Eventopia.Core.Service;
using Eventopia.Infra.Repository;
using Eventopia.Infra.Utility;

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
		List<Event> events = _eventRepository.SearchEventsBetweenDates(datesDTO.StartDate, datesDTO.EndDate);
		foreach (Event e in events)
		{
			string? byteFile = ImageUtility.RetrieveImage(e.ImagePath, "Event");
			e.RetrievedImageFile = byteFile;
		}
		return events;
    }

    public List<Event> SearchEventsByName(string eventName)
    {
        List<Event> events = _eventRepository.SearchEventsByName(eventName);
        foreach(Event e in events)
        {
			string? byteFile = ImageUtility.RetrieveImage(e.ImagePath, "Event");
			e.RetrievedImageFile = byteFile;
		}
        return events;
    }
    
    public bool CreateNew(Event @event)
    {
        return _eventRepository.CreateNew(@event);
    }

    public bool Delete(int id)
    {
		Event eventt = _eventRepository.GetById(id);
		if (eventt == null)
			return false;
		ImageUtility.DeleteImage(eventt.ImagePath, "Event");
		return _eventRepository.Delete(id);
    }

    public List<Event> GetAll()
    {
		List<Event> events = _eventRepository.GetAll();
		foreach (Event e in events)
		{
			string? byteFile = ImageUtility.RetrieveImage(e.ImagePath, "Event");
			e.RetrievedImageFile = byteFile;
		}
		return events;
    }

    public Event GetById(int id)
    {
		Event eventt = _eventRepository.GetById(id);
		if (eventt == null)
			return null;
		string? byteFile = ImageUtility.RetrieveImage(eventt.ImagePath, "Event");
		eventt.RetrievedImageFile = byteFile;
		return eventt;
    }

    public bool Update(Event @event)
    {
        return _eventRepository.Update(@event);
    }

    public List<Event> GetAllEventsByCreatorId(int creatorId) 
    {
        return _eventRepository.GetAllEventsByCreatorId(@creatorId);
    }

	public List<Event> GetAllActiveEvents()
	{
		List<Event> events = _eventRepository.GetAllActiveEvents();
		foreach (Event e in events)
		{
			string? byteFile = ImageUtility.RetrieveImage(e.ImagePath, "Event");
			e.RetrievedImageFile = byteFile;
		}
		return events;
	}
}
