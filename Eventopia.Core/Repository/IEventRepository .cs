using Eventopia.Core.Data;

namespace Eventopia.Core.Repository;

public interface IEventRepository : IRepository<Event>
{
    List<Event> SearchEventsByName(string eventName);
	List<Event> SearchEventsBetweenDates(DateTime startDate, DateTime endDate);
}
