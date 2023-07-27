using Eventopia.Core.Data;
using Eventopia.Core.Service;
using Microsoft.AspNetCore.Mvc;

namespace Eventopia.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CommentsController : ControllerBase
	{
		private readonly ICommentsService _commentsService;

		public CommentsController(ICommentsService commentsService)
		{
			_commentsService = commentsService;
		}

		[HttpPost]
		[Route("CreateNewComment")]
		public void CreateNewComment(Comment comment)
		{
			_commentsService.CreateNew(comment);
		}

		[HttpDelete]
		[Route("DeleteComment/{id}")]
		public void DeleteComment(int id)
		{
			_commentsService.Delete(id);
		}

		[HttpGet]
		[Route("GetAllComments")]
		public List<Comment> GetAllComments()
		{
			return _commentsService.GetAll();
		}

		[HttpGet]
		[Route("GetById/{id}")]
		public Comment GetById(int id)
		{
			return _commentsService.GetById(id);
		}

		[HttpGet]
		[Route("GetEventComments/{eventId}")]
		public List<Comment> GetEventComments(int eventId)
		{
			return _commentsService.GetEventComments(eventId);
		}

		[HttpGet]
		[Route("GetUserComments/{userId}")]
		public List<Comment> GetUserComments(int userId)
		{
			return _commentsService.GetUserComments(userId);
		}

		[HttpGet]
		[Route("GetUserCommentsOnEvent/{eventId}/{userId}")]
		public List<Comment> GetUserCommentsOnEvent(int eventId, int userId)
		{
			return _commentsService.GetUserCommentsOnEvent(eventId, userId);
		}

		[HttpPut]
		[Route("UpdateComment")]
		public void UpdateComment(Comment comment)
		{
			_commentsService.Update(comment);
		}

	}
}
