using Eventopia.Core.Data;
using Eventopia.Core.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Eventopia.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize(Policy = "AdminAndUserOnly")]
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
			_commentsService.CreateNew(comment);
			return Ok();
		}

		[HttpDelete]
		[Route("DeleteComment/{id}")]
		public IActionResult DeleteComment(
			[Required(ErrorMessage = "CommentId is required.")]
			[Range(1, int.MaxValue, ErrorMessage = "CommentId must be a positive number.")]
			int id)
		{
			if (!_commentsService.Delete(id))
				return NotFound();
			
			return Ok();
		}

		[HttpGet]
		[Route("GetAllComments")]
		public List<Comment> GetAllComments()
		{
			return _commentsService.GetAll();
		}

		[HttpGet]
		[Route("GetCommentById/{id}")]
		public IActionResult GetCommentById(
			[Required(ErrorMessage = "CommentId is required.")]
			[Range(1, int.MaxValue, ErrorMessage = "CommentId must be a positive number.")]
			int id)
		{
			Comment comment = _commentsService.GetById(id);
			if(comment == null)
				return NotFound();
			return Ok(comment);
		}

		[HttpGet]
		[Route("GetEventComments/{eventId}")]
		public IActionResult GetEventComments(
			[Required(ErrorMessage = "EventId is required.")]
			[Range(1, int.MaxValue, ErrorMessage = "EventId must be a positive number.")]
			int eventId)
		{
			return Ok(_commentsService.GetEventComments(eventId));
		}

		[HttpGet]
		[Route("GetUserComments/{userId}")]
		public IActionResult GetUserComments(
			[Required(ErrorMessage = "UserId is required.")]
			[Range(1, int.MaxValue, ErrorMessage = "UserId must be a positive number.")]
			int userId)
		{
			return Ok(_commentsService.GetUserComments(userId));
		}

		[HttpGet]
		[Route("GetUserCommentsOnEvent/{eventId}/{userId}")]
		public IActionResult GetUserCommentsOnEvent(
			[Required(ErrorMessage = "EventId is required.")]
			[Range(1, int.MaxValue, ErrorMessage = "EventId must be a positive number.")]
			int eventId,
			[Required(ErrorMessage = "UserId is required.")]
			[Range(1, int.MaxValue, ErrorMessage = "UserId must be a positive number.")]
			int userId)
		{
			return Ok(_commentsService.GetUserCommentsOnEvent(eventId, userId));
		}

		[HttpPut]
		[Route("UpdateComment")]
		public IActionResult UpdateComment([FromBody] Comment comment)
		{
			_commentsService.Update(comment);

			return Ok();
		}

	}
}
