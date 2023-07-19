using Eventopia.Core.Data;
using Eventopia.Core.Service;
using Microsoft.AspNetCore.Mvc;

namespace Eventopia.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IService<Booking> _bookingService;

        public BookingController(IService<Booking> bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpPost]
        [Route("CreateNewBooking")]
        public void CreateNewBooking(Booking booking)
        {
            _bookingService.CreateNew(booking);
        }

        [HttpGet]
        [Route("GetBookingByID/{id}")]
        public Booking GetBookingByID(int id)
        {
            return _bookingService.GetById(id);
        }

        [HttpGet]
        [Route("GetAllBooking")]
        public List<Booking> GetAllBooking()
        {
            return _bookingService.GetAll();
        }

        [HttpPut]
        [Route("UpdateBooking")]
        public void UpdateBooking(Booking booking) 
        {
            _bookingService.Update(booking);
        }

        [HttpDelete]
        [Route("DeleteBooking/{id}")]
        public void DeleteBooking(int id)
        {
            _bookingService.Delete(id);
        }
    }
}
