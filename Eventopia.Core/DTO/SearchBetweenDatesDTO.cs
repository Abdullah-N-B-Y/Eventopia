
using System.ComponentModel.DataAnnotations;

namespace Eventopia.Core.DTO
{
    public class SearchBetweenDatesDTO
    {
		[Required(ErrorMessage = "StartDate is required.")]
		public DateTime StartDate { get; set; }

		[Required(ErrorMessage = "EndDate is required.")]
		public DateTime EndDate { get; set; }
    }
}
