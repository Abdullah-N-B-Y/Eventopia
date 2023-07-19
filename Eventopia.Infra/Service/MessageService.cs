
using Eventopia.Core.Data;
using Eventopia.Core.Repository;
using Eventopia.Core.Service;

namespace Eventopia.Infra.Service;

public class MessageService : IService<Message>
{

    private readonly IRepository<Message> _messageRepository;

    public MessageService(IRepository<Message> messageRepository)
    {
        _messageRepository = messageRepository;
    }

    public void CreateNew(Message t)
    {
        _messageRepository.CreateNew(t);
    }

    public void Delete(int id)
    {
        _messageRepository.Delete(id);
    }

    public List<Message> GetAll()
    {
        return _messageRepository.GetAll();
    }

    public Message GetById(int id)
    {
        return _messageRepository.GetById(id);
    }

    public void Update(Message t)
    {
        _messageRepository.Update(t);
    }
}
