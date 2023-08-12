using Eventopia.Core.Data;
using Eventopia.Core.DTO;


namespace Eventopia.Core.Service;

public interface IEventService : IService<Event>
{
    List<Event> GetEventsBetweenDates(SearchBetweenDatesDTO datesDTO);
    List<Event> SearchEventsByName(string eventName);
    List<Event> GetAllEventsByCreatorId(int creatorId);
}
