using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventopia.Core.DTO
{
    public class StatisticsDTO
    {
        public int NumberOfUsers { get; set; }
        public int NumberOfEvents { get; set; }
        public int MaxEventAttendees { get; set; }
        public int MaxEventID { get; set; }
    }
}
