using Eventopia.Core.Data;

namespace Eventopia.Core.Service;

public interface IBookingUserService
{
    void AddUserToBooking(Booking booking);
    void DeleteUserFromBooking(int userId, int eventId);
}
