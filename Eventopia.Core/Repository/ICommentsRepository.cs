using Eventopia.Core.Data;

namespace Eventopia.Core.Repository;

public interface ICommentsRepository : IRepository<Comment>
{
	List<Comment> GetEventComments(int eventId);
	List<Comment> GetUserComments(int userId);
	List<Comment> GetUserCommentsOnEvent(int eventId, int userId);
}
