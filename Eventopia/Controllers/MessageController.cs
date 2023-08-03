using Eventopia.Core.Data;
using Eventopia.Core.Service;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Eventopia.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MessageController : ControllerBase
{
    private readonly IService<Message> _messageService;

    public MessageController(IService<Message> messageService)
    {
        _messageService = messageService;
    }

    [HttpPost]
    [Route("CreateNewMessage")]
    public IActionResult CreateNewMessage([FromBody] Message message)
    {
        return Ok(_messageService.CreateNew(message));
    }

    [HttpGet]
    [Route("GetMessageByID/{id}")]
    public IActionResult GetMessageByID(
		[Required(ErrorMessage = "MessageId is required.")]
		[Range(1, int.MaxValue, ErrorMessage = "MessageId must be a positive number.")]
		int id)
    {
		return Ok(_messageService.GetById(id));
    }

    [HttpGet]
    [Route("GetAllMessages")]
    public List<Message> GetAllMessages()
    {
        return _messageService.GetAll();
    }

    [HttpPut]
    [Route("UpdateMessage")]
    public IActionResult UpdateMessage([FromBody] Message message)
    {
        return Ok(_messageService.Update(message));
    }

    [HttpDelete]
    [Route("DeleteMessage/{id}")]
    public IActionResult DeleteMessage(
		[Required(ErrorMessage = "MessageId is required.")]
		[Range(1, int.MaxValue, ErrorMessage = "MessageId must be a positive number.")]
		int id)
    {
		return Ok(_messageService.Delete(id));
    }
}
