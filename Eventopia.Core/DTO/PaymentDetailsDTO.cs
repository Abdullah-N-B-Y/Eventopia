using Eventopia.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventopia.Core.DTO
{
	public class PaymentDetailsDTO
	{
		public decimal? UserId { get; set; }
		public decimal? EventId { get; set; }
		public decimal? PaymentAmount { get; set; }
		public Bank? Bank { get; set; }
	}
}
