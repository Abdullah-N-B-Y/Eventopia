using Eventopia.Core.Data;
using Eventopia.Core.Repository;
using Eventopia.Core.Service;
using System;
using System.Collections.Generic;

namespace Eventopia.Infra.Service
{
    public class EventService : IService<Event>
    {
        private readonly IRepository<Event> _eventRepository;

        public EventService(IRepository<Event> eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public void CreateNew(Event @event)
        {
            _eventRepository.CreateNew(@event);
        }

        public void Delete(int id)
        {
            _eventRepository.Delete(id);
        }

        public void Delete(decimal id)
        {
            throw new NotImplementedException();
        }

        public List<Event> GetAll()
        {
            return _eventRepository.GetAll();
        }

        public Event GetById(int id)
        {
            return _eventRepository.GetById(id);
        }

        public Event GetById(decimal id)
        {
            throw new NotImplementedException();
        }

        public void Update(Event @event)
        {
            _eventRepository.Update(@event);
        }
    }
}
