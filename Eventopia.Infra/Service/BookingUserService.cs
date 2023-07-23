using Eventopia.Core.Data;
using Eventopia.Core.Repository;
using Eventopia.Core.Service;


namespace Eventopia.Infra.Service;

public class BookingUserService : IBookingUserService
{
    private readonly IBookingUserRepository _bookingUserRepository;

    public BookingUserService(IBookingUserRepository bookingUserRepository)
    {
        _bookingUserRepository = bookingUserRepository;
    }

    public void AddUserToBooking(Booking booking)
    {
        _bookingUserRepository.AddUserToBooking(booking);
    }

    public void DeleteUserFromBooking(int userId, int eventId)
    {
        _bookingUserRepository.DeleteUserFromBooking(userId, eventId);
    }
}
