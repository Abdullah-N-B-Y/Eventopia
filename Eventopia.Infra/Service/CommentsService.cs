using Eventopia.Core.Data;
using Eventopia.Core.Repository;
using Eventopia.Core.Service;

namespace Eventopia.Infra.Service;

public class CommentsService: ICommentsService
{
	private readonly ICommentsRepository _commentsRepository;

	public CommentsService(ICommentsRepository commentsRepository)
	{
		_commentsRepository = commentsRepository;
	}

	public bool CreateNew(Comment comment)
	{
		return _commentsRepository.CreateNew(comment);
	}

	public bool Delete(int id)
	{
		return _commentsRepository.Delete(id);
	}

	public List<Comment> GetAll()
	{
		return _commentsRepository.GetAll();
	}

	public Comment GetById(int id)
	{
		return _commentsRepository.GetById(id);
	}

	public List<Comment> GetEventComments(int eventId)
	{
		return _commentsRepository.GetEventComments(eventId);
	}

	public List<Comment> GetUserComments(int userId)
	{
		return _commentsRepository.GetUserComments(userId);
	}

	public List<Comment> GetUserCommentsOnEvent(int eventId, int userId)
	{
		return _commentsRepository.GetUserCommentsOnEvent(eventId, userId);
	}

	public bool Update(Comment comment)
	{
		return _commentsRepository.Update(comment);
	}
}
