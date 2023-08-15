using Eventopia.Core.Data;
using Eventopia.Core.DTO;

namespace Eventopia.Core.Repository;

public interface IEventRepository : IRepository<Event>
{
    List<Event> SearchEventsByName(string eventName);
	List<Event> SearchEventsBetweenDates(DateTime startDate, DateTime endDate);
    List<Event> GetAllEventsByCreatorId(int creatorId);
    List<Event> GetAllActiveEvents();
	List<EventWithDetailsDTO> GetAllEventsWithDetails();
	List<EventWithDetailsDTO> GetAllActiveEventsWithDetails();
}
