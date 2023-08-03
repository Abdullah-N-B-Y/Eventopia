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
		public IActionResult CreateNewComment([FromBody] Comment comment)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			_commentsService.CreateNew(comment);
			return Ok();
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
		public IActionResult UpdateComment([FromBody] Comment comment)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			_commentsService.Update(comment);

			return Ok();
		}

	}
}
