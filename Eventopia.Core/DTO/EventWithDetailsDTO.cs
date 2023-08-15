using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventopia.Core.DTO
{
	public class EventWithDetailsDTO
	{
		public decimal Id { get; set; }

		public string? Name { get; set; }

		public decimal? AttendingCost { get; set; }

		public DateTime? StartDate { get; set; }

		public DateTime? EndDate { get; set; }

		public string? Status { get; set; }

		public string? EventDescription { get; set; }

		public string? ImagePath { get; set; }

		public decimal? EventCapacity { get; set; }

		public decimal? Latitude { get; set; }

		public decimal? Longitude { get; set; }

		public string? Address { get; set; }

		public decimal? EventCreatorId { get; set; }

		public decimal? CategoryId { get; set; }

		public string? RetrievedImageFile { get; set; }

		public string? CategoryName { get; set; }

		public string? CreatorName { get; set; }
	}
}
