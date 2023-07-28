using Eventopia.Core.Data;
using Eventopia.Core.Service;
using Microsoft.AspNetCore.Mvc;

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
    public bool CreateNewMessage([FromBody] Message message)
    {
        return _messageService.CreateNew(message);
    }

    [HttpGet]
    [Route("GetMessageByID/{id}")]
    public Message GetMessageByID(int id)
    {
        return _messageService.GetById(id);
    }

    [HttpGet]
    [Route("GetAllMessages")]
    public List<Message> GetAllMessages()
    {
        return _messageService.GetAll();
    }

    [HttpPut]
    [Route("UpdateMessage")]
    public bool UpdateMessage(Message message)
    {
        return _messageService.Update(message);
    }

    [HttpDelete]
    [Route("DeleteMessage/{id}")]
    public bool DeleteMessage(int id)
    {
        return _messageService.Delete(id);
    }
}
