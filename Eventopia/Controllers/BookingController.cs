using Eventopia.Core.Data;
using Eventopia.Core.Service;
using Eventopia.Infra.Service;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Eventopia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpPost]
        [Route("CreateNewBooking")]
        public IActionResult CreateNewBooking([FromBody] Booking booking)
        {
			_bookingService.CreateNew(booking);

            return Ok();
        }

        [HttpGet]
        [Route("GetBookingByID/{id}")]
        public IActionResult GetBookingByID(
			[Required(ErrorMessage = "BookingId is required.")]
		    [Range(1, int.MaxValue, ErrorMessage = "BookingId must be a positive number.")]
			int id)
        {
			return Ok(_bookingService.GetById(id));
        }

        [HttpGet]
        [Route("GetAllBooking")]
        public List<Booking> GetAllBooking()
        {
            return _bookingService.GetAll();
        }

        [HttpPut]
        [Route("UpdateBooking")]
        public IActionResult UpdateBooking([FromBody] Booking booking) 
        {
			_bookingService.Update(booking);
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteBooking/{id}")]
        public IActionResult DeleteBooking(
			[Required(ErrorMessage = "BookingId is required.")]
			[Range(1, int.MaxValue, ErrorMessage = "BookingId must be a positive number.")]
			int id)
        {
            _bookingService.Delete(id);
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteUserFromBooking/{userId}/{eventId}")]
        public IActionResult DeleteUserFromBooking(
			[Required(ErrorMessage = "UserId is required.")]
			[Range(1, int.MaxValue, ErrorMessage = "UserId must be a positive number.")]
			int userId,
			[Required(ErrorMessage = "EventId is required.")]
			[Range(1, int.MaxValue, ErrorMessage = "EventId must be a positive number.")]
			int eventId)
        {
			_bookingService.DeleteUserFromBooking(userId, eventId);
            return Ok();
        }
    }
}
