using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventopia.Core.DTO
{
    public class SearchBetweenDatesDTO
    {
        public DateTime? Startdate { get; set; }

        public DateTime? Enddate { get; set; }
    }
}
