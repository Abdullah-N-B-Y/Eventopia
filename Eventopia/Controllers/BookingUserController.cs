
using Eventopia.Core.Data;
using Eventopia.Core.Service;
using Microsoft.AspNetCore.Mvc;

namespace Eventopia.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookingUserController : ControllerBase
{
    private readonly IBookingUserService _bookingUserService;

    public BookingUserController(IBookingUserService bookingUserService)
    {
        _bookingUserService = bookingUserService;
    }

    [HttpPost]
    [Route("AddUserToBooking")]
    public void AddUserToBooking(Booking booking)
    {
        _bookingUserService.AddUserToBooking(booking);
    }
    [HttpDelete]
    [Route("DeleteUserFromBooking")]
    public void DeleteUserFromBooking(int userId, int eventId)
    {
        _bookingUserService.DeleteUserFromBooking(userId, eventId);
    }
}
