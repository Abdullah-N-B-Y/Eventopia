using Eventopia.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventopia.Core.Repository
{
    public interface IEventRepository : IRepository<Event>
    {
        List<Event> SearchEventsByName(string eventName);
    }
}
