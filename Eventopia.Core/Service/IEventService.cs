using Eventopia.Core.Data;
using Eventopia.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventopia.Core.Service
{
    public interface IEventService : IService<Event>
    {
        List<Event> GetEventsBetweenDates(SearchBetweenDatesDTO datesDTO);
    }

}
