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

    public bool CreateNew(Message t)
    {
        return _messageRepository.CreateNew(t);
    }

    public bool Delete(int id)
    {
        return _messageRepository.Delete(id);
    }

    public List<Message> GetAll()
    {
        return _messageRepository.GetAll();
    }

    public Message GetById(int id)
    {
        return _messageRepository.GetById(id);
    }

    public bool Update(Message t)
    {
        return _messageRepository.Update(t);
    }
}
