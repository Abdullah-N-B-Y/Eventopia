using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventopia.Core.DTO
{
    public class GetBenefitsReportDTO
    {
        public decimal? MonthlyBenefits { get; set; }
        public decimal? AnnualBenefits { get; set; }
    }
}
