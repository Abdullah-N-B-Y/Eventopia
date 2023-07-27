using Eventopia.Core.Data;

namespace Eventopia.Core.Service;

public interface ICommentsService: IService<Comment>
{
	List<Comment> GetEventComments(int eventId);
	List<Comment> GetUserComments(int userId);
	List<Comment> GetUserCommentsOnEvent(int eventId, int userId);
}
